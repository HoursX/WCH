using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wch.view
{
    public class bs_CourseSelection
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int rowCount { get; set; }
        public IEnumerable<wch.sv_wch_CourseSelection> showData { get; set; }
        public wch.sv_wch_CourseSelection entry { get; set; }
        public void search()
        {
            wch.wchEntities dc = new wch.wchEntities();
            var data = from a in dc.sv_wch_CourseSelection select a;
            this.rowCount = data.Count();
            data = (from a in data
                    orderby a.StuID ascending
                    select a).Skip(pageIndex * pageSize).Take(pageSize);
            showData = data.ToList<wch.sv_wch_CourseSelection>();
        }
    }
}
