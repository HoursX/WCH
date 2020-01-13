using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace wch.bll
{
    public class Classes
    {
        public static void Update(string class_json)
        {
            wchEntities dc = new wchEntities();
            wch_Class model = JsonConvert.DeserializeObject<wch_Class>(class_json);
            wch_Class newClass = dc.wch_Class.SingleOrDefault(a => a.ClassID == model.ClassID);
            newClass.ClassName = model.ClassName;
            newClass.DepID = model.DepID;
            newClass.StuNum = model.StuNum;
            dc.SaveChanges();
        }

        public static void Add(string class_json)
        {
            wchEntities dc = new wchEntities();
            wch_Class model = JsonConvert.DeserializeObject<wch_Class>(class_json);
            dc.wch_Class.Add(model);
            dc.SaveChanges();
        }

        public static void Delete(string id)
        {
            int classid = Convert.ToInt32(id);
            wchEntities dc = new wchEntities();
            wch_Class model = dc.wch_Class.SingleOrDefault(a => a.ClassID == classid);
            dc.wch_Class.Remove(model);
            dc.SaveChanges();
        }
    }
}
