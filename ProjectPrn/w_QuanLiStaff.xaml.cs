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
    /// Interaction logic for w_QuanLiStaff.xaml
    /// </summary>
    public partial class w_QuanLiStaff : Window
    {
        ProjectPrn212Context context = new ProjectPrn212Context();
        public w_QuanLiStaff()
        {
            InitializeComponent();
            LoadStaff();
            LoadChucVu();
        }
        public void LoadStaff()
        {
            var listStaff= context.Staff.Where(c=>c.ChucVu!="None").Select(s=> new
            {
                staffId= s.StaffId,
                ten=s.Ten,
                chucvu=s.ChucVu,
                dienthoai=s.DienThoai,
                diachi=s.DiaChi,
                username=s.username,
                password=s.password
            }).ToList();
            dtStaff.ItemsSource = listStaff;
        }
        public void LoadChucVu()
        {
            List<String> list = new List<string>() {"Nhân viên","Quản lý","None"};
            cboFilter.ItemsSource = list;
            cboChucVu.ItemsSource= list;
            cboChucVu.SelectedIndex = 0;
        }

        private void dtStaff_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = dtStaff.SelectedItem as dynamic;
            if (selectedItem != null)
            {
                txtId.Text=selectedItem.staffId.ToString();
                txtName.Text=selectedItem.ten.ToString();
                txtDiachir.Text=selectedItem.diachi.ToString();
                if(selectedItem.chucvu.ToString()=="Nhân viên")
                {
                    cboChucVu.Text = "Nhân viên";
                }else if(selectedItem.chucvu.ToString()=="Quản lý")
                {
                    cboChucVu.Text = "Quản lý";
                }
                else
                {
                    cboChucVu.Text = "None";
                }
                txtPhone.Text=selectedItem.dienthoai.ToString();
                txtUsername.Text=selectedItem.username.ToString();
                txtPassword.Text=selectedItem.password.ToString();
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (context.Staff.FirstOrDefault(s=>s.username== txtUsername.Text)==null)
            {
                Staff sAdd = new Staff();
                sAdd.Ten = txtName.Text;
                sAdd.ChucVu = cboChucVu.Text;
                sAdd.DienThoai = txtPhone.Text;
                sAdd.DiaChi = txtDiachir.Text;
                sAdd.username = txtUsername.Text;
                sAdd.password = txtPassword.Text;
                context.Staff.Add(sAdd);
                context.SaveChanges();
                LoadStaff();
            }
            else
            {
                MessageBox.Show("Username đã tôn tại! Vui lòng tạo username mới!");
            }
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            Staff sEdit = context.Staff.FirstOrDefault(s => s.StaffId == int.Parse(txtId.Text));
            if (sEdit != null) {
                if (context.Staff.FirstOrDefault(s => s.username == txtUsername.Text) == null)
                {
                    sEdit.Ten = txtName.Text;
                    sEdit.ChucVu = cboChucVu.Text;
                    sEdit.DienThoai = txtPhone.Text;
                    sEdit.DiaChi = txtDiachir.Text;
                    sEdit.username = txtUsername.Text;
                    sEdit.password = txtPassword.Text;
                }
                else
                {
                    MessageBox.Show("Username đã tôn tại! Vui đổi username khác!");
                }
            }
            context.SaveChanges();
            LoadStaff();
        }

        private void disable_Click(object sender, RoutedEventArgs e)
        {
            Staff sEdit = context.Staff.FirstOrDefault(s => s.StaffId == int.Parse(txtId.Text));
            if (sEdit != null)
            {
                if (sEdit.ChucVu != "None")
                {
                    sEdit.ChucVu = "None";
                }
                else
                {
                    sEdit.ChucVu = "Nhân viên";
                }
            }
            context.SaveChanges();
            LoadStaff();
        }

        private void cboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                String chucVu = cboFilter.Text;

                var listStaff = context.Staff
                    .Where(c => c.ChucVu == chucVu)
                    .Select(s => new
                    {
                        staffId = s.StaffId,
                        ten = s.Ten,
                        chucvu = s.ChucVu,
                        dienthoai = s.DienThoai,
                        diachi = s.DiaChi,
                        username = s.username,
                        password = s.password
                    }).ToList();

                dtStaff.ItemsSource = listStaff;
            }));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ExportDataGridToExcel(dtStaff);
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
    }
}
