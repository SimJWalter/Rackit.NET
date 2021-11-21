using SkiaSharp;
using SkiaSharp.Views.UWP;
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
using Windows.Graphics.Display;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Rackit.Desktop
{

  public sealed partial class CanvasSWPage : Page
  {
    private Point _currentPosition;
    public CanvasSWPage()
    {
      this.InitializeComponent();
    }

    private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
    {
      // the the canvas and properties
      var canvas = e.Surface.Canvas;
      var info = e.Info;

      Render(canvas, new Size(info.Width, info.Height), SKColors.Yellow, "SkiaSharp Software Rendering");
    }

    private void OnPointerMovedII(object sender, PointerRoutedEventArgs e)
    {
      _currentPosition = e.GetCurrentPoint(panelGrid).Position;
      currentPositionText.Text = _currentPosition.ToString();
      swCanvas.Invalidate();
    }


    private void Render(SKCanvas canvas, Size size, SKColor color, string text)
    {
      // get the screen density for scaling
      var display = DisplayInformation.GetForCurrentView();
      var scale = display.LogicalDpi / 96.0f;
      var scaledSize = new SKSize((float)size.Width / scale, (float)size.Height / scale);

      // handle the device screen density
      canvas.Scale(scale);

      // make sure the canvas is blank
      canvas.Clear(color);

      // draw some text
      var paint = new SKPaint
      {
        Color = SKColors.Black,
        IsAntialias = true,
        Style = SKPaintStyle.Fill,
        TextAlign = SKTextAlign.Center,
        TextSize = 24
      };
      var coord = new SKPoint(scaledSize.Width / 2, (scaledSize.Height + paint.TextSize) / 2);
      canvas.DrawText(text, coord, paint);

      var circlePaint = new SKPaint
      {
        Style = SKPaintStyle.Fill,
        Color = SKColors.Red

      };

      canvas.DrawCircle((float)_currentPosition.X, (float)_currentPosition.Y, 5, circlePaint);
    }
  }
}
