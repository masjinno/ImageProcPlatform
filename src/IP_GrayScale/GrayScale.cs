using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;
using ImageProcPlatform.Plugin;
using IP_GrayScale.Setting;

namespace IP_GrayScale
{
    public class GrayScale : IImageProcPlugin
    {
        //設定画面フォーム
        private Form SettingForm;

        //画像処理名
        public string Name { get { return "GrayScale"; } }

        //画像処理進捗
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

        //設定画面表示メソッド
        public void Setting()
        {
            if (SettingForm == null)
            {
                SettingForm = new GrayScaleSetting();
            }
            else if (SettingForm.IsDisposed)
            {
                SettingForm = new GrayScaleSetting();
            }

            SettingForm.Show();
            return;
        }

        //画像処理
        public Bitmap ProcImage(Bitmap inputBMP)
        {
            Bitmap outputBMP;
            Size imageSize;
            int maxProgress;
            int procPixel = 0;

            outputBMP = (Bitmap)inputBMP.Clone();
            imageSize = inputBMP.Size;
            maxProgress = imageSize.Width * imageSize.Height;
            
            for (int y = 0; y < imageSize.Height; y++)
            {
                for (int x = 0; x < imageSize.Width; x++)
                {
                    Byte inR, inG, inB, aveRGB;
                    Color gray;

                    inR = inputBMP.GetPixel(x, y).R;
                    inG = inputBMP.GetPixel(x, y).G;
                    inB = inputBMP.GetPixel(x, y).B;
                    aveRGB = (Byte)(((int)inR + (int)inG + (int)inB) / 3);
                    gray = Color.FromArgb(aveRGB, aveRGB, aveRGB);

                    outputBMP.SetPixel(x, y, gray);

                    procPixel++;
                    progress = procPixel * 100 / maxProgress;
                }
            }

            return outputBMP;
        }

    }
}
