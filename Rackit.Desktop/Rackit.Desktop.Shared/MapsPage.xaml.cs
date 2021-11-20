using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls.Maps;
using Windows.Devices.Geolocation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Rackit.Desktop
{
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class MapsPage : Page
  {
    private MapControl Mappie;

    public MapsPage()
    {
      this.InitializeComponent();      
      Mappie = new MapControl();
      Mappie.Style = MapStyle.Terrain;
      Mappie.ZoomLevel = 12;
      Mappie.Center = new Geopoint(new BasicGeoposition() { Latitude = 51.885804, Longitude = 0.238923 });
      Mappie.HorizontalAlignment = HorizontalAlignment.Left;
      Mappie.Margin = new Thickness(84, 401, 0, 0);
      Mappie.VerticalAlignment = VerticalAlignment.Top;        
      gdMappie.Children.Add(Mappie);
    }
  }
}
