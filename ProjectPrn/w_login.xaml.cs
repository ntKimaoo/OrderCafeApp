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
    /// Interaction logic for w_login.xaml
    /// </summary>
    public partial class w_login : Window
    {
        ProjectPrn212Context context = new ProjectPrn212Context();
        public w_login()
        {
            InitializeComponent();
        }

        private void btnDangnhap_Click(object sender, RoutedEventArgs e)
        {
            string enteredUsername = txtUsername.Text;
            string enteredPassword = txtPassword.Password;
            var user = context.Staff
        .Where(s => s.username == enteredUsername && s.password == enteredPassword)
        .Select(s => new
        {
            staffid=s.StaffId,
            name=s.Ten,
            username = s.username,
            password = s.password,
            ChucVu=s.ChucVu
        })
        .FirstOrDefault();
       
            if (user != null)
            {
                if (user.ChucVu != null) { 
                    if(user.ChucVu.Equals("Nhân viên"))
                    {
                        w_chonBan w_ChonBan = new w_chonBan(user.staffid,user.name);
                        w_ChonBan.Show();
                        this.Close();
                    }
                    else
                    {
                        w_dashboard w = new w_dashboard();
                        w.Show();
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }
    }
}
