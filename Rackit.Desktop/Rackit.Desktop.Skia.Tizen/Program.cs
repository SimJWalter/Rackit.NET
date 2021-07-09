using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace Rackit.Desktop.Skia.Tizen
{
  class Program
  {
    static void Main(string[] args)
    {
      var host = new TizenHost(() => new Rackit.Desktop.App(), args);
      host.Run();
    }
  }
}
