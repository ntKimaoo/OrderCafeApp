using ProjectPrn.DAL;
using ProjectPrn.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ProjectPrn
{
    public partial class w_goiMon : Window
    {
        ProjectPrn212Context context = new ProjectPrn212Context();
        Dictionary<Product, (int Quantity, decimal TotalPrice)> productSelection = new Dictionary<Product, (int Quantity, decimal TotalPrice)>();
        public w_goiMon()
        {
            InitializeComponent();
            LoadProducts();
        }
        private void LoadProducts()
        {
            List<Product> products = context.Products.ToList();
            DisplayProducts(products);
        }
        public w_goiMon(int banId,int staffId)
        {
            InitializeComponent();
            LoadProducts();
            Ban ban = context.Bans.FirstOrDefault(b=>b.BanId == banId);
            tblSoBan.Text = ban.SoBan;
            tblBanid.Text = banId.ToString();
            tblNhanvienid.Text = staffId.ToString();
            var order = context.Orders.FirstOrDefault(o => o.BanId == ban.BanId && ban.TrangThai == "Đang có khách");
            if (order != null) {
                lvChoseItem.ItemsSource = context.OrderDetails.Where(o => o.OrderId == order.OrderId).Select(od => new
                {
                    TenProduct = context.Products.FirstOrDefault(c => c.ProductId == od.ProductId).TenProduct,
                    quantity = od.SoLuong,
                    totalPrice = od.ThanhTien
                }).ToList();
                btnOrder.Content = "Xác nhận";
            }

        }
        private void DisplayProducts(List<Product> products)
        {
            // Clear existing buttons
            ProductWrapPanel.Children.Clear();
            
            foreach (var product in products)
            {
                // Tạo Button cho sản phẩm
                Button btn = new Button
                {
                    Width = 150,
                    Height = 200,
                    Margin = new Thickness(10),
                    Content = new StackPanel
                    {
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Children =
                        {
                            new Image
                            {
                                Source = GetProductImageSource(product.HinhAnh), // Đổi qua hàm để xử lý hình ảnh
                                Width = 100,
                                Height = 100,
                                HorizontalAlignment = HorizontalAlignment.Center
                            },
                            new TextBlock
                            {
                                Text = product.TenProduct,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                FontSize = 14,
                                Margin = new Thickness(0, 5, 0, 5)
                            },
                            new TextBlock
                            {
                                Text = $"{product.Gia}",
                                HorizontalAlignment = HorizontalAlignment.Center,
                                FontSize = 14,
                                Foreground = Brushes.Gray
                            }
                        }
                    },
                    ToolTip = new ToolTip
                    {
                        Content = $"{product.MoTa}",
                        FontSize = 12,
                        Padding = new Thickness(10),
                        Background = Brushes.LightYellow,
                        Foreground = Brushes.Black
                    }
                };

                btn.Click += (sender, e) =>
                {
                    if (productSelection.ContainsKey(product))
                    {
                        var currentSelection = productSelection[product];
                        productSelection[product] = (currentSelection.Quantity + 1, product.Gia * (currentSelection.Quantity + 1));
                    }
                    else
                    {
                        productSelection[product] = (1, product.Gia);
                    }
                    lvChoseItem.ItemsSource = productSelection.Select(c => new
                    {
                        TenProduct = c.Key.TenProduct,
                        quantity = c.Value.Quantity,
                        price = c.Value.TotalPrice
                    });
                };

                ProductWrapPanel.Children.Add(btn);
            }
        }
        private ImageSource GetProductImageSource(string imagePath)
        {
            try
            {
                if (!string.IsNullOrEmpty(imagePath) && Uri.IsWellFormedUriString(imagePath, UriKind.RelativeOrAbsolute))
                {
                    return new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
                }
            }
            catch (Exception)
            {
                return new BitmapImage(new Uri("pack://application:,,,/Images/default.jpg"));
            }

            return new BitmapImage(new Uri("pack://application:,,,/Images/default.jpg"));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            w_chonBan w_ChonBan = new w_chonBan(int.Parse(tblNhanvienid.Text), context.Staff.FirstOrDefault(s => s.StaffId == int.Parse(tblNhanvienid.Text)).Ten);
            w_ChonBan.Show();
            this.Close();
        }

        private void btnResetOrder_Click(object sender, RoutedEventArgs e)
        {
            productSelection.Clear();
            lvChoseItem.ItemsSource = null;
        }
        private void PlaceOrder(int banId,int staffId)
        {
            if (productSelection.Count == 0)
            {
                MessageBox.Show("No products selected for the order.");
                return;
            }
            OrderDAO orderDAO = new OrderDAO();
            if (btnOrder.Content.Equals("Order"))
            {
                Order newOrder = new Order
                {
                    BanId = banId,
                    StaffId = staffId,
                    NgayLap = DateTime.Now,
                    TongTien = 0,
                    TrangThai = "Unpaid"

                };
                var ban = context.Bans.FirstOrDefault(x => x.BanId == banId);
                if (ban != null)
                {
                    ban.TrangThai = "Đang có khách";
                }
                context.Orders.Add(newOrder);
                context.SaveChanges();
                orderDAO.AddOrder(newOrder, productSelection);

            }else if(btnOrder.Content.Equals("Xác nhận"))
            {
                var ban = context.Bans.FirstOrDefault(x => x.BanId == banId);
                Order o = context.Orders.FirstOrDefault(x => x.BanId==banId && ban.TrangThai=="Đang có khách");
                orderDAO.AddOrder(o, productSelection);
            }
        }
        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            PlaceOrder(int.Parse(tblBanid.Text), int.Parse(tblNhanvienid.Text));
            w_chonBan chonBan = new w_chonBan(int.Parse(tblNhanvienid.Text), context.Staff.FirstOrDefault(s => s.StaffId == int.Parse(tblNhanvienid.Text)).Ten);
            chonBan.Show();
            this.Close();
        }

        private void lvChoseItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
