using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using System.IO;
using System.Runtime.InteropServices; //DllImport
using System.Threading.Tasks;

namespace ImageProcPlatform
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        public static extern bool AttachConsole(uint dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();


        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //if (args.Length >= 1)
            //{
            //    if (AttachConsole(System.UInt32.MaxValue))
            //    {
            //        Stream stream = Console.OpenStandardOutput();
            //        StreamWriter stdout = new StreamWriter(stream);

            //        stdout.WriteLine("\n");
            //        stdout.Flush();

            //        FreeConsole();
            //    }
            //}
            //else
            {
                Application.Run(new MainForm());
            }
        }
    }
}
