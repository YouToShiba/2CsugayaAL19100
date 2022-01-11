using System;
using System.IO;
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

namespace test
{
    /// <summary>
    /// RestHome.xaml の相互作用ロジック
    /// </summary>
    public partial class RestHome : Page
    {
        public RestHome()
        {
            InitializeComponent();
            // min.txtとstart.txtの初期化
            File.WriteAllText(@"min.txt", "1000000");
            using (var fileStream = new FileStream("./start.txt", FileMode.Open))
            {
                fileStream.SetLength(0);
            }
            using (var fileStream = new FileStream("./title.txt", FileMode.Open))
            {
                fileStream.SetLength(0);
            }
            using (var fileStream = new FileStream("./result.txt", FileMode.Open))
            {
                fileStream.SetLength(0);
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            var RestMeasurement = new RestMeasurement();
            NavigationService.Navigate(RestMeasurement);
        }
    }
}
