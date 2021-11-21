using Rackit.Desktop.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Rackit.Desktop
{
  public sealed partial class RootLayout : Grid
  {
    public RootLayout(Frame contentFrame)
    {
      this.InitializeComponent();
      Window.Current.SetTitleBar(bkgTitleBar);
      this.SaveCommand = new RelayCommand(OnSave);
      this.DemoCommand = new RelayCommand<string>(OnDemo);
      gdMainCont.Children.Add(contentFrame);
    }

    public ICommand SaveCommand { get; }
    public ICommand DemoCommand { get; }

    private void MenuFlyoutItemMaps_Click(object sender, RoutedEventArgs e)
    {
      App.Instance.ContentFrame.Navigate(typeof(MapsPage));
    }    

    private async void OnDemo(string text)
    {
      await new ContentDialog
      {
        Title = "On demo!",
        Content = DateTime.Now.Millisecond.ToString() + ":" + text,
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
    private void MenuFlyoutItemSWCanvas_Click(object sender, RoutedEventArgs e)
    {
      App.Instance.ContentFrame.Navigate(typeof(CanvasSWPage));
    }
    private void MenuFlyoutItemHWCanvas_Click(object sender, RoutedEventArgs e)
    {
      App.Instance.ContentFrame.Navigate(typeof(CanvasHWPage));
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
