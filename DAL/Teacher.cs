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
            SqlDataReader reader = DBHelper.query("SELECT TOP 1 [id],[password] FROM [Teacher] WHERE name='" + username + "'");
            return reader.Read() && reader["password"].ToString() == password ? Convert.ToInt32(reader["id"]) : 0;
        }


        public static List<Model.Teacher> getTeachers()
        {
            List<Model.Teacher> result = new List<Model.Teacher>();
            SqlDataReader reader = DBHelper.query("SELECT [id],[name],[sex],[password],[tel] FROM [Teacher]");
            while (reader.Read())
            {
                Model.Teacher  model = new Model.Teacher ();
                model.id = reader.GetInt32(0);
                model.name = reader.GetString(1);
                model.sex = reader.GetInt16(2);
                model.password = reader.GetString(3);
                model.tel = reader.GetString(4);
                result.Add(model);
            }
            return result;
        }

        public static int updateTeacher(Model.Teacher teacher)
        {
            return DBHelper.execute(String.Format("UPDATE [Teacher] SET [name]=N'{0}',[password]=N'{1}',tel=N'{2}',sex={3} WHERE id={5}",teacher.name, teacher.password, teacher.tel,teacher.sex,teacher.id));
        }
        public static int insertTeacher(Model.Teacher teacher)
        {
            return DBHelper.execute(String.Format("INSERT INTO [Teacher] ([name],[password],[tel],[sex]) VALUES (N'{0}',{1},{2},N'{3}')", teacher.name, teacher.password, teacher.tel, teacher.sex));
        }

        public static int deleteTeacher(int id)
        {
            return DBHelper.execute("DELETE FROM [Teacher] WHERE id=" + id);
        }

        public static List<Model.Teacher> findTeacher(String name)
        {
            List<Model.Teacher> result = new List<Model.Teacher>();
            SqlDataReader reader = DBHelper.query("SELECT [id],[name],[sex],[password],[tel] FROM [Teacher] WHERE [name] LIKE N'%" + name + "%'");
            while (reader.Read())
            {
                Model.Teacher model = new Model.Teacher();
                model.id = reader.GetInt32(0);
                model.name = reader.GetString(1);
                model.sex = reader.GetInt16(2);
                model.password = reader.GetString(3);
                model.tel = reader.GetString(4);
                result.Add(model);
            }
            return result;
        }
    }
}
