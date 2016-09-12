using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using IP_Filter.Parameter;

namespace IP_Filter.Setting
{
    public partial class FilterSetting : Form
    {
        //パラメータ
        private FilterParameter originalFP;
        private FilterParameter changedFP;

        public FilterSetting(FilterParameter fp)
        {
            InitializeComponent();

            this.originalFP = fp;
            changedFP = new FilterParameter(originalFP.FilterSize);
            changedFP.FilterArray = originalFP.FilterArray;

            Filter_DataGridView.RowCount = originalFP.FilterSize;
            Filter_DataGridView.ColumnCount = originalFP.FilterSize;
            for (int h = 0; h < originalFP.FilterSize; h++)
            {
                for (int w = 0; w < originalFP.FilterSize; w++)
                {
                    Filter_DataGridView[w, h].Value = originalFP.FilterArray[w, h].ToString();
                }
            }
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            //パラメータ更新処理
            //TODO:パラメータ更新処理

            this.Close();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            //設定Formをクローズするだけ。値は更新しない。
            this.Close();
        }

        private void FilterSize_NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Filter_DataGridView.RowCount = (int)FilterSize_NumericUpDown.Value;
            Filter_DataGridView.ColumnCount = (int)FilterSize_NumericUpDown.Value;
            
        }
    }
}
