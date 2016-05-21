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
    /// TeacherWindow.xaml 的交互逻辑
    /// </summary>
    public partial class TeacherWindow : Window
    {
        private int teacher_id;
        private ServiceClient client;
        public TeacherWindow(int teacher_id)
        {
            this.teacher_id = teacher_id;
            client = new ServiceClient();
            InitializeComponent();
            initData();
        }

        private void initData()
        {
            Model.Teacher teacher = client.GetTeacherById(teacher_id);
            name.Text = teacher.name;
            sex.Text = teacher.sex;
            course.Text = teacher.course_name;
            password.Text = teacher.password;
            tel.Text = teacher.tel;

            teacher_grid.ItemsSource = client.GetMarksByTeacherId(teacher_id);
        }

        private void change_Click(object sender, RoutedEventArgs e)
        {
            Model.Teacher model = new Model.Teacher();
            model.tel = tel.Text;
            model.password = password.Text;
            model.id = teacher_id;
            if (client.UpdateTeacher(model) > 0)
            {
                MessageBox.Show("修改成功");
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }

        private void teacher_save_Click(object sender, RoutedEventArgs e)
        {
            if (teacher_grid.SelectedIndex >= 0)
            {
                Model.Mark model = (Model.Mark)teacher_grid.SelectedItem;
                if(client.UpdateMark(model)>0)
                {
                    MessageBox.Show("保存成功");
                }
                else
                {
                    MessageBox.Show("保存失败");
                }
            }
        }

        private void teacher_find_Click(object sender, RoutedEventArgs e)
        {
            teacher_grid.ItemsSource = new List<Model.Mark >(client.FindStudentMark(teacher_id,student_name.Text));
        }
    }
}
