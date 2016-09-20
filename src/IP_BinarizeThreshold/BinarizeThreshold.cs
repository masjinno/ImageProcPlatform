﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;
using ImageProcPlatform.Plugin;
using IP_BinarizeThreshold.Setting;
using IP_BinarizeThreshold.Parameter;

namespace IP_BinarizeThreshold
{
    public class BinarizeThreshold : IImageProcPlugin
    {
        /// <summary>
        /// 設定画面フォーム
        /// </summary>
        private static Form SettingForm;

        /// <summary>
        /// 画像処理名
        /// </summary>
        public string Name { get { return "BinarizeThreshold"; } }    //RENAME

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

            set
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


        BinarizeThresholdParameter binarizeThresholdParameter;


        /// <summary>
        /// 設定画面表示メソッド
        /// </summary>
        /// <returns></returns>
        public void Setting()
        {
            binarizeThresholdParameter = new BinarizeThresholdParameter();
            if (SettingForm == null || SettingForm.IsDisposed)
            {
                SettingForm = new BinarizeThresholdSetting(ref binarizeThresholdParameter); //RENAME
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
            for (int y = 0; y < imageSize.Height; y++)
            {
                for (int x = 0; x < imageSize.Width; x++)
                {
                    Color c = inputBMP.GetPixel(x, y);
                    int grayValue = (c.R + c.G + c.B) / 3;

                    if (grayValue < binarizeThresholdParameter.threshold)
                    {
                        outputBMP.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        outputBMP.SetPixel(x, y, Color.White);
                    }

                    procPixel++;
                    progress = procPixel * 100 / maxProgress;
                }
            }
            ////////////////////////////////////////////////////////////////

            progress = 100;

            return outputBMP;
        }

    }
}
