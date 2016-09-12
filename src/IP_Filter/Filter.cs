using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;
using ImageProcPlatform.Plugin;
using IP_Filter.Setting;
using IP_Filter.Parameter;

namespace IP_Filter
{
    public class Filter : IImageProcPlugin
    {
        /// <summary>
        /// 設定画面フォーム
        /// </summary>
        private Form SettingForm;

        /// <summary>
        /// 画像処理名
        /// </summary>
        public string Name { get { return "Filter"; } }

        /// <summary>
        /// 画像処理進捗
        /// </summary>
        private int _progress = 0;
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


        /// <summary>
        /// フィルター用パラメータ
        /// </summary>
        private FilterParameter FilterParam;


        /// <summary>
        /// 設定画面表示メソッド
        /// </summary>
        /// <returns></returns>
        public void Setting()
        {
            FilterParam = new FilterParameter(3);

            if (SettingForm == null)
            {
                SettingForm = new FilterSetting(FilterParam);
            }
            else if (SettingForm.IsDisposed)
            {
                SettingForm = new FilterSetting(FilterParam);
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

            outputBMP = new Bitmap(inputBMP.Width, inputBMP.Height);
            imageSize = inputBMP.Size;
            maxProgress = imageSize.Width * imageSize.Height;   //画像サイズが変わる or 進捗がピクセル数に等しくない場合はここを変更
            this.progress = procPixel * 100 / maxProgress;

            ////////////////////////////////////////////////////////////////
            // 画像処理定義                                               //
            // グレースケール変換して、フィルターを適用する
            Bitmap grayBMP;
            grayBMP = ConvertToGrayScale(inputBMP);

            outputBMP = (Bitmap)grayBMP.Clone();

            // 画像処理定義                                               //
            ////////////////////////////////////////////////////////////////

            this.progress = 100;

            return outputBMP;
        }

        //グレースケール変換
        private Bitmap ConvertToGrayScale(Bitmap bmp)
        {
            Size bmpSize = bmp.Size;
            Bitmap outBmp = (Bitmap)bmp.Clone();
            Color c, gray;
            int grayValue;
            for (int y = 0; y < bmpSize.Height; y++)
            {
                for (int x = 0; x < bmpSize.Width; x++)
                {
                    c = bmp.GetPixel(x, y);
                    grayValue = (c.R + c.G + c.B) / 3;
                    gray = Color.FromArgb(grayValue, grayValue, grayValue);
                    outBmp.SetPixel(x, y, gray);
                }
            }
            return outBmp;
        }
    }
}
