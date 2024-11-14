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
using Microsoft.Win32;
using Excel = Microsoft.Office.Interop.Excel;

namespace ProjectPrn
{
    /// <summary>
    /// Interaction logic for w_QuanliHoaDon.xaml
    /// </summary>
    public partial class w_QuanliHoaDon : Window
    {
        ProjectPrn212Context context = new ProjectPrn212Context();
        public w_QuanliHoaDon()
        {
            InitializeComponent();
            load_Order();
            load_cbo();
        }
        public void load_Order()
        {
            var listOrder = context.Orders.Select(o => new
            {
                orderid=o.OrderId,
                soban=context.Bans.FirstOrDefault(b=>b.BanId==o.BanId).SoBan,
                staff=context.Staff.FirstOrDefault(s=>s.StaffId==o.StaffId).Ten,
                ngaylap=o.NgayLap,
                tongtien=o.TongTien,
                trangthai=o.TrangThai
            }).ToList();
            dtBan.ItemsSource= listOrder;
        }
        public void load_cbo()
        {
            List<String> cbo = new List<string>() { "Paid", "Unpaid" };
            cboTrangthai.ItemsSource= cbo;
        }

        private void dtBan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = dtBan.SelectedItem as dynamic;
            if (selectedItem != null) { 
                txtId.Text = selectedItem.orderid.ToString();
                txtSoBan.Text=selectedItem.soban.ToString();
                txtNhanVien.Text=selectedItem.staff.ToString();
                txtNgayLap.Text=selectedItem.ngaylap.ToString();
                txtThanhTien.Text=selectedItem.tongtien.ToString();
                cboTrangthai.Text=selectedItem.trangthai.ToString();
            }
        }

        private void btnViewDetail_Click(object sender, RoutedEventArgs e)
        {
            Order order=context.Orders.FirstOrDefault(o=>o.OrderId==int.Parse(txtId.Text));
            w_ChiTietHoaDon chiTietHoaDon = new w_ChiTietHoaDon(order.OrderId);
            chiTietHoaDon.Show();
        }
        public void ExportDataGridToExcel(DataGrid dataGrid)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveFileDialog.DefaultExt = "xlsx";
            saveFileDialog.FileName = "ExportedData";

            bool? result = saveFileDialog.ShowDialog();
            if (result != true)
            {
                return;
            }

            string filePath = saveFileDialog.FileName;

            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = false;

            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.Sheets[1];

            for (int i = 0; i < dataGrid.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1] = dataGrid.Columns[i].Header;
            }

            for (int i = 0; i < dataGrid.Items.Count; i++)
            {
                for (int j = 0; j < dataGrid.Columns.Count; j++)
                {
                    var cell = dataGrid.Columns[j].GetCellContent(dataGrid.Items[i]) as TextBlock;
                    worksheet.Cells[i + 2, j + 1] = cell?.Text ?? string.Empty;
                }
            }

            workbook.SaveAs(filePath);
            workbook.Close();
            excelApp.Quit();

            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            MessageBox.Show("Data successfully exported to Excel!", "Export Complete", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnExportExcel_Click(object sender, RoutedEventArgs e)
        {
            ExportDataGridToExcel(dtBan);
        }
    }
}

