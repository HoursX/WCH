using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wch.view
{
    public class bs_Past
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int rowCount { get; set; }
        public string stuID { get; set; }
        public IEnumerable<wch.sv_wch_pastCourse> showData { get; set; }
        public wch.sv_wch_pastCourse entry { get; set; }
        public void search()
        {
            wchEntities dc = new wchEntities();
            var data = from a in dc.sv_wch_pastCourse select a;
            if (stuID == null)
            {
                throw new Exception();
            }
            data = from a in dc.sv_wch_pastCourse where a.StuID == stuID select a;
            this.rowCount = data.Count();
            data = (from a in data orderby a.TimeID select a).Skip(pageIndex * pageSize).Take(pageSize);

            showData = data.ToList<wch.sv_wch_pastCourse>();
        }
    }
}
