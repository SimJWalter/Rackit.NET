using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Rackit.Desktop.Helper
{
  internal static class DialogManager
  {
    private static readonly SemaphoreSlim _oneAtATimeAsync = new SemaphoreSlim(1, 1);

    internal static async Task<T> OneAtATimeAsync<T>(Func<Task<T>> show, TimeSpan? timeout, CancellationToken? token)
    {
      var to = timeout ?? TimeSpan.FromHours(1);
      var tk = token ?? new CancellationToken(false);
      if (!await _oneAtATimeAsync.WaitAsync(to, tk))
      {
        throw new Exception($"{nameof(DialogManager)}.{nameof(OneAtATimeAsync)} has timed out.");
      }
      try
      {
        return await show();
      }
      finally
      {
        _oneAtATimeAsync.Release();
      }
    }

    internal static async Task<ContentDialogResult> ShowOneAtATimeAsync(
    this ContentDialog dialog,
    TimeSpan? timeout = null,
    CancellationToken? token = null)
    {
      return await DialogManager.OneAtATimeAsync(async () => await dialog.ShowAsync(), timeout, token);
    }
  }
}
