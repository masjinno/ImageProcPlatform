using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Reflection;
using System.Drawing;
using System.Collections.ObjectModel;
using ImageProcPlatform.Plugin;

//using System.Windows.Forms; //デバッグのMessageBox用

//statusは見直し必要

namespace ImageProcPlatform
{
    class ImageProc
    {
        /// <summary>
        /// プラグインDLLを配置するディレクトリ名
        /// </summary>
        const string pluginDirName = "Plugin";

        /// <summary>
        /// ロードしたプラグイン
        /// </summary>
        public List<IImageProcPlugin> IP_PluginList;

        /// <summary>
        /// ステータス文字列一覧
        /// </summary>
        ReadOnlyCollection<string> StatusMessage = Array.AsReadOnly(new string[] {
            "画像処理待機中",
            "画像処理実行中",
            "画像処理設定中",
            "画像処理クラス初期化失敗",
            "該当画像処理プラグインなし",
            "画像処理設定エラー",
            "画像処理進捗取得失敗"
        });

        /// <summary>
        /// ステータス番号
        /// </summary>
        private enum EStatus
        {
            IP_WAITING = 0,
            IP_EXECUTING,
            IP_SETTING,
            IP_FAILED_INITIALIZE,
            IP_FAILED_NO_PLUGIN,
            IP_FAILED_SETTING,
            IP_FAILED_GET_PROGRESS
        };

        /// <summary>
        /// ステータス
        /// </summary>
        public string status { get; private set; }


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="path"></param>
        public ImageProc(string path)
        {
            if (InitIPPlugin(path))
            {
                status = StatusMessage[(int)EStatus.IP_WAITING];
            }
            else
            {
                status = StatusMessage[(int)EStatus.IP_FAILED_INITIALIZE];
            }
        }

        /// <summary>
        /// プラグイン初期化
        /// </summary>
        /// <param name="path">dllを配置しているディレクトリパス</param>
        /// <returns></returns>
        private bool InitIPPlugin(string path)
        {
            bool ret = true;

            IP_PluginList = new List<IImageProcPlugin>();

            foreach (string dllPath in Directory.GetFiles(Path.Combine(path, pluginDirName), "*.dll"))
            {
                //MessageBox.Show(@dllPath);

                Assembly assembly = Assembly.LoadFrom(dllPath);
                if (assembly == null)
                {
                    goto Error;
                }

                foreach (Type type in assembly.GetTypes())
                {
                    //非クラス型，非パブリック型，抽象クラスはスキップ
                    if (!type.IsClass || !type.IsPublic || type.IsAbstract)
                    {
                        continue;
                    }

                    //型に実装されているインターフェイスからIImageProcPluginを取得
                    Type t = type.GetInterfaces().FirstOrDefault((_t) => _t == typeof(IImageProcPlugin));
                    //if (t == null)
                    //{
                    //    goto Error;
                    //}

                    //default(IImageProcPlugin)と等しい場合は未実装なのでスキップ
                    if (t == default(IImageProcPlugin))
                    {
                        continue;
                    }

                    //取得した型のインスタンスを作成
                    object obj = Activator.CreateInstance(type);
                    IP_PluginList.Add((IImageProcPlugin)obj);
                }

                //foreach (IImageProcPlugin ip in IP_PluginList)
                //{
                //    MessageBox.Show("name is " + ip.Name);
                //}
            }

            return ret;

        Error:
            ret = false;
            return ret;
        }

        /// <summary>
        /// ロードしたdllのプラグイン名の配列を返す
        /// </summary>
        /// <returns>プラグイン名配列</returns>
        public string[] GetPluginName()
        {
            string[] retNames = new string[IP_PluginList.Count];

            for (int i = 0; i < IP_PluginList.Count; i++)
            {
                retNames[i] = IP_PluginList[i].Name;
            }

            //status = StatusName[0];

            return retNames;
        }

        /// <summary>
        /// 設定画面表示
        /// </summary>
        /// <param name="ipName">選択中画処理名</param>
        public bool SettingIP(string ipName)
        {
            bool find = false;
            foreach (IImageProcPlugin ip in IP_PluginList)
            {
                if (ip.Name == ipName)
                {
                    status = StatusMessage[(int)EStatus.IP_SETTING];
                    ip.Setting();
                    find = true;
                }
            }

            if (find)
            {
                status = StatusMessage[(int)EStatus.IP_WAITING];
            }
            else
            {
                status = StatusMessage[(int)EStatus.IP_FAILED_SETTING];
            }

            return find;
        }

        /// <summary>
        /// 画像処理実行
        /// </summary>
        /// <param name="ipName">選択中画処理名</param>
        public Bitmap ExecIP(string ipName, Bitmap inBMP)
        {
            Bitmap retBmp = new Bitmap(inBMP);
            bool find = false;

            status = StatusMessage[(int)EStatus.IP_EXECUTING];

            foreach (IImageProcPlugin ip in IP_PluginList)
            {
                if (ip.Name == ipName)
                {
                    retBmp = ip.ProcImage(inBMP);
                    find = true;
                }
            }

            if (find)
            {
                status = StatusMessage[(int)EStatus.IP_WAITING];
            }
            else
            {
                status = StatusMessage[(int)EStatus.IP_FAILED_NO_PLUGIN];
            }

            return retBmp;
        }

        /// <summary>
        /// 画像処理進捗を取得する
        /// 画像処理中以外には呼ばれないことを想定する
        /// </summary>
        /// <param name="ipName">対象画像処理名</param>
        /// <param name="progress">進捗</param>
        /// <returns></returns>
        public bool GetProgress(string ipName, out int progress)
        {
            bool find = false;
            bool ret;
            progress = -1;

            foreach (IImageProcPlugin ip in IP_PluginList)
            {
                if (ip.Name == ipName)
                {
                    progress = ip.progress;
                    find = true;
                }
            }

            if (!find)
            {
                //対象画像処理がない場合
                ret = false;
                progress = -1;
                status = StatusMessage[(int)EStatus.IP_FAILED_NO_PLUGIN];
                goto Finish;
            }
            else if (progress < 0)
            {
                //異常値だった場合
                ret = false;
                status = StatusMessage[(int)EStatus.IP_FAILED_GET_PROGRESS];
                goto Finish;
            }
            else if (100 <= progress)
            {
                //処理終了後
                ret = true;
                status = StatusMessage[(int)EStatus.IP_WAITING];
                goto Finish;
            }
            else
            {
                //正常ケース
                ret = true;
                status = StatusMessage[(int)EStatus.IP_EXECUTING];
            }

        Finish:
            return ret;
        }

        /// <summary>
        /// コマンドライン実行時に呼び出す関数
        /// コマンド引数仕様などもこのクラスが管理する
        /// </summary>
        /// <param name="commandLine">コマンドライン引数</param>
        /// <returns>true:コマンド実行成功 false:コマンド実行失敗</returns>
        public bool ExecCommand(string[] commandLine)
        {
            bool ret = true;

            foreach (string arg in commandLine)
            {
                //Console.WriteLine(arg);
            }

            return ret;
        }
    }
}
