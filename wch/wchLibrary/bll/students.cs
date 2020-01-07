using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace wch.bll
{
    public class students
    {
        public static void Delete(string id)
        {
            wchEntities dc = new wchEntities();
            wch.wch_Student entry = dc.wch_Student.SingleOrDefault(a => a.StuID == id);
            dc.wch_Student.Remove(entry);
            dc.SaveChanges();
        }

        public static void Add(string stu_json)
        {
            wchEntities dc = new wchEntities();
            wch_Student model = JsonConvert.DeserializeObject<wch_Student>(stu_json);
            dc.wch_Student.Add(model);
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
