using MarkManager.ServiceReference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<String> _sex = new ObservableCollection<string>();

        public AdminWindow()
        {
            client = new ServiceClient();

            _sex.Add("男");
            _sex.Add("女");

            InitializeComponent();
            load_student();
            load_teacher();
            load_clazz();
            load_course();
        }

        public ObservableCollection<String> sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        #region 学生管理窗口逻辑
        private  void load_student()
        {
            Model.Student[] students = client.GetStudents();
            student_grid.ItemsSource = new List<Model.Student>(students);
        }

        private void student_save_Click(object sender, RoutedEventArgs e)
        {
            if (student_grid.SelectedIndex >= 0)
            {
                Model.Student model = (Model.Student)student_grid.SelectedItem;
                if (client.UpdateStudent(model) > 0)
                {
                    MessageBox.Show("更新成功");
                    load_student();
                }
                else
                {
                    MessageBox.Show("更新失败");
                }
            }
        }

        private void student_delete_Click(object sender, RoutedEventArgs e)
        {
            if (student_grid.SelectedIndex >= 0)
            {
                if (client.DeleteStudent(((Model.Student)student_grid.SelectedItem).id) > 0)
                {
                    MessageBox.Show("删除成功");
                    load_student();
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
        }

        private void student_find_Click(object sender, RoutedEventArgs e)
        {
            student_grid.ItemsSource = new List<Model.Student>(client.FindStudent(student_name.Text));
        }
        #endregion

        #region 教师管理窗口逻辑
        private void load_teacher()
        {
            teacher_grid.ItemsSource = new List<Model.Teacher>(client.GetTeachers());
        }

        private void teacher_save_Click(object sender, RoutedEventArgs e)
        {
            if (teacher_grid.SelectedIndex >= 0)
            {
                Model.Teacher model = (Model.Teacher)teacher_grid.SelectedItem;
                if (client.UpdateTeacher(model) > 0)
                {
                    MessageBox.Show("更新成功");
                    load_teacher();
                }
                else
                {
                    MessageBox.Show("更新失败");
                }
            }
        }

        private void teacher_delete_Click(object sender, RoutedEventArgs e)
        {
            if (teacher_grid.SelectedIndex >= 0)
            {
                if (client.DeleteTeacher(((Model.Teacher)teacher_grid.SelectedItem).id) > 0)
                {
                    MessageBox.Show("删除成功");
                    load_teacher();
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
        }

        private void teacher_find_Click(object sender, RoutedEventArgs e)
        {
            //teacher_grid.ItemsSource = new List<Model.Teacher>(client.FindTeacher(teacher_name.Text));
        }
        #endregion

        #region 班级管理窗口逻辑实现
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
        #endregion

        #region 课程管理窗口逻辑实现
        private void load_course()
        {
            course_grid.ItemsSource = new List<Model.Course>(client.GetCourses());
        }

        private void course_save_Click(object sender, RoutedEventArgs e)
        {
            if (course_grid.SelectedIndex >= 0)
            {
                Model.Course model = (Model.Course)course_grid.SelectedItem;
                if (client.UpdateCourse(model) > 0)
                {
                    MessageBox.Show("更新成功");
                    load_course();
                }
                else
                {
                    MessageBox.Show("更新失败");
                }
            }
        }

        private void course_delete_Click(object sender, RoutedEventArgs e)
        {
            if (course_grid.SelectedIndex >= 0)
            {
                if (client.DeleteCourse(((Model.Course)course_grid.SelectedItem).id) > 0)
                {
                    MessageBox.Show("删除成功");
                    load_course();
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
        }

        private void course_find_Click(object sender, RoutedEventArgs e)
        {
            course_grid.ItemsSource = new List<Model.Course>(client.FindCourse(course_name.Text));
        }
        #endregion

    }
}
