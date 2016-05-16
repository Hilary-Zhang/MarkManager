using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Clazz
    {
        public static List<Model.Clazz> getClazzs()
        {
            List<Model.Clazz> result = new List<Model.Clazz>();
            SqlDataReader reader = DBHelper.query("SELECT [id],[name] FROM [clazz]");
            while(reader.Read())
            {
                Model.Clazz model = new Model.Clazz();
                model.id = reader.GetInt32(0);
                model.name = reader.GetString(1);
                result.Add(model);
            }
            return result;
        }

        public static int updateClazz(Model.Clazz clazz)
        {
            return DBHelper.execute("UPDATE [clazz] SET [name]=N'" + clazz.name + "' WHERE [id]=" + clazz.id);
        }

        public static int insertClazz(Model.Clazz clazz)
        {
            return DBHelper.execute(String.Format("INSERT INTO [clazz] ([name]) VALUES (N'{0}')", clazz.name));
        }

        public static int deleteClazz(int id)
        {
            return DBHelper.execute("DELETE FROM [clazz] WHERE id=" + id);
        }

        public static List<Model.Clazz> findClazz(String name)
        {
            List<Model.Clazz> result = new List<Model.Clazz>();
            SqlDataReader reader=DBHelper.query("SELECT [id],[name] FROM [clazz] WHERE [name] LIKE N'%"+name+"%'");
            while (reader.Read())
            {
                Model.Clazz model = new Model.Clazz();
                model.id = reader.GetInt32(0);
                model.name = reader.GetString(1);
                result.Add(model);
            }
            return result;
        }
    }
}
