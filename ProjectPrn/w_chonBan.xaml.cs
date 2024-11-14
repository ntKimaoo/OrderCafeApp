using ProjectPrn.DAL;
using ProjectPrn.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for w_chonBan.xaml
    /// </summary>
    public partial class w_chonBan : Window
    {
        public int? SelectedBanId { get; set; }
        public int? SelectedOrderId { get; set; }
        ProjectPrn212Context context = new ProjectPrn212Context();
        public w_chonBan()
        {
            InitializeComponent();
            LoadTables();
        }
        public w_chonBan(int id, String user)
        {
            InitializeComponent();
            LoadTables();
            tblId.Text = id.ToString();
            tblName.Text = user.ToString();
        }
        private void LoadTables()
        {
            List<Ban> banList = context.Bans.ToList();
            DisplayTables(banList);

        }
        private void TableButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Ban selectedBan = btn.Tag as Ban;

            if (selectedBan != null && selectedBan.TrangThai == "Trống")
            {
                
                w_goiMon goiMon = new w_goiMon(selectedBan.BanId, int.Parse(tblId.Text));
                goiMon.Show();
                this.Close();
            }
            else if (selectedBan != null && selectedBan.TrangThai == "Đang có khách")
            {
                decimal? sum = 0;
                var order = context.Orders.FirstOrDefault(o => o.BanId == selectedBan.BanId && selectedBan.TrangThai== "Đang có khách");
                List<OrderDetail> ordetail = context.OrderDetails.Where(c=>c.OrderId==order.OrderId).ToList();
                foreach (var item in ordetail)
                {
                    sum += item.ThanhTien;
                }
                SelectedBanId=selectedBan.BanId;
                SelectedOrderId = order.OrderId;
                tongTien.Text = sum.ToString();
                if (order != null)
                {
                    lvListItem.ItemsSource = null;
                    lvListItem.ItemsSource = context.OrderDetails.Where(o => o.OrderId == order.OrderId).Select(od => new
                    {
                        TenProduct = context.Products.FirstOrDefault(c => c.ProductId == od.ProductId).TenProduct,
                        quantity = od.SoLuong,
                        price = od.ThanhTien
                    }).ToList();
                    MessageBoxResult result = MessageBox.Show("Order thêm đồ?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        w_goiMon goiMon = new w_goiMon(selectedBan.BanId, int.Parse(tblId.Text));
                        goiMon.Show();
                        this.Close();
                    }
                }
            }
        }
        private void DisplayTables(List<Ban> banList)
        {
            GridTable.Children.Clear();

            int row = 0;
            int col = 0;

            foreach (var ban in banList)
            {
                Button btn = new Button
                {
                    Content = ban.SoBan,
                    FontSize = 20,
                    Width = 160,
                    Height = 150,
                    Tag = ban
                };
                switch (ban.TrangThai)
                {
                    case "Trống":
                        btn.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Green);
                        break;
                    case "Đang có khách":
                        btn.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Yellow);
                        break;
                    default:
                        btn.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Gray);
                        break;
                }

                btn.Click += TableButton_Click;
                Grid.SetRow(btn, row);
                Grid.SetColumn(btn, col);
                GridTable.Children.Add(btn);
                col++;
                if (col >= 5)
                {
                    col = 0;
                    row++;
                }
            }
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            w_login w_Login = new w_login();
            w_Login.Show();
            this.Close();
        }

        private void btnThanhToan_Click(object sender, RoutedEventArgs e)
        {
            Ban ban = context.Bans.FirstOrDefault(b=>b.BanId==SelectedBanId);
            Order order = context.Orders.FirstOrDefault(o=>o.OrderId==SelectedOrderId);
            if (order != null && ban!=null) {
                ban.TrangThai = "Trống";
                order.TrangThai = "Paid";
                order.TongTien = decimal.Parse(tongTien.Text);
                tongTien.Text = "0";
                lvListItem.ItemsSource = null;
                context.SaveChanges();
            }
            LoadTables();
        }

        private void lvListItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
