using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wch.view
{
    public class bs_Course
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int rowCount { get; set; }
        public string stuID { get; set; }
        public IEnumerable<wch.sv_wch_StudentSelect> showData { get; set; }
        public wch.sv_wch_StudentSelect entry { get; set; }
        public void search()
        {
            wchEntities dc = new wchEntities();
            var data = from a in dc.sv_wch_StudentSelect select a;
            if (stuID != null)
            {
                var list = from a in dc.wch_CourseSelection where a.StuID == stuID select a.TimeID;
                data = from a in data where !list.Contains(a.TimeID) select a;
            }
            this.rowCount = data.Count();
            data = (from a in data orderby a.CourseID select a).Skip(pageIndex * pageSize).Take(pageSize);

            showData = data.ToList<wch.sv_wch_StudentSelect>();
        }
    }
}
