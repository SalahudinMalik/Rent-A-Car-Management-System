using CarDALEF;
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
using ViewModel;

namespace AutoDealership.Form
{
    /// <summary>
    /// Interaction logic for DeleteShowroom.xaml
    /// </summary>
    public partial class DeleteShowroom : Window
    {
        public DeleteShowroom()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowRFactory Fobj = new ShowRFactory();
            List<ShowRModelView> list = Fobj.GetAll();
            cbSR.ItemsSource = list;
            cbSR.DisplayMemberPath = "ShowRName";
            cbSR.SelectedValuePath = "S_ID";

        }
        int rid ()
        {
            int id = int.Parse(cbSR.SelectedValue.ToString());
            return id;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            ShowRFactory fobj = new ShowRFactory();
            bool rC, rS;
            rS = fobj.DeleteS(rid());
            rC = fobj.DeleteC(rid());
            if (rS && rC)
            {
                MessageBox.Show("Showroom is Deleted", "Deleted");
                this.Close();
            }
            else
                MessageBox.Show("Showroom is not Deleted", "Error!");
            
        }
    }
}
