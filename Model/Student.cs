using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Student
    {
        public int id { set; get; }
        public String name { set; get; }
        public String password { set; get; }
        public String email { set; get; }
        public short sex { set; get; }
        public Clazz clazz { set; get; }
    }
}
