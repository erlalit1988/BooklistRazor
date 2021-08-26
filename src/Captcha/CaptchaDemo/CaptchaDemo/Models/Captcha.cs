using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptchaDemo.Models
{
    public class Captcha
    {
        const string Letters = "0123456789abcdefghijklmnopqrstuvxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string GenerateCaptchaCode()
        {
            Random rand = new Random();
            int maxBand = Letters.Length - 1;

            StringBuilder sb = new StringBuilder();

            for(int i=0;i<6;i++)
            {
                int index = rand.Next(maxBand);
                sb.Append(Letters[index]);
            }
            return sb.ToString();
        }
        public static CaptchaResult GenerateCaptchaImage(int width,int height,string captchaCode)
        {
            using (Bitmap baseMap = new Bitmap(width, height))
                using(Graphics graph=Graphics.FromImage(baseMap))
            {
                Random rand = new Random();
                graph.Clear(GetRandomLightColor());
                DrawCaptchaCode();
                DrawDisorderLine();
                AdjustRippleEffect();

                MemoryStream ms = new MemoryStream();

                baseMap.Save(ms, ImageFormat.Png);

                return new CaptchaResult { CaptchaCode = captchaCode, CaptchaByteData = ms.ToArray(), Timestamp = DateTime.Now };

                int GetFontSize(int imageWidth, int captchaCodeCount)
                {
                    var averageSize = imageWidth / captchaCodeCount;
                    return Convert.ToInt32(averageSize);
                }
                Color GetRandomDeepColor()
                {
                    int redLow = 160, greenLow = 100, blueLow = 160;
                 
                    return Color.FromArgb(rand.Next(redLow), rand.Next(greenLow), rand.Next(blueLow));
                }
                Color GetRandomLightColor()
                {
                    int low = 180, high = 255;

                    int nRed = rand.Next(high) % (high - low) + low;
                    int nGreen = rand.Next(high) % (high - low) + low;
                    int nBlue= rand.Next(high) % (high - low) + low;

                    return Color.FromArgb(nRed, nGreen, nBlue);
                }
                void DrawCaptchaCode()
                {
                    SolidBrush fontBrush = new SolidBrush(Color.Black);
                    int fontSize = GetFontSize(width, captchaCode.Length);
                    Font font = new Font(FontFamily.GenericSerif, fontSize, FontStyle.Bold, GraphicsUnit.Pixel);
                    for(int i=0;i<captchaCode.Length;i++)
                    {
                        fontBrush.Color = GetRandomDeepColor();

                        int shiftPx = fontSize / 6;
                        float x = i * fontSize + rand.Next(-shiftPx, shiftPx) + rand.Next(-shiftPx, shiftPx);
                        int maxY = height - fontSize;
                        if (maxY < 0) maxY = 0;
                        float y = rand.Next(0, maxY);

                        graph.DrawString(captchaCode[i].ToString(), font, fontBrush, x, y);

                    }
                }

                void DrawDisorderLine()
                {
                    Pen linePen = new Pen(new SolidBrush(Color.Black), 3);
                    for(int i=0;i<rand.Next(3,5);i++)
                    {
                        linePen.Color = GetRandomDeepColor();

                        Point startPoint = new Point(rand.Next(0, width), rand.Next(0, height));
                        Point endPoint = new Point(rand.Next(0, width), rand.Next(0, height));
                        graph.DrawLine(linePen, startPoint, endPoint);

                        Point bezierPoint1 = new Point(rand.Next(0, width), rand.Next(0, height));
                        Point bezierPoint2 = new Point(rand.Next(0, width), rand.Next(0, height));
                        graph.DrawBezier(linePen, startPoint, bezierPoint1, bezierPoint2, endPoint);

                    }

                }
                void AdjustRippleEffect()
                {
                    short nWave = 6;
                    int nWidth = baseMap.Width;
                    int nheight = baseMap.Height;

                    Point[,] pt = new Point[nWidth, nheight];

                    double newX, newY;
                    double xo, yo;

                    for(int x=0; x<nWidth;++x)
                    {
                        for(int y=0;y<nheight;++y)
                        {
                            xo = ((double)nWave * Math.Sin(2.0 * 3.1415 * (float)y / 128.0));
                            yo = ((double)nWave * Math.Cos(2.0 * 3.1415 * (float)y / 128.0));

                            newX = (x + xo);
                            newY = (y + yo);

                            if(newX>0&&newX<nWidth)
                            {
                                pt[x, y].X = (int)newX;
                            }
                            else
                            {
                                pt[x, y].X = 0;
                            }
                        }
                    }

                    Bitmap bSrc = (Bitmap)baseMap.Clone();

                    BitmapData bitmapData=baseMap.LockBits(new Rectangle(0,0,baseMap.Width,baseMap.Height),ImageLockMode.ReadWrite,PixelFormat.Format32bppArgb);
                    BitmapData bmSrc = baseMap.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadOnly,PixelFormat.Format32bppArgb);

                }
            }

        }
       
    }
}
