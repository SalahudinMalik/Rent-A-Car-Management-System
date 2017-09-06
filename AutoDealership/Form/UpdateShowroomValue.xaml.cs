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
    /// Interaction logic for UpdateShowroomValue.xaml
    /// </summary>
    public partial class UpdateShowroomValue : Window
    {
        public UpdateShowroomValue()
        {
            InitializeComponent();
        }

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    ShowRFactory Fobj = new ShowRFactory();
        //    List<ShowRModelView> list = Fobj.GetAll();
        //    cbSR.ItemsSource = list;
        //    cbSR.DisplayMemberPath = "ShowRName";
        //    cbSR.SelectedValuePath = "S_ID";
        //}
        //int rid()
        //{
        //    int id = int.Parse(cbSR.SelectedValue.ToString());
        //    return id;
        //}
        //private void btnNext_Click(object sender, RoutedEventArgs e)
        //{
        //    UpdateShowroom obj = new UpdateShowroom(rid());
        //    obj.ShowDialog();
        //}
    }
}
