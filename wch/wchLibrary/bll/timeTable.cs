using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace wch.bll
{
    public class timeTable
    {
        public static void Delete(string id)
        {
            wchEntities dc = new wchEntities();
            int val = Convert.ToInt32(id);
            wch.wch_TimeTable entry = dc.wch_TimeTable.SingleOrDefault(a => a.TimeID == val);
            if (entry.StuNum > 0 && entry.StuNum != null)
            {
                throw new Exception();
            }
            var list = from a in dc.wch_TimeTableDetail where a.TimeID == val select a;
            dc.wch_TimeTableDetail.RemoveRange(list);
            dc.wch_TimeTable.Remove(entry);
            dc.SaveChanges();
        }

        public static void Add(string time_json)
        {
            wchEntities dc = new wchEntities();
            sv_wch_TimeTable model = JsonConvert.DeserializeObject<sv_wch_TimeTable>(time_json);

            if (dc.wch_TimeTableDetail.Any(a => a.TermID == model.TermID && a.Day == model.Day && a.ScheduleID == model.ScheduleID && a.TheatreID == model.TheatreID))
            {
                throw new Exception();
            }


            wch_TimeTable timeTable = new wch_TimeTable();
            wch_TimeTableDetail timeTableDetail = new wch_TimeTableDetail();
            timeTable.CourseID = model.CourseID;
            timeTable.TeaID = model.TeaID;
            timeTable.Capacity = model.Capacity;
            timeTable.AllowView = model.AllowView;
            dc.wch_TimeTable.Add(timeTable);
            dc.SaveChanges();
            wch_TimeTable view = dc.wch_TimeTable.OrderByDescending(table => table.TimeID).First();
            timeTableDetail.TimeID = view.TimeID;
            timeTableDetail.TermID = model.TermID;
            timeTableDetail.Day = model.Day;
            timeTableDetail.ScheduleID = model.ScheduleID;
            timeTableDetail.TheatreID = model.TheatreID;
            
            dc.wch_TimeTableDetail.Add(timeTableDetail);
            dc.SaveChanges();
        }

        public static void Update(string stu_json)
        {
            wchEntities dc = new wchEntities();
            wch_Student model = JsonConvert.DeserializeObject<wch_Student>(stu_json);
            wch_Student stu = dc.wch_Student.SingleOrDefault(a => a.StuID == model.StuID);
            stu.StuName = model.StuName;
            stu.Gender = model.Gender;
            stu.ClassID = model.ClassID;
            stu.DepID = model.DepID;
            stu.StuAge = model.StuAge;
            stu.Tel = model.Tel;
            stu.Address = model.Address;
            stu.Grade = model.Grade;
            dc.SaveChanges();
        }
    }
}
