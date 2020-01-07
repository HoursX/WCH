using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wch.view
{
    public class bs_TimeTable
    {
        public bs_TimeTable()
        {
            CourseName = "";
            DepName = "";
            TeaName = "";
            TermName = "";
            Site = "";
        }
        public string CourseName { get; set; }
        public string DepName { get; set; }
        public string TeaName { get; set; }
        public string TermName { get; set; }
        public string Site { get; set; }

        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int rowCount { get; set; }

        public IEnumerable<wch.sv_wch_TimeTable> showData { get; set; }
        public wch.sv_wch_TimeTable entry { get; set; }
        public void search()
        {
            wchEntities dc = new wchEntities();

            var data = from a in dc.sv_wch_TimeTable select a;
            if (CourseName != "")
            {
                data = from a in data where a.CourseName.Contains(CourseName) select a;
            }
            if (DepName != "")
            {
                data = from a in data where a.DepName.Contains(DepName) select a;
            }
            if (TeaName != "")
            {
                data = from a in data where a.TeaName.Contains(TeaName) select a;
            }
            if (TermName != "")
            {
                data = from a in data where a.TermName.Contains(TermName) select a;
            }
            if (Site != "")
            {
                data = from a in data where a.Site.Contains(Site) select a;
            }
            this.rowCount = data.Count();
            data = (from a in data orderby a.TimeID select a).Skip(pageIndex * pageSize).Take(pageSize);

            showData = data.ToList<wch.sv_wch_TimeTable>();
        }
    }
}
