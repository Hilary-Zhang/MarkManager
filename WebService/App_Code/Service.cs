﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Model;

// 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、服务和配置文件中的类名“Service”。
public class Service : IService
{
    public Service()
    {
        DAL.DBHelper.connect("Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True");//数据库连接
    }

    #region 登录接口
    public int Login(string username, string password, short type)
    {
        switch (type)
        {
            case 0://学生
                return DAL.Student.checkPassword(username, password);
            case 1://老师
                return DAL.Teacher.checkPassword(username, password);
            case 2://管理员
                return DAL.Admin.checkPassword(username, password);
            default:
                return 0;
        }
    }
    #endregion

    #region 学生接口
    public List<Student> GetStudents()
    {
        return DAL.Student.getStudents();
    }

    public int UpdateStudent(Student student)
    {
        if (student.id == 0)
        {
            return DAL.Student.insertStudent(student);
        }
        else
        {
            return DAL.Student.updateStudent(student);
        }
    }

    public int DeleteStudent(int id)
    {
        return DAL.Student.deleteStudent(id);
    }

    public List<Student> FindStudent(string name)
    {
        return DAL.Student.findStudent(name);
    }

    public Student GetStudentById(int id)
    {
        return DAL.Student.getStudentById(id);
    }
    #endregion

    #region 老师接口 
    public List<Teacher> GetTeachers()
    {
        return DAL.Teacher.getTeachers();
    }

    public int UpdateTeacher(Teacher teacher)
    {
        if (teacher.id == 0)
        {
            return DAL.Teacher.insertTeacher(teacher);
        }
        else
        {
            return DAL.Teacher.updateTeacher(teacher);
        }
    }

    public int DeleteTeacher(int id)
    {
        return DAL.Teacher.deleteTeacher(id);
    }

    public List<Teacher> FindTeacher(string name)
    {
        return DAL.Teacher.findTeacher(name);
    }
    public Teacher GetTeacherById(int id)
    {
        return DAL.Teacher.getTeacherById(id);
    }
    #endregion

    #region 班级接口
    public List<Clazz> GetClazzs()
    {
        return DAL.Clazz.getClazzs();
    }

    public int UpdateClazz(Model.Clazz clazz)
    {
        if (clazz.id == 0)
        {
            return DAL.Clazz.insertClazz(clazz);
        }
        else
        {
            return DAL.Clazz.updateClazz(clazz);
        }
    }

    public int DeleteClazz(int id)
    {
        return DAL.Clazz.deleteClazz(id);
    }

    public List<Clazz> FindClazz(string name)
    {
        return DAL.Clazz.findClazz(name);
    }

    public int GetClazzIdByName(String name)
    {
        List<Model.Clazz> result = DAL.Clazz.findClazz(name);
        if (result.Count > 0)
        {
            return result[0].id;
        }
        else
        {
            return 0;
        }
    }
    #endregion

    #region 课程接口
    public List<Course> GetCourses()
    {
        return DAL.Course.getCourses();
    }

    public int UpdateCourse(Course course)
    {
        if (course.id == 0)
        {
            return DAL.Course.insertCourse(course);
        }
        else
        {
            return DAL.Course.updateCourse(course);
        }
    }

    public int DeleteCourse(int id)
    {
        return DAL.Course.deleteCourse(id);
    }

    public List<Course> FindCourse(string name)
    {
        return DAL.Course.findCourse(name);
    }

    public int GetCourseIdByName(string name)
    {
        List<Model.Course> result = DAL.Course.findCourse(name);
        if (result.Count > 0)
        {
            return result[0].id;
        }
        else
        {
            return 0;
        }
    }
    #endregion

    public List<Teacher> GetLessons(int student_id)
    {
        return DAL.Mark.getLessons(student_id);
    }

    public List<Mark> GetMarksByStudentId(int student_id)
    {
        return DAL.Mark.getMarksByStudentId(student_id);
    }

    public List<Mark> GetMarksByTeacherId(int teacher_id)
    {
        return DAL.Mark.getMarksByTeacherId(teacher_id);
    }

    public int AddMark(int student_id, int teacher_id)
    {
        return DAL.Mark.addMark(student_id, teacher_id);
    }

    public int UpdateMark(Model.Mark mark)
    {
        return DAL.Mark.updateMark(mark);
    }

    public List<Mark> FindStudentMark(int teacher_id, string name)
    {
        return DAL.Mark.findStudentMark(teacher_id, name);
    }

    public List<Mark> FindTeacherMark(int student_id, string name)
    {
        return DAL.Mark.findTeacherMark(student_id, name);
    }

    public List<Model.Teacher> FindCourseMark(int student_id, String name)
    {
        return DAL.Mark.findCourseMark(student_id, name);
    }
}
