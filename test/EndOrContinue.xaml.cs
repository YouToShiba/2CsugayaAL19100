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
    /// EndOrContinue.xaml の相互作用ロジック
    /// </summary>
    public partial class EndOrContinue : Page
    {
        public EndOrContinue()
        {
            InitializeComponent();
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            var Home = new Home();
            NavigationService.Navigate(Home);
        }

        private void EndButton_Click(object sender, RoutedEventArgs e)
        {
            var Result = new Result();
            NavigationService.Navigate(Result);
        }
    }
}
