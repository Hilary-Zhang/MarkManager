using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Teacher
    {
        public int id { set; get; }
        public String name { set; get; }
        public String password { set; get; }
        public String tel { set; get; }
        public String sex { set; get; }
        public Course course { set; get; }
        public String course_name{set;get;}
    }
}
