using Rackit.Desktop.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Rackit.Desktop
{
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class MainPage : Page
  {
    public ApplicationViewTitleBar TitleBar { get; }

    public ICommand SaveCommand { get; }
    public ICommand DemoCommand { get; }

    public MainPage()
    {
      this.InitializeComponent();
#if NETFX_CORE
      CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
      Window.Current.SetTitleBar(BackgroundElement);
      TitleBar = ApplicationView.GetForCurrentView().TitleBar;
      TitleBar.ButtonBackgroundColor = new Color() { A = 0, R = 54, G = 60, B = 116 };
      TitleBar.ButtonHoverBackgroundColor = new Color() { A = 0, R = 19, G = 21, B = 40 };
      TitleBar.ButtonPressedBackgroundColor = new Color() { A = 0, R = 232, G = 211, B = 162 };
      TitleBar.ButtonInactiveBackgroundColor = new Color() { A = 0, R = 135, G = 141, B = 199 };
#endif

      this.SaveCommand = new RelayCommand(OnSave);
      this.DemoCommand = new RelayCommand<string>(OnDemo);
    }

    private async void OnDemo(string text)
    {
      await new ContentDialog
      {
        Title = "On demo!",
        Content = DateTime.Now.Millisecond.ToString(),
        PrimaryButtonText = "OK"
      }.ShowOneAtATimeAsync();
    }

    private async void OnSave()
    {
      await new ContentDialog
      {
        Title = "On save!",
        Content = DateTime.Now.Millisecond.ToString(),
        PrimaryButtonText = "OK"
      }.ShowOneAtATimeAsync();
    }

    private async void MenuFlyoutOpen_Click(object sender, RoutedEventArgs e)
    {
      await new ContentDialog
      {
        Title = "On open!",
        Content = DateTime.Now.Millisecond.ToString(),
        PrimaryButtonText = "OK"
      }.ShowOneAtATimeAsync();
    }

    private async void MenuFlyoutItemAbout_Click(object sender, RoutedEventArgs e)
    {
      await new ContentDialog
      {
        Title = "On about!",
        Content = "all about something",
        PrimaryButtonText = "OK"
      }.ShowOneAtATimeAsync();
    }
  }
}
