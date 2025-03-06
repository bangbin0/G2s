using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace G2S
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 确保SQLite本机库被正确加载
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string x86Dir = Path.Combine(baseDir, "x86");
            
            if (!Directory.Exists(x86Dir))
            {
                Directory.CreateDirectory(x86Dir);
            }

            // 设置环境变量
            string path = Environment.GetEnvironmentVariable("PATH");
            if (!path.Contains(x86Dir))
            {
                Environment.SetEnvironmentVariable("PATH", x86Dir + ";" + path);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
