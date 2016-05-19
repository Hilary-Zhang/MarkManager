using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService”。
[ServiceContract]
public interface IService
{
    [OperationContract]
    int Login(String username, String password, short type);

    [OperationContract]
    List<Model.Student> GetStudents();

    [OperationContract]
    int UpdateStudent(Model.Student student);

    [OperationContract]
    int DeleteStudent(int id);

    [OperationContract]
    List<Model.Student> FindStudent(String name);

    [OperationContract]
    Model.Student GetStudentById(int id);

    [OperationContract]
    List<Model.Teacher> GetTeachers();

    [OperationContract]
    int UpdateTeacher(Model.Teacher teacher);

    [OperationContract]
    int DeleteTeacher(int id);

    [OperationContract]
    List<Model.Teacher> FindTeacher(String name);

    [OperationContract]
    Model.Teacher GetTeacherById(int id);

    [OperationContract]
    List<Model.Clazz> GetClazzs();

    [OperationContract]
    int GetClazzIdByName(String name);

    [OperationContract]
    int UpdateClazz(Model.Clazz clazz);

    [OperationContract]
    int DeleteClazz(int id);

    [OperationContract]
    List<Model.Clazz> FindClazz(String name);

    [OperationContract]
    List<Model.Course> GetCourses();

    [OperationContract]
    int GetCourseIdByName(String name);

    [OperationContract]
    int UpdateCourse(Model.Course course);

    [OperationContract]
    int DeleteCourse(int id);

    [OperationContract]
    List<Model.Course> FindCourse(String name);

    [OperationContract]
    List<Model.Teacher> GetLessons(int student_id);

    [OperationContract]
    List<Model.Mark> GetMarksByStudentId(int student_id);

    [OperationContract]
    List<Model.Mark> GetMarksByTeacherId(int teacher_id);

    [OperationContract]
    int AddMark(int student_id, int teacher_id);

    [OperationContract]
    int UpdateMark(Model.Mark mark);
}
