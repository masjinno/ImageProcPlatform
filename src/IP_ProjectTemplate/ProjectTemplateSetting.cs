using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IP_ProjectTemplate.Setting    //RENAME
{
    public partial class ProjectTemplateSetting : Form  //RENAME
    {
        //パラメータ
        //TODO:宣言

        public ProjectTemplateSetting() //RENAME
        {
            InitializeComponent();

            //パラメータインスタンス生成
            //TODO:生成
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
    }
}
