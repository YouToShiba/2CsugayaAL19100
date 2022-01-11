using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    // 入力タイトルを保持するクラス
    internal class Data
    {
        public static string[] Title 
        {
            get; set;
        } = new string[11];

        public static string[] Start
        {
            get; set;
        } = new string[11];

        public static string[] Finish
        {
            get; set;
        } = new string[11];

        public static int Count
        {
            get; set;
        } = 0;
    }
}
