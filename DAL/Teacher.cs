using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace DAL
{
    public class Teacher
    {
        public static int checkPassword(String username,String password)
        {
            SqlDataReader reader = DBHelper.query("SELECT TOP 1 [id],[password] FROM [Teacher] WHERE name=N'" + username.Trim() + "'");
            if (reader.Read())
            {
                if (reader.GetSqlString(1) == password)
                    return reader.GetInt32(0);
            }
            return 0;
        }

        public static List<Model.Teacher> getTeachers()
        {
            List<Model.Teacher> result = new List<Model.Teacher>();
            SqlDataReader reader = DBHelper.query("SELECT [Teacher].[id],[Teacher].[name],[sex],[password],[tel],[course_id],[Course].[name] FROM [Teacher] JOIN [Course] ON [Course].[id]=[Teacher].[course_id]");
            while (reader.Read())
            {
                Model.Teacher  model = new Model.Teacher ();
                model.id = reader.GetInt32(0);
                model.name = reader.GetString(1).Trim();
                model.sex = reader.GetString(2).Trim();
                model.password = reader.GetString(3).Trim();
                model.tel = reader.GetString(4).Trim();
                model.course = new Model.Course();
                model.course.id = reader.GetInt32(5);
                model.course.name = reader.GetString(6).Trim();
                model.course_name = model.course.name;
                result.Add(model);
            }
            return result;
        }

        public static int updateTeacher(Model.Teacher teacher)
        {
            if (teacher.course == null)
            {
                return DBHelper.execute(String.Format("UPDATE [Teacher] SET [password]=N'{0}',tel=N'{1}' WHERE id={2}",teacher.password.Trim(), teacher.tel.Trim(),teacher.id));
            }
            else
            {
                return DBHelper.execute(String.Format("UPDATE [Teacher] SET [name]=N'{0}',[password]=N'{1}',tel=N'{2}',sex=N'{3}',course_id={4} WHERE id={5}", teacher.name.Trim(), teacher.password.Trim(), teacher.tel.Trim(), teacher.sex.Trim(), teacher.course.id, teacher.id));
            } 
        }

        public static int insertTeacher(Model.Teacher teacher)
        {
            return DBHelper.execute(String.Format("INSERT INTO [Teacher] ([name],[password],[tel],[sex],[course_id]) VALUES (N'{0}',N'{1}',N'{2}',N'{3}',{4})", teacher.name, teacher.password.Trim(), teacher.tel.Trim(), teacher.sex.Trim(),teacher.course.id));
        }

        public static int deleteTeacher(int id)
        {
            return DBHelper.execute("DELETE FROM [Teacher] WHERE id=" + id);
        }

        public static List<Model.Teacher> findTeacher(String name)
        {
            List<Model.Teacher> result = new List<Model.Teacher>();
            SqlDataReader reader = DBHelper.query("SELECT [Teacher].[id],[Teacher].[name],[sex],[password],[tel],[course_id],[Course].[name] FROM [Teacher] JOIN [Course] ON [Course].[id]=[Teacher].[course_id] WHERE [Teacher].[name] LIKE N'%" + name.Trim() + "%' or [course].[name] LIKE N'%" + name.Trim() + "%'");
            while (reader.Read())
            {
                Model.Teacher model = new Model.Teacher();
                model.id = reader.GetInt32(0);
                model.name = reader.GetString(1).Trim();
                model.sex = reader.GetString(2).Trim();
                model.password = reader.GetString(3).Trim();
                model.tel = reader.GetString(4).Trim();
                model.course = new Model.Course();
                model.course.id = reader.GetInt32(5);
                model.course.name = reader.GetString(6).Trim();
                model.course_name = model.course.name;
                result.Add(model);
            }
            return result;
        }

        public static Model.Teacher getTeacherById(int id)
        {
            Model.Teacher model = new Model.Teacher();
            SqlDataReader reader = DBHelper.query("SELECT [Teacher].[id],[Teacher].[name],[sex],[course_id],[Course].[name],[password],[tel] FROM [Teacher] JOIN [Course] ON [Course].[id]=[Teacher].[course_id] WHERE [Teacher].[id]=" + id);
            if (reader.Read())
            {
                model.id = reader.GetInt32(0);
                model.name = reader.GetString(1).Trim();
                model.sex = reader.GetString(2).Trim();
                model.course = new Model.Course();
                model.course.id = reader.GetInt32(3);
                model.course.name = reader.GetString(4).Trim();
                model.password = reader.GetString(5).Trim();
                model.tel = reader.GetString(6).Trim();
                model.course_name = model.course.name;
            }
            return model;
        }
    }
}
