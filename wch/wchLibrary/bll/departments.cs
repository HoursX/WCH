using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wch.bll
{
    public class departments
    {
        public static void Add(string dep_json)
        {
            wchEntities dc = new wchEntities();
            wch_Department model = JsonConvert.DeserializeObject<wch_Department>(dep_json);
            dc.wch_Department.Add(model);
            dc.SaveChanges();
        }
        public static void Delete(string id)
        {
            wchEntities dc = new wchEntities();
            int s = Convert.ToInt32(id);
            wch.wch_Department entry = dc.wch_Department.SingleOrDefault(a => a.DepID == s);
            dc.wch_Department.Remove(entry);
            dc.SaveChanges();
        }
        public static void Update(string dep_json)
        {
            wchEntities dc = new wchEntities();
            wch_Department model = JsonConvert.DeserializeObject<wch_Department>(dep_json);
            wch_Department dep = dc.wch_Department.SingleOrDefault(a => a.DepID == model.DepID);
            dep.DepName = model.DepName;
            dc.SaveChanges();
        }
    }
}
