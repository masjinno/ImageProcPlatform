using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace IP_BinarizeThreshold.Parameter  //RENAME
{
    public class BinarizeThresholdParameter  //RENAME
    {
        public const int THRESHOLD_INIT = 255 / 2;
        public const int THRESHOLD_MIN = 0;
        public const int THRESHOLD_MAX = 255;

        /// <summary>
        /// true:有効
        /// false:無効
        /// </summary>
        bool isEnabled;

        //画像処理に使用するパラメータを定義してください。
        private int _threshold = -1;
        public int threshold
        {
            get
            {
                return _threshold;
            }
            set
            {
                if (BinarizeThresholdParameter.THRESHOLD_MIN <= value && value <= BinarizeThresholdParameter.THRESHOLD_MAX)
                {
                    _threshold = value;
                }
                else
                {
                    MessageBox.Show(
                        "value is NG.\n" + BinarizeThresholdParameter.THRESHOLD_MIN.ToString() + " <= value <= " + BinarizeThresholdParameter.THRESHOLD_MAX.ToString(),
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    _threshold = BinarizeThresholdParameter.THRESHOLD_INIT;
                }
            }
        }

        public BinarizeThresholdParameter()
        {
            threshold = THRESHOLD_INIT;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        public void SetParameter(int th)
        {
            threshold = th;
        }
    }
}
