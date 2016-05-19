using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace DAL
{
    public class Student
    {
        public static int checkPassword(String username,String password)
        {
            SqlDataReader reader = DBHelper.query("SELECT TOP 1 [id],[password] FROM [student] WHERE name=N'" + username + "'");
            if (reader.Read())
            {
                if (reader.GetSqlString(1) == password)
                    return reader.GetInt32(0);
            }
            return 0;
        }

        public static List<Model.Student> getStudents()
        {
            List<Model.Student> result = new List<Model.Student>();
            SqlDataReader reader = DBHelper.query("SELECT [Student].[id],[Student].[name],[sex],[clazz_id],[Clazz].[name],[password],[email] FROM [Student] JOIN [Clazz] ON [Clazz].[id]=[Student].[clazz_id]");
            while (reader.Read())
            {
                Model.Student model = new Model.Student();
                model.id = reader.GetInt32(0);
                model.name = reader.GetString(1).Trim();
                model.sex = reader.GetString(2).Trim();
                model.clazz = new Model.Clazz();
                model.clazz.id = reader.GetInt32(3);
                model.clazz.name = reader.GetString(4).Trim();
                model.password = reader.GetString(5).Trim();
                model.email = reader.GetString(6).Trim();
                model.clazz_name = model.clazz.name;
                result.Add(model);
            }
            return result;
        }

        public static int updateStudent(Model.Student student)
        {
            if (student.clazz==null)
            {
                return DBHelper.execute(String.Format("UPDATE [Student] SET [password]=N'{0}',email=N'{1}' WHERE id={2}", student.password.Trim(), student.email.Trim(),student.id));
            }
            else
            {
                return DBHelper.execute(String.Format("UPDATE [Student] SET [name]=N'{0}',[password]=N'{1}',email=N'{2}',sex=N'{3}',clazz_id={4} WHERE id={5}", student.name.Trim(), student.password.Trim(), student.email.Trim(), student.sex.Trim(), student.clazz.id, student.id));
            }
        }

        public static int insertStudent(Model.Student student)
        {
            return DBHelper.execute(String.Format("INSERT INTO [Student] ([name],[password],[email],[sex],[clazz_id]) VALUES (N'{0}',N'{1}',N'{2}',N'{3}',{4})", student.name.Trim(), student.password.Trim(), student.email.Trim(), student.sex.Trim(), student.clazz.id));
        }

        public static int deleteStudent(int id)
        {
            return DBHelper.execute("DELETE FROM [student] WHERE id=" + id);
        }

        public static List<Model.Student> findStudent(String name)
        {
            List<Model.Student> result = new List<Model.Student>();
            SqlDataReader reader = DBHelper.query("SELECT [Student].[id],[Student].[name],[sex],[clazz_id],[Clazz].[name],[password],[email] FROM [Student] JOIN [Clazz] ON [Clazz].[id]=[Student].[clazz_id] WHERE [student].[name] LIKE N'%" + name.Trim() + "%' or [Clazz].[name] LIKE N'%" + name.Trim() + "%'");
            while (reader.Read())
            {
                Model.Student model = new Model.Student();
                model.id = reader.GetInt32(0);
                model.name = reader.GetString(1).Trim();
                model.sex = reader.GetString(2).Trim();
                model.clazz = new Model.Clazz();
                model.clazz.id = reader.GetInt32(3);
                model.clazz.name = reader.GetString(4).Trim();
                model.password = reader.GetString(5).Trim();
                model.email = reader.GetString(6).Trim();
                model.clazz_name = model.clazz.name;
                result.Add(model);
            }
            return result;
        }

        public static Model.Student getStudentById(int id)
        {
            Model.Student model = new Model.Student();
            SqlDataReader reader = DBHelper.query("SELECT [Student].[id],[Student].[name],[sex],[clazz_id],[Clazz].[name],[password],[email] FROM [Student] JOIN [Clazz] ON [Clazz].[id]=[Student].[clazz_id] WHERE [Student].[id]=" + id);
            if(reader.Read())
            {
                model.id = reader.GetInt32(0);
                model.name = reader.GetString(1).Trim();
                model.sex = reader.GetString(2).Trim();
                model.clazz = new Model.Clazz();
                model.clazz.id = reader.GetInt32(3);
                model.clazz.name = reader.GetString(4).Trim();
                model.password = reader.GetString(5).Trim();
                model.email = reader.GetString(6).Trim();
                model.clazz_name = model.clazz.name;
            }
            return model;
        }
    }
}
