using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wch.view
{
    public class bs_Department
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int rowCount { get; set; }
        public IEnumerable<wch.wch_Department> showData { get; set; }
        public wch.wch_Department entry { get; set; }
        public void search()
        {
            wchEntities dc = new wchEntities();

            var data = from a in dc.wch_Department select a;
            this.rowCount = data.Count();
            data = (from a in data orderby a.DepID select a).Skip(pageIndex * pageSize).Take(pageSize);

            showData = data.ToList<wch.wch_Department>();
        }
    }
}
