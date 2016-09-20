using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IP_ProjectTemplate.Parameter
{
    class ProjectTemplateParameter  //RENAME
    {
        /// <summary>
        /// 画像処理に使用するパラメータ
        /// </summary>
        public struct parameter
        {
            /// <summary>
            /// true:有効
            /// false:無効
            /// </summary>
            bool isEnabled;

            //画像処理に使用するパラメータを定義してください。


        };

        /// <summary>
        /// パラメータのインスタンス
        /// </summary>
        public parameter _param;
        public parameter param
        {
            get
            {
                return _param;
            }
            set
            {
                //バリデーションがあれば記述すること
                this._param = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        public void SetParameter(parameter input)
        {

        }
    }
}
