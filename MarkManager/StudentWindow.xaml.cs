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
    /// StudentWindow.xaml 的交互逻辑
    /// </summary>
    public partial class StudentWindow : Window
    {
        private int student_id;
        private ServiceClient client;
        public StudentWindow(int student_id)
        {
            this.student_id = student_id;
            client = new ServiceClient();
            InitializeComponent();
            initData();
        }

        private void initData()
        {
            Model.Student student=client.GetStudentById(student_id);
            name.Text = student.name;
            sex.Text = student.sex;
            clazz.Text = student.clazz_name;
            password.Text = student.password;
            email.Text = student.email;

            student_grid.ItemsSource = client.GetMarksByStudentId(student_id);
            course_grid.ItemsSource = client.GetLessons(student_id);
        }

        private void change_Click(object sender, RoutedEventArgs e)
        {
            Model.Student model = new Model.Student();
            model.email = email.Text;
            model.password = password.Text;
            model.id = student_id;
            if(client.UpdateStudent(model)>0)
            {
                MessageBox.Show("修改成功");
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }

        private void course_add_Click(object sender, RoutedEventArgs e)
        {
            if(course_grid.SelectedIndex>=0)
            {
                Model.Teacher teacher = (Model.Teacher)course_grid.SelectedItem;
                if(client.AddMark(student_id, teacher.id)>0)
                {
                    MessageBox.Show("选课成功");
                    student_grid.ItemsSource = client.GetMarksByStudentId(student_id);
                    course_grid.ItemsSource = client.GetLessons(student_id);
                }
                else
                {
                    MessageBox.Show("选课失败");
                }
            }
        }

        private void student_find_Click(object sender, RoutedEventArgs e)
        {
            student_grid.ItemsSource = client.FindTeacherMark(student_id, student_name.Text);
        }

        private void course_find_Click(object sender, RoutedEventArgs e)
        {
            course_grid.ItemsSource = client.FindCourseMark(student_id, course_name.Text);
        }
    }
}
