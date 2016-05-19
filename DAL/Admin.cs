using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace DAL
{
    public class Admin
    {
        public static int checkPassword(String username,String password)
        {
            SqlDataReader reader = DBHelper.query("SELECT TOP 1 [id],[password] FROM [admin] WHERE name=N'" + username + "'");
            if(reader.Read())
            {
                if (reader.GetSqlString(1) == password)
                    return reader.GetInt32(0);
            }
            return 0;
        }
    }
}
