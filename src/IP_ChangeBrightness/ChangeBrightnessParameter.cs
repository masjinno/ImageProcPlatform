using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace IP_ChangeBrightness.Parameter
{
    public class ChangeBrightnessParameter  //RENAME
    {
        /// <summary>
        /// true:有効
        /// false:無効
        /// </summary>
        bool isEnabled;

        //画像処理に使用するパラメータを定義してください。

        /// <summary>
        /// 設定明度 0～100とする
        /// </summary>
        const int BRIGHTNESS_MAX = 100;
        const int BRIGHTNESS_MIN = 0;
        int _brightness = 50;
        public int brightness
        {
            get
            {
                return _brightness;
            }
            private set
            {
                if (BRIGHTNESS_MIN <= value && value <= BRIGHTNESS_MAX)
                {
                    _brightness = value;
                }
                else
                {
                    MessageBox.Show(
                        "value is NG.\n" + BRIGHTNESS_MIN.ToString() + " <= value <= " + BRIGHTNESS_MAX.ToString(),
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
            }
        }

        public ChangeBrightnessParameter(int br)
        {
            brightness = br;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        public void SetParameter(int br)
        {

        }
    }
}
