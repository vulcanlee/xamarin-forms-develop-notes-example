using SkiaSharp;
using Xamarin.Forms;
using SkiaSharp.Views.Forms;
using System;

namespace XFSkiaSharp.Views
{
    public enum 重繪狀態
    {
        第一次初始化,
        清除,
        繪製點,
        繪製線,
        收集資料
    }
    public partial class MainPage : ContentPage
    {
        public 重繪狀態 _重繪狀態 { get; set; } = 重繪狀態.第一次初始化;
        public MainPage()
        {
            InitializeComponent();

            myBtn清除.Clicked += (s, e) =>
              {
                  _重繪狀態 = 重繪狀態.清除;
                  Canvas.InvalidateSurface();
              };

            myBtn畫線.Clicked += (s, e) =>
              {
                  _重繪狀態 = 重繪狀態.繪製線;
                  Canvas.InvalidateSurface();
              };

            myBtn畫點.Clicked += (s, e) =>
            {
                _重繪狀態 = 重繪狀態.繪製點;
                Canvas.InvalidateSurface();
            };
            myBtn收集資料.Clicked += (s, e) =>
            {
                _重繪狀態 = 重繪狀態.收集資料;
                Canvas.InvalidateSurface();
            };
        }

        int surfaceWidth;
        int surfaceHeight;
        SKCanvas myCanvas;
        private void OnPaintSample(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            surfaceWidth = e.Info.Width;
            surfaceHeight = e.Info.Height;
            myCanvas = e.Surface.Canvas;
            float side = Math.Min(surfaceHeight, surfaceWidth) * 0.5f;

            switch (_重繪狀態)
            {
                case 重繪狀態.第一次初始化:
                    myCanvas.Clear(Color.Gray.ToSKColor());  //paint it black
                    break;
                case 重繪狀態.清除:
                    myCanvas.Clear(Color.Black.ToSKColor());  //paint it black
                    myCanvas.Clear(Color.Red.ToSKColor());  //paint it black
                    myCanvas.Clear(Color.Blue.ToSKColor());  //paint it black
                    myCanvas.Clear(Color.Gray.ToSKColor());  //paint it black
                    break;
                case 重繪狀態.繪製點:
                    var foo = 1;
                    using (SKPaint paint = new SKPaint())
                    {
                        paint.Color = Color.FromHex("00FF00").ToSKColor();
                        paint.StrokeWidth = 5;
                        Random rm = new Random();
                        for (int i = 0; i < 3000; i++)
                        {
                            //myCanvas.DrawPoint(rm.Next(300), rm.Next(300), SKColor.Parse("#00eFF00"));
                            myCanvas.DrawPoint(rm.Next(surfaceWidth), rm.Next(surfaceHeight), paint);
                        }
                    }
                    break;
                case 重繪狀態.收集資料:
                    using (SKPaint paint = new SKPaint())
                    {
                        paint.Color = Color.FromHex("FF0000").ToSKColor();
                        paint.StrokeWidth = 3;
                        Random rm = new Random();
                        for (int i = 0; i < surfaceWidth; i++)
                        {
                            var fooPM = rm.Next(10);
                            if (fooPM >= 5)
                            {
                                fooPM = -1;
                            }
                            else
                            {
                                fooPM = 1;
                            }

                            var fooY = surfaceHeight - (32 + i / 3 + (rm.Next(10) * fooPM));
                            var fooX = i;
                            myCanvas.DrawPoint(fooX, fooY, paint);
                        }
                    }
                    break;
                case 重繪狀態.繪製線:
                    using (SKPaint paint = new SKPaint())
                    {
                        paint.Color = Color.Pink.ToSKColor();
                        paint.StrokeWidth = 7;
                        Random rm = new Random();
                        var fooPreX = 0;
                        var fooPreY = surfaceHeight - 100;
                        for (int i = 0; i < surfaceWidth / 10; i++)
                        {
                            var fooPM = rm.Next(13);
                            if (fooPM >= 5)
                            {
                                fooPM = -1;
                            }
                            else
                            {
                                fooPM = 1;
                            }

                            var fooY = surfaceHeight - (100 + i + (rm.Next(50) * fooPM));
                            var fooX = i * 10;
                            myCanvas.DrawLine(fooPreX, fooPreY, fooX, fooY, paint);
                            fooPreX = fooX;
                            fooPreY = fooY;
                        }
                    }
                    break;
                default:
                    break;
            }
            return;
            using (SKPaint paint = new SKPaint())
            {
                myCanvas.Clear(Color.Gray.ToSKColor());  //paint it black
                SKRect r1 = new SKRect(10f, 20f, side, side);
                paint.Color = Color.Blue.ToSKColor();
                myCanvas.DrawRect(r1, paint);

                paint.Color = Color.Red.ToSKColor();
                myCanvas.DrawOval(r1, paint);

                paint.Color = Color.FromHex("00FF00").ToSKColor();
                paint.StrokeWidth = 5;

                Random rm = new Random();
                for (int i = 0; i < 3000; i++)
                {
                    myCanvas.DrawPoint(rm.Next(300), rm.Next(300), paint);
                    //myCanvas.DrawPoint(rm.Next(300), rm.Next(300), SKColor.Parse("#00FF00"));
                }

                paint.Color = Color.Green.ToSKColor();
                paint.TextSize = 64.0f;
                paint.IsAntialias = true;
                paint.Color = new SKColor(0x9C, 0xAF, 0xB7);
                paint.IsStroke = true;
                paint.StrokeWidth = 3;
                paint.TextAlign = SKTextAlign.Center;

                myCanvas.DrawText("這是Xamarin.Forms", 200f, 200f, paint);
                myCanvas.DrawText("這是Xamarin.Forms", surfaceWidth / 2f, surfaceHeight / 2f, paint);
            }
        }
    }
}
