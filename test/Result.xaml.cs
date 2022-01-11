using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.IO;

namespace test
{
    /// <summary>
    /// Result.xaml の相互作用ロジック .NET Framework 4.8
    /// </summary>
    public partial class Result : Page
    {
        public Result()
        {
            InitializeComponent();

            try
            {
                // テキストファイル出力（追記出力）
                for (int i = 1; i < Data.Count; i++)
                {
                    File.AppendAllText(@"./title.txt", Data.Title[i] + Environment.NewLine);
                }
            }
            // 例外処理
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            // startとfinishの値からt検定に用いる要素数を計算
            // Result result = new Result();
            string myPythonApp = "ElementCount.py";
            for (int i = 0; i < Data.Count; i++)
            {
                string start = Data.Start[i];
                string finish = Data.Finish[i];
                string arguments = myPythonApp + " " + start + " " + finish;  
                Result.StartProcess(arguments);
            }
            // pNNxの計算
            myPythonApp = "pNNx.py";
            Result.StartProcess(myPythonApp);

            // 結果表示
            // File.AppendAllText(@"result.txt", "1\n2");
            var temp = "";
            foreach (string line in System.IO.File.ReadLines(@"result.txt"))
            {
                temp += Data.Title[Int32.Parse(line)] + "\n";
            }
            this.DataContext = new { X = temp };
        }

        private static void StartProcess(string arguments)
        {
            var myProcess = new Process
            {
                StartInfo = new ProcessStartInfo("python.exe")
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    Arguments = arguments,
                    CreateNoWindow = true,
                }
            };
            myProcess.Start();
            myProcess.WaitForExit();
            myProcess.Close();
        }
    }
}
