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

namespace test
{
    /// <summary>
    /// Measurement.xaml の相互作用ロジック
    /// </summary>
    public partial class Measurement : Page
    {
        public Measurement()
        {
            DateTime dt = DateTime.Now;
            Data.Start[Data.Count] = dt.ToString("HH:mm:ss");
            InitializeComponent();
        }

        private void EndMeasurement_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            string temp = dt.ToString("HH:mm:ss");
            Data.Finish[Data.Count] = temp;
            Data.Count += 1;
            if (Data.Count == 11)
            {
                var Result = new Result();
                NavigationService.Navigate(Result);
            } 
            else
            {
                var EndOrContinue = new EndOrContinue();
                NavigationService.Navigate(EndOrContinue);
            }
        }
    }
}
