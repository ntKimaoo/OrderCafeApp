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
    /// Interaction logic for w_ChiTietHoaDon.xaml
    /// </summary>
    public partial class w_ChiTietHoaDon : Window
    {
        ProjectPrn212Context context=new ProjectPrn212Context();
        public w_ChiTietHoaDon()
        {
            InitializeComponent();
        }
        public w_ChiTietHoaDon(int orderid)
        {
            InitializeComponent();
            var listOrder = context.OrderDetails.Where(o=>o.OrderId == orderid).Select(o => new
            {
                TenProduct=context.Products.FirstOrDefault(p=> p.ProductId==o.ProductId).TenProduct,
                quantity=o.SoLuong,
                price=o.DonGia,
                thanhTien=o.ThanhTien
            }).ToList();
            lvChiTietHoaDon.ItemsSource = listOrder;
        }
    }
}
