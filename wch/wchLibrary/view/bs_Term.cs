using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wch.view
{
    public class bs_Term
    {
        public bs_Term()
        {
            TermName = "";
        }
        public string TermName { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int rowCount { get; set; }
        public IEnumerable<wch.sv_wch_Term> showData { get; set; }
        public wch.sv_wch_Term entry { get; set; }
        public void search()
        {
            wchEntities dc = new wchEntities();
            var data = from a in dc.sv_wch_Term select a;
            if (TermName != "")
            {
                data = from a in data where a.TermName.Contains(TermName) select a;
            }
            this.rowCount = data.Count();
            data = (from a in data orderby a.TermID select a).Skip(pageIndex * pageSize).Take(pageSize);

            showData = data.ToList();
        }
    }
}
