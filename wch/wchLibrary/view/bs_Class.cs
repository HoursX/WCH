using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wch.view
{
    public class bs_Class
    {
        public bs_Class()
        {
            className = "";
        }
        public string className { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int rowCount { get; set; }
        public IEnumerable<wch.sv_wch_Class> showData { get; set; }
        public wch.sv_wch_Class entry { get; set; }
        public void search()
        {
            wchEntities dc = new wchEntities();
            var data = from a in dc.sv_wch_Class select a;
            if (className != "")
            {
                data = from a in data where a.ClassName.Contains(className) select a;
            }
            this.rowCount = data.Count();
            data = (from a in data orderby a.ClassID select a).Skip(pageIndex * pageSize).Take(pageSize);

            showData = data.ToList<wch.sv_wch_Class>();
        }
    }
}
