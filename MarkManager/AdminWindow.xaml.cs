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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MarkManager
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AdminWindow : Window
    {
        private ServiceClient client;

        public AdminWindow()
        {
            client = new ServiceClient();

            InitializeComponent();

            load_clazz();
        }

        private void load_clazz()
        {
            clazz_grid.ItemsSource = new List<Model.Clazz>(client.GetClazzs());
        }

        private void clazz_save_Click(object sender, RoutedEventArgs e)
        {
            if (clazz_grid.SelectedIndex>=0)
            {
                Model.Clazz model = (Model.Clazz)clazz_grid.SelectedItem;
                if (client.UpdateClazz(model) > 0)
                {
                    MessageBox.Show("更新成功");
                    load_clazz();
                }
                else
                {
                    MessageBox.Show("更新失败");
                }
            }
        }

        private void clazz_delete_Click(object sender, RoutedEventArgs e)
        {
            if(clazz_grid.SelectedIndex>=0)
            {
                if(client.DeleteClazz(((Model.Clazz)clazz_grid.SelectedItem).id)>0)
                {
                    MessageBox.Show("删除成功");
                    load_clazz();
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
        }

        private void clazz_find_Click(object sender, RoutedEventArgs e)
        {
            clazz_grid.ItemsSource = new List<Model.Clazz>(client.FindClazz(clazz_name.Text));
        }
    }
}
