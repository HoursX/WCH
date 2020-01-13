using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wch.bll
{
    public class grade
    {
        public static void Update(string grade_json)
        {
            wchEntities dc = new wchEntities();
            wch_CourseSelection model = JsonConvert.DeserializeObject<wch_CourseSelection>(grade_json);
            wch_CourseSelection newCourse = dc.wch_CourseSelection.SingleOrDefault(a => a.TimeID == model.TimeID && a.StuID == model.StuID);
            newCourse.Mark = model.Mark;
            dc.SaveChanges();
        }
    }
}
