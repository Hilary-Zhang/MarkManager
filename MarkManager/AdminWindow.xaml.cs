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
        private ObservableCollection<String> _clazz;
        private ObservableCollection<String> _course;
        private ObservableCollection<String> _teacher;

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

        public ObservableCollection<String> clazz
        {
            get { return _clazz; }
            set { _clazz = value; }
        }

        public ObservableCollection<String> course
        {
            get { return _course; }
            set { _course = value; }
        }

        public ObservableCollection<String> teacher
        {
            set { _teacher = value; }
            get { return _teacher; }
        }

        #region 学生管理窗口逻辑
        private  void load_student()
        {
            student_grid.ItemsSource = new List<Model.Student>(client.GetStudents());
        }

        private void student_save_Click(object sender, RoutedEventArgs e)
        {
            if (student_grid.SelectedIndex >= 0)
            {
                Model.Student model = (Model.Student)student_grid.SelectedItem;
                if (model.clazz_name == null)
                {
                    MessageBox.Show("请选择班级");
                    return;
                }
                if (model.email == null)
                {
                    MessageBox.Show("请输入联系方式");
                    return;
                }
                if(model.name==null)
                {
                    MessageBox.Show("请输入姓名");
                    return;
                }
                if (model.password == null)
                {
                    MessageBox.Show("请输入密码");
                    return;
                }
                if(model.sex==null)
                {
                    MessageBox.Show("请选择性别");
                    return;
                }
                model.clazz = new Model.Clazz();
                model.clazz.name = model.clazz_name;
                model.clazz.id = client.GetClazzIdByName(model.clazz_name);
                if (model.clazz.id == 0)
                {
                    MessageBox.Show("请选择班级");
                    return;
                }
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
            _teacher = new ObservableCollection<string>();
            Model.Teacher[] teachers = client.GetTeachers();
            foreach(Model.Teacher teacher in teachers)
            {
                _teacher.Add(teacher.name);
            }
            teacher_grid.ItemsSource = new List<Model.Teacher>(teachers);
        }

        private void teacher_save_Click(object sender, RoutedEventArgs e)
        {
            if (teacher_grid.SelectedIndex >= 0)
            {
                Model.Teacher model = (Model.Teacher)teacher_grid.SelectedItem;
                if(model.course_name==null)
                {
                    MessageBox.Show("请选择课程");
                    return;
                }
                if(model.name==null)
                {
                    MessageBox.Show("请输入姓名");
                    return;
                }
                if(model.password==null)
                {
                    MessageBox.Show("请输入密码");
                    return;
                }
                if(model.sex==null)
                {
                    MessageBox.Show("请选择性别");
                    return;
                }
                if(model.tel==null)
                {
                    MessageBox.Show("请输入联系方式");
                    return;
                }
                model.course = new Model.Course();
                model.course.name = model.course_name;
                model.course.id = client.GetCourseIdByName(model.course_name);
                if (model.course.id == 0)
                {
                    MessageBox.Show("请选择课程");
                    return;
                }
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
            teacher_grid.ItemsSource = new List<Model.Teacher>(client.FindTeacher(teacher_name.Text));
        }
        #endregion

        #region 班级管理窗口逻辑实现
        private void load_clazz()
        {
            _clazz = new ObservableCollection<String>();
            Model.Clazz[] clazzs = client.GetClazzs();
            foreach(Model.Clazz clazz in clazzs)
            {
                _clazz.Add(clazz.name);
            }
            clazz_grid.ItemsSource = new List<Model.Clazz>(clazzs);
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
            _course = new ObservableCollection<String>();
            Model.Course[] courses = client.GetCourses();
            foreach (Model.Course course in courses)
            {
                _course.Add(course.name);
            }
            course_grid.ItemsSource = new List<Model.Course>(courses);
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
