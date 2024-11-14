using ProjectPrn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectPrn
{
    /// <summary>
    /// Interaction logic for w_QuanLiBan.xaml
    /// </summary>
    public partial class w_QuanLiBan : Window
    {   
        ProjectPrn212Context context = new ProjectPrn212Context();
        public w_QuanLiBan()
        {
            InitializeComponent();
            Load_Ban();
            Load_Cbo();
        }

        public void Load_Ban()
        {
            var bans = context.Bans.Select(b => new
            {
                banId= b.BanId,
                SoBan = b.SoBan,
                TrangThai = b.TrangThai
            }).ToList();
            dtBan.ItemsSource= bans;
        }
        public void Load_Cbo()
        {
            List<String> trangThai = new List<string>() {"Trống", "Đang có khách" };
            cboStatus.ItemsSource= trangThai;
            cboStatus.SelectedIndex=0;
        }
        private void dtBan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = dtBan.SelectedItem as dynamic;
            if (selectedItem != null) { 
                txtId.Text = selectedItem.banId.ToString();
                txtSoBan.Text = selectedItem.SoBan.ToString();
                if (selectedItem.TrangThai.ToString() == "Trống")
                {
                    cboStatus.Text = "Trống";
                }
                else
                {
                    cboStatus.Text = "Đang có khách";
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Ban ban = new Ban();
            ban.SoBan=txtSoBan.Text;
            ban.TrangThai=cboStatus.Text;
            context.Bans.Add(ban);
            context.SaveChanges();
            Load_Ban();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Ban banEdit = context.Bans.FirstOrDefault(b=>b.BanId==int.Parse(txtId.Text));
            if (banEdit != null) { 
                banEdit.SoBan = txtSoBan.Text;
                banEdit.TrangThai= cboStatus.Text;
            }
            context.SaveChanges();
            Load_Ban();
        }
    }
}
