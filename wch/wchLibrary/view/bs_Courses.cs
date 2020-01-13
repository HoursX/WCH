using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wch.view
{
    public class bs_Courses
    {
        public bs_Courses()
        {
            courseName = "";
        }
        public string courseName { get; set; }


        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int rowCount { get; set; }

        public IEnumerable<wch.sv_wch_Course> showData { get; set; }
        public wch.sv_wch_Course entry { get; set; }
        public void search()
        {
            wchEntities dc = new wchEntities();

            var data = from a in dc.sv_wch_Course select a;
            if (courseName != "")
            {
                data = from a in data where a.CourseName.Contains(courseName) select a;
            }
            this.rowCount = data.Count();
            data = (from a in data orderby a.CourseID select a).Skip(pageIndex * pageSize).Take(pageSize);

            showData = data.ToList();
        }
    }
}
