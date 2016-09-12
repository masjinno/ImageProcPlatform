using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IP_GrayScale.Setting
{
    public partial class GrayScaleSetting : Form
    {
        public GrayScaleSetting()
        {
            InitializeComponent();
        }

        private void SettingFormCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
