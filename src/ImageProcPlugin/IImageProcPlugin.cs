using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;


namespace ImageProcPlatform.Plugin
{
    public interface IImageProcPlugin
    {
        /// <summary>
        /// 画像処理名
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 画像処理進捗(単位：％)
        /// 処理中定義域 [0,100)
        /// 処理後定義域 100以上
        /// 異常値定義域 負数
        /// </summary>
        int progress { get; }

        /// <summary>
        /// 設定画面表示メソッド
        /// </summary>
        /// <returns>true:設定 false:キャンセル</returns>
        void Setting();

        /// <summary>
        /// 画像処理
        /// </summary>
        /// <param name="inputBMP">入力BMP画像</param>
        /// <returns>画像処理結果</returns>
        Bitmap ProcImage(Bitmap inputBMP);
    }
}
