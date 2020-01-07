using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wch.view
{
    public class bs_Student
    {
        public bs_Student()
        {
            stuName = "";
            stuID = "";
            className = "";
        }
        public string stuName { get; set; }
        public string stuID { get; set; }

        public string className { get; set; }

        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int rowCount { get; set; }

        public IEnumerable<wch.sv_wch_Student> showData { get; set; }
        public wch.sv_wch_Student entry { get; set; }
        public void search()
        {
            wchEntities dc = new wchEntities();

            var data = from a in dc.sv_wch_Student select a;
            if (stuName != "")
            {
                data = from a in data where a.StuName.Contains(stuName) select a;
            }
            if (stuID != "")
            {
                data = from a in data where a.StuID.Contains(stuID) select a;
            }
            if (className != "")
            {
                data = from a in data where a.ClassName.Contains(className) select a;
            }
            this.rowCount = data.Count();
            data = (from a in data orderby a.StuID select a).Skip(pageIndex * pageSize).Take(pageSize);

            showData = data.ToList<wch.sv_wch_Student>();
        }
    }
}
