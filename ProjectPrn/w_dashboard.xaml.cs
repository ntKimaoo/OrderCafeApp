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

namespace ProjectPrn
{
    /// <summary>
    /// Interaction logic for w_dashboard.xaml
    /// </summary>
    public partial class w_dashboard : Window
    {
        public w_dashboard()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            w_login w_Login = new w_login();
            w_Login.Show();
            this.Close();
        }

        private void btnOrderMana_Click(object sender, RoutedEventArgs e)
        {
            w_QuanliHoaDon wQuanLiOrder = new w_QuanliHoaDon();
            wQuanLiOrder.Show();
        }

        private void btnItemMana_Click(object sender, RoutedEventArgs e)
        {
            w_QuanLiSanPham wQuanLiSanPham = new w_QuanLiSanPham();
            wQuanLiSanPham.Show();
        }

        private void btnBanMana_Click(object sender, RoutedEventArgs e)
        {
            w_QuanLiBan wQuanLiBan = new w_QuanLiBan();
            wQuanLiBan.Show();
        }

        private void btnStaffMana_Click(object sender, RoutedEventArgs e)
        {
            w_QuanLiStaff wQuanLiStaff = new w_QuanLiStaff();
            wQuanLiStaff.Show(); 
        }
    }
}
