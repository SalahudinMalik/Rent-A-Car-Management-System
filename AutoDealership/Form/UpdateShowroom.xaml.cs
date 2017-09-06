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
using System.Windows.Shapes;

namespace AutoDealership.Form
{
    /// <summary>
    /// Interaction logic for UpdateShowroom.xaml
    /// </summary>
    public partial class UpdateShowroom : Window
    {
        private int id = -1;
        public UpdateShowroom(int cid)
        {
            InitializeComponent();
            id = cid;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
