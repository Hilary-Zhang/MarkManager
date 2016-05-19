using MarkManager;
using MarkManager.ServiceReference;
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

namespace MarkManager
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        private ServiceClient client;

        public LoginWindow()
        {
            InitializeComponent();
            client = new ServiceClient();
        }

        private void command_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            if(username.Text.Length==0)
            {
                MessageBox.Show("请填写用户名");
                return;
            }
            if (password.Text.Length == 0)
            {
                MessageBox.Show("请填写密码");
                return;
            }
            if (type.SelectedIndex<0)
            {
                MessageBox.Show("请选择类型");
                return;
            }
            id = client.Login(username.Text, password.Text, (short)type.SelectedIndex);
            if(id==0)
            {
                MessageBox.Show("用户名或密码错误");
                return;
            }
            switch(type.SelectedIndex)
            {
                case 0:
                    new StudentWindow(id).Show();
                    Close();
                    break;
                case 1:
                    new TeacherWindow(id).Show();
                    Close();
                    break;
                case 2:
                    new AdminWindow().Show();
                    Close();
                    break;
            }
        }
    }
}
