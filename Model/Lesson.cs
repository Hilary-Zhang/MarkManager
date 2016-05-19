using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Lesson
    {
        public Teacher teacher { set; get; }
        public Clazz clazz { set; get; }
        public String teacher_name { set; get; }
        public String course_name { set; get; }
        public String clazz_name { set; get; }
    }
}
