using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using IP_BinarizeThreshold.Parameter;

namespace IP_BinarizeThreshold.Setting    //RENAME
{
    public partial class BinarizeThresholdSetting : Form  //RENAME
    {
        //パラメータ
        static BinarizeThresholdParameter binarizeThresholdParam;


        public BinarizeThresholdSetting(ref BinarizeThresholdParameter binThParam) //RENAME
        {
            InitializeComponent();

            //パラメータインスタンス生成
            binarizeThresholdParam = binThParam;
            ThresholdTextBox.Text = binarizeThresholdParam.threshold.ToString();
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            //パラメータ更新処理
            int th;
            if (Int32.TryParse(ThresholdTextBox.Text, out th))
            {
                binarizeThresholdParam.threshold = th;
                MessageBox.Show(
                    "update OK.",
                    "OK",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Input value.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            //設定Formをクローズするだけ。値は更新しない。
            this.Close();
        }
    }
}
