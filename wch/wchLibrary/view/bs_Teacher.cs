using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wch.view
{
    public class bs_Teacher
    {
        public bs_Teacher()
        {
            teaName = "";
            teaID = "";
            depName = "";
        }
        public string teaName { get; set; }
        public string teaID { get; set; }
        public string depName { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int rowCount { get; set; }
        public IEnumerable<wch.sv_wch_Teacher> showData { get; set; }
        public wch.sv_wch_Teacher entry { get; set; }
        public void search()
        {
            wch.wchEntities dc = new wch.wchEntities();
            var data = from a in dc.sv_wch_Teacher select a;
            if (teaName != "")
            {
                data = from a in data where a.TeaName.Contains(teaName) select a;
            }
            if (teaID != "")
            {
                data = from a in data where a.TeaID.Contains(teaID) select a;
            }
            if (depName != "")
            {
                data = from a in data where a.DepName.Contains(depName) select a;
            }
            this.rowCount = data.Count();
            data = (from a in data
                    orderby a.TeaID ascending
                    select a).Skip(pageIndex * pageSize).Take(pageSize);
            showData = data.ToList<wch.sv_wch_Teacher>();
        }
    }
}
