using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Mark
    {
        public int student_id { set; get; }
        public int teacher_id { set; get; }
        public Int16 mark { set; get; }
        public String teacher_name { set; get; }
        public String course_name { set; get; }
        public String student_name { set; get; }
    }
}
