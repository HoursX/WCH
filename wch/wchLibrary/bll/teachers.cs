using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wch.bll
{
    public class teachers
    {
        public static void Delete(string id)
        {
            wchEntities dc = new wchEntities();
            wch.wch_Teacher entry = dc.wch_Teacher.SingleOrDefault(a => a.TeaID == id);
            dc.wch_Teacher.Remove(entry);
            dc.SaveChanges();
        }
        public static void Add(string tea_json)
        {
            wchEntities dc = new wchEntities();
            wch_Teacher model = JsonConvert.DeserializeObject<wch_Teacher>(tea_json);
            dc.wch_Teacher.Add(model);
            dc.SaveChanges();
        }
        public static void Update(string tea_json)
        {
            wchEntities dc = new wchEntities();
            wch_Teacher model = JsonConvert.DeserializeObject<wch_Teacher>(tea_json);
            wch_Teacher tea = dc.wch_Teacher.SingleOrDefault(a => a.TeaID == model.TeaID);
            tea.TeaName = model.TeaName;
            tea.Gender = model.Gender;
            tea.DepID = model.DepID;
            tea.TeaAge = model.TeaAge;
            tea.Tel = model.Tel;
            tea.Address = model.Address;
            dc.SaveChanges();
        }
    }
}
