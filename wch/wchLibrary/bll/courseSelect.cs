using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wch.bll
{
    public class courseSelect
    {
        public static void Add(string id,string timeid)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception();
            }
            if (string.IsNullOrEmpty(timeid))
            {
                throw new Exception();
            }
            wchEntities dc = new wchEntities();
            wch.wch_CourseSelection model = new wch_CourseSelection();
            int val = Convert.ToInt32(timeid);
            sv_wch_TimeTable check = dc.sv_wch_TimeTable.SingleOrDefault(a => a.TimeID == val);
            if (check.StartChoice > DateTime.Now || check.EndChoice < DateTime.Now)
            {
                throw new Exception();
            }
            model.StuID = id;
            model.TimeID = Convert.ToInt32(timeid);
            dc.wch_CourseSelection.Add(model);
            dc.SaveChanges();
        }
        public static void Delete(string stuid,string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception();
            }
            if (string.IsNullOrEmpty(stuid))
            {
                throw new Exception();
            }

            wchEntities dc = new wchEntities();
            int val = Convert.ToInt32(id);
            wch.wch_CourseSelection model = new wch_CourseSelection();
            sv_wch_TimeTable check = dc.sv_wch_TimeTable.SingleOrDefault(a => a.TimeID == val);
            if (check.StartChoice > DateTime.Now || check.EndChoice < DateTime.Now)
            {
                throw new Exception();
            }
            model.TimeID = Convert.ToInt32(id);
            wch.wch_CourseSelection entry = dc.wch_CourseSelection.SingleOrDefault(a => a.StuID == stuid && a.TimeID == val);
            dc.wch_CourseSelection.Remove(entry);
            dc.SaveChanges();
        }
    }
}
