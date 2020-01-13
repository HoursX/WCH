using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wch.view
{
    public class bs_Department
    {
        public bs_Department()
        {
            DepName = "";
        }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int rowCount { get; set; }
        public string DepName { get; set; }
        public IEnumerable<wch.sv_wch_department> showData { get; set; }
        public wch.sv_wch_department entry { get; set; }
        public void search()
        {
            wchEntities dc = new wchEntities();


            var data = from p in dc.sv_wch_department select p;
            if (DepName != "")
            {
                data = from a in data where a.DepName.Contains(DepName) select a;
            }
            this.rowCount = data.Count();
            data = (from a in data orderby a.DepID select a).Skip(pageIndex * pageSize).Take(pageSize);

            showData = data.ToList();
        }
    }
}
