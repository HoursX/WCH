using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace wch.bll
{
    public class Course
    {
        public static void Update(string course_json)
        {
            wchEntities dc = new wchEntities();
            wch_Course model = JsonConvert.DeserializeObject<wch_Course>(course_json);
            wch_Course newCourse = dc.wch_Course.SingleOrDefault(a => a.CourseID == model.CourseID);
            newCourse.CourseName = model.CourseName;
            newCourse.DepID = model.DepID;
            newCourse.Credit = model.Credit;
            newCourse.Period = model.Period;
            dc.SaveChanges();
        }

        public static void Add(string course_json)
        {
            wchEntities dc = new wchEntities();
            wch_Course model = JsonConvert.DeserializeObject<wch_Course>(course_json);
            dc.wch_Course.Add(model);
            dc.SaveChanges();
        }

        public static void Delete(string id)
        {
            int courseid = Convert.ToInt32(id);
            wchEntities dc = new wchEntities();
            wch_Course model = dc.wch_Course.SingleOrDefault(a => a.CourseID == courseid);
            dc.wch_Course.Remove(model);
            dc.SaveChanges();
        }
    }
}
