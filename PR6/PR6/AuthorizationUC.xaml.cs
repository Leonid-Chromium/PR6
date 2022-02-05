using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PR6
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationUC.xaml
    /// </summary>
    public partial class AuthorizationUC : UserControl
    {
        public AuthorizationUC()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            string hash = Hashing.GetMD5Hash(passwordTB.Text);
            Trace.WriteLine(hash + " " + hash.Length);
            DataTable dataTable = SQLClass.ReturnDT("SELECT MyPassword FROM MyUser WHERE MyLogin = '" + loginTB.Text + "'");
            for(int i = 0; i < dataTable.Rows.Count; i++)
                if (dataTable.Rows[i].ItemArray[0].ToString() == hash)
                    MessageBox.Show("Salam");
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            string hash = Hashing.GetMD5Hash(passwordTB.Text);
            Trace.WriteLine(hash + " " + hash.Length);
            int check = SQLClass.NoReturn("INSERT INTO MyUser(MyLogin, MyPassword) VALUES ('" + loginTB.Text + "', '" + hash + "')");
            if (check == 0)
                MessageBox.Show("Принимаем в семью");
        }
    }
}
