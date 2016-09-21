using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;
using ImageProcPlatform.Plugin;
using IP_ChangeBrightness.Setting;
using IP_ChangeBrightness.Parameter;

namespace IP_ChangeBrightness
{
    public class ChangeBrightness : IImageProcPlugin
    {
        /// <summary>
        /// 設定画面フォーム
        /// </summary>
        private Form SettingForm;

        /// <summary>
        /// 画像処理名
        /// </summary>
        public string Name { get { return "ChangeBrightness"; } }    //RENAME

        /// <summary>
        /// 画像処理進捗
        /// </summary>
        private int _progress;
        public int progress
        {
            get
            {
                return _progress;
            }

            private set
            {
                if (0 <= value && value <= 100)
                {
                    this._progress = value;
                }
                else
                {
                    this._progress = -1;
                }
            }
        }

        ChangeBrightnessParameter changeBrightnessParameter;

        public ChangeBrightness()
        {
            changeBrightnessParameter = new ChangeBrightnessParameter(100);
        }

        /// <summary>
        /// 設定画面表示メソッド
        /// </summary>
        /// <returns></returns>
        public void Setting()
        {
            if (SettingForm == null)
            {
                SettingForm = new ChangeBrightnessSetting(); //RENAME
            }
            else if (SettingForm.IsDisposed)
            {
                SettingForm = new ChangeBrightnessSetting(); //RENAME
            }

            SettingForm.Show();
            return;
        }

        //画像処理
        public Bitmap ProcImage(Bitmap inputBMP)
        {
            Bitmap outputBMP;
            Size imageSize; //入力画像サイズ
            int maxProgress; //進捗最大値
            int procPixel = 0; //進捗率基準

            outputBMP = (Bitmap)inputBMP.Clone();
            imageSize = inputBMP.Size;
            maxProgress = imageSize.Width * imageSize.Height;   //画像サイズが変わる or 進捗がピクセル数に等しくない場合はここを変更
            progress = procPixel * 100 / maxProgress;

            ////////////////////////////////////////////////////////////////
            // 画像処理定義                                               //
            // outputBMP に処理後画像が格納されるように処理してください。 //
            //                                                            //
            // template:未定義ならば、真っ白の画像に変換                  //
            double h, s, v;
            for (int y = 0; y < imageSize.Height; y++)
            {
                for (int x = 0; x < imageSize.Width; x++)
                {
                    int r = inputBMP.GetPixel(x, y).R;
                    int g = inputBMP.GetPixel(x, y).G;
                    int b = inputBMP.GetPixel(x, y).B;
                    h = getHue(r, g, b);
                    s = getSatuation(r, g, b);
                    //v = getBrightness(r, g, b);

                    v = changeBrightnessParameter.brightness / 100.0;
                    
                    getRGBColorFromHSV(h, s, v, out r, out g, out b);

                    outputBMP.SetPixel(x, y, Color.FromArgb(r, g, b));
                    procPixel++;
                    progress = procPixel * 100 / maxProgress;
                }
            }
            ////////////////////////////////////////////////////////////////

            progress = 100;

            return outputBMP;
        }

        private double getHue(int r, int g, int b)
        {
            double retHue = -1;

            int max = (r > g) ? r : g;
            max = (max > b) ? max : b;
            int min = (r <= g) ? r : g;
            min = (min <= b) ? min : b;

            if(max == min)
            {
                retHue = 0.0;
            }
            else
            {
                retHue = max - min;
                if (max == r)
                {
                    retHue = (g - b) / (retHue * 255.0);
                    if(retHue < 0.0)
                    {
                        retHue = retHue + 1.0;
                    }
                }
                else if (max == g)
                {
                    retHue = 1 / 3 + (b - r) / (retHue * 255.0);
                }
                else
                {
                    retHue = 1 / 3 + (r - g) / (retHue * 255.0);
                }
            }

            return retHue;
        }
        
        private double getSatuation(int r, int g, int b)
        {
            double retSatuation = -1;
            
            int max = (r > g) ? r : g;
            max = (max > b) ? max : b;

            int min = (r <= g) ? r : g;
            min = (min <= b) ? min : b;

            if (max != 0)
            {
                retSatuation = (double)(max - min) / max;
            }
            else
            {
                retSatuation = (max - min) / 255.0;
            }

            return retSatuation;
        }

        private double getBrightness(int r, int g, int b)
        {
            double retBrightness = -1;

            int max = (r > g) ? r : g;
            max = (max > b) ? max : b;

            int min = (r <= g) ? r : g;
            min = (min <= b) ? min : b;

            retBrightness = max / 255.0;

            return retBrightness;
        }

        private void getRGBColorFromHSV(double h, double s, double v, out int outR, out int outG, out int outB)
        {
            double r = v;
            double g = v;
            double b = v;
            if (s > 0.0f) {
                h *= 6.0f;
                int i = (int) h;
                double f = h - (double)i;
                switch (i) {
                    default:
                    case 0:
                        g *= 1 - s * (1 - f);
                        b *= 1 - s;
                        break;
                    case 1:
                        r *= 1 - s * f;
                        b *= 1 - s;
                        break;
                    case 2:
                        r *= 1 - s;
                        b *= 1 - s * (1 - f);
                        break;
                    case 3:
                        r *= 1 - s;
                        g *= 1 - s * f;
                        break;
                    case 4:
                        r *= 1 - s * (1 - f);
                        g *= 1 - s;
                        break;
                    case 5:
                        g *= 1 - s;
                        b *= 1 - s * f;
                        break;
                }
            }

            outR = (int)(r * 255);
            outG = (int)(g * 255);
            outB = (int)(b * 255);

            return;
        }
    }
}
