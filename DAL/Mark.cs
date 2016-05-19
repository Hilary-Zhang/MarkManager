using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Mark
    {
        public static List<Model.Teacher> getLessons(int student_id)
        {
            List<Model.Teacher> result = new List<Model.Teacher>();
            SqlDataReader reader = DBHelper.query("SELECT [Teacher].[id],[Teacher].[name],[sex],[password],[tel],[course_id],[Course].[name] FROM [Teacher] JOIN [Course] ON [Course].[id]=[Teacher].[course_id] WHERE [Teacher].[id] NOT IN (SELECT [teacher_id] FROM [Mark] WHERE [student_id]=" + student_id + ")");
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

        public static List<Model.Mark> getMarksByStudentId(int student_id)
        {
            List<Model.Mark> result = new List<Model.Mark>();
            SqlDataReader reader = DBHelper.query("SELECT [Mark].[student_id],[Mark].[teacher_id],[mark],[Course].[name],[Teacher].[name] FROM [Mark] JOIN [Teacher] ON [Teacher].[id]=[Mark].[teacher_id] JOIN [Course] ON [Course].[id]=[Teacher].[course_id] WHERE [student_id]=" + student_id);
            while (reader.Read())
            {
                Model.Mark model = new Model.Mark();
                model.student_id = reader.GetInt32(0);
                model.teacher_id = reader.GetInt32(1);
                model.mark = reader.GetInt16(2);
                model.course_name = reader.GetString(3);
                model.teacher_name = reader.GetString(4);
                result.Add(model);
            }
            return result;
        }

        public static List<Model.Mark> getMarksByTeacherId(int teacher_id)
        {
            List<Model.Mark> result = new List<Model.Mark>();
            SqlDataReader reader = DBHelper.query("SELECT [Mark].[student_id],[Mark].[teacher_id],[mark],[Course].[name],[Teacher].[name],[Student].[name] FROM [Mark] JOIN [Student] ON [Student].[id]=[Mark].[student_id] JOIN [Teacher] ON [Teacher].[id]=[Mark].[teacher_id] JOIN [Course] ON [Course].[id]=[Teacher].[course_id] WHERE [teacher_id]=" + teacher_id);
            while (reader.Read())
            {
                Model.Mark model = new Model.Mark();
                model.student_id = reader.GetInt32(0);
                model.teacher_id = reader.GetInt32(1);
                model.mark = reader.GetInt16(2);
                model.course_name = reader.GetString(3);
                model.teacher_name = reader.GetString(4);
                model.student_name = reader.GetString(5);
                result.Add(model);
            }
            return result;
        }

        public static int addMark(int student_id,int teacher_id)
        {
            return DBHelper.execute(String.Format("INSERT INTO [Mark] ([student_id],[teacher_id]) VALUES ({0},{1})", student_id, teacher_id));
        }

        public static int updateMark(Model.Mark mark)
        {
            return DBHelper.execute(String.Format("UPDATE [Mark] SET [mark]={0} WHERE [student_id]={1} AND [teacher_id]={2}",mark.mark,mark.student_id,mark.teacher_id));
        }
    }
}
