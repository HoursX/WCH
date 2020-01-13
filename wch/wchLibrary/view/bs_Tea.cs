using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wch.view
{
    public class bs_Tea
    {
        public bs_Tea()
        {
            CourseName = "";
        }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int rowCount { get; set; }
        public string TeaID { get; set; }
        public string CourseName { get; set; }
        public IEnumerable<wch.sv_wch_pastCourse> showData { get; set; }
        public wch.sv_wch_pastCourse entry { get; set; }
        public void search()
        {
            wchEntities dc = new wchEntities();
            var data = from a in dc.sv_wch_pastCourse select a;
            if (TeaID == null)
            {
                throw new Exception();
            }
            data = from a in dc.sv_wch_pastCourse where a.TeaID == TeaID select a;
            if(!string.IsNullOrEmpty(CourseName))
            {
                data = from a in data where a.CourseName.Contains(CourseName) select a;
            }
            this.rowCount = data.Count();
            data = (from a in data orderby a.TimeID select a).Skip(pageIndex * pageSize).Take(pageSize);

            showData = data.ToList<wch.sv_wch_pastCourse>();
        }
    }
}
