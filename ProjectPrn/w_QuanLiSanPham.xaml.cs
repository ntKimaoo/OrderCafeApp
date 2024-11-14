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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectPrn
{
    /// <summary>
    /// Interaction logic for w_QuanLiSanPham.xaml
    /// </summary>
    public partial class w_QuanLiSanPham : Window
    {
        ProjectPrn212Context context = new ProjectPrn212Context();
        public w_QuanLiSanPham()
        {
            InitializeComponent();
            Load_Product();
        }
        public void Load_Product()
        {
            var listP = context.Products.Select(p => new
            {
                productId = p.ProductId,
                name = p.TenProduct,
                gia = p.Gia,
                mota=p.MoTa,
                hinhanh=p.HinhAnh
            }).ToList();
            dtProduct.ItemsSource = listP;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.TenProduct=txtName.Text;
            product.MoTa=txtMoTa.Text;
            product.Gia=decimal.Parse(txtGia.Text);
            product.HinhAnh=txtUrlImg.Text;
            context.Products.Add(product);
            context.SaveChanges();
            Load_Product();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Product pEdit = context.Products.FirstOrDefault(p => p.ProductId == int.Parse(txtId.Text));
            if (pEdit != null) {
                pEdit.TenProduct = txtName.Text;
                pEdit.MoTa=txtMoTa.Text;
                pEdit.Gia = decimal.Parse(txtGia.Text);
                pEdit.HinhAnh= txtUrlImg.Text;
            }
            context.SaveChanges();
            Load_Product();
        }

        private void dtBan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = dtProduct.SelectedItem as dynamic;
            if (selectedItem != null) {
                txtId.Text = selectedItem.productId.ToString();
                txtName.Text = selectedItem.name.ToString();
                txtGia.Text =selectedItem.gia.ToString();
                txtMoTa.Text = selectedItem.mota.ToString();
                txtUrlImg.Text = selectedItem.hinhanh.ToString();
                imgP.Source = GetProductImageSource(selectedItem.hinhanh.ToString());
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
    }
}
