using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Course
    {
        public static List<Model.Course> getCourses()
        {
            List<Model.Course> result = new List<Model.Course>();
            SqlDataReader reader = DBHelper.query("SELECT [id],[name] FROM [Course]");
            while (reader.Read())
            {
                Model.Course model = new Model.Course();
                model.id = reader.GetInt32(0);
                model.name = reader.GetString(1).Trim();
                result.Add(model);
            }
            return result;
        }

        public static int updateCourse(Model.Course course)
        {
            return DBHelper.execute("UPDATE [Course] SET [name]=N'" + course.name.Trim() + "' WHERE [id]=" + course.id);
        }

        public static int insertCourse(Model.Course course)
        {
            return DBHelper.execute(String.Format("INSERT INTO [Course] ([name]) VALUES (N'{0}')", course.name.Trim()));
        }

        public static int deleteCourse(int id)
        {
            return DBHelper.execute("DELETE FROM [Course] WHERE id=" + id);
        }

        public static List<Model.Course> findCourse(String name)
        {
            List<Model.Course> result = new List<Model.Course>();
            SqlDataReader reader = DBHelper.query("SELECT [id],[name] FROM [Course] WHERE [name] LIKE N'%" + name.Trim() + "%'");
            while (reader.Read())
            {
                Model.Course model = new Model.Course();
                model.id = reader.GetInt32(0);
                model.name = reader.GetString(1).Trim();
                result.Add(model);
            }
            return result;
        }
    }
}
