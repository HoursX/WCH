using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wch.view
{
    public class bs_CourseSelect
    {
        public bs_CourseSelect()
        {
            stuID = "";
            stuName = "";
            termName = "";
            courseName = "";
            teaName = "";
        }
        public string stuName { get; set; }
        public string stuID { get; set; }

        public string termName { get; set; }
        public string courseName { get; set; }
        public string teaName { get; set; }


        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int rowCount { get; set; }

        public IEnumerable<wch.sv_wch_courseSelect> showData { get; set; }
        public wch.sv_wch_courseSelect entry { get; set; }
        public void search()
        {
            wchEntities dc = new wchEntities();

            var data = from a in dc.sv_wch_courseSelect select a;
            if (stuName != "")
            {
                data = from a in data where a.StuName.Contains(stuName) select a;
            }
            if (stuID != "")
            {
                data = from a in data where a.StuID.Contains(stuID) select a;
            }
            if (termName != "")
            {
                data = from a in data where a.TermName.Contains(termName) select a;
            }
            if (courseName != "")
            {
                data = from a in data where a.CourseName.Contains(courseName) select a;
            }
            if (teaName != "")
            {
                data = from a in data where a.TeaName.Contains(teaName) select a;
            }
            this.rowCount = data.Count();
            data = (from a in data orderby a.StuID select a).Skip(pageIndex * pageSize).Take(pageSize);

            showData = data.ToList();
        }
    }
}
