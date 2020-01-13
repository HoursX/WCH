using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace wch.bll
{
    public class Terms
    {
        public static void Update(string trem_json)
        {
            wchEntities dc = new wchEntities();
            wch_Term model = JsonConvert.DeserializeObject<wch_Term>(trem_json);
            if ((model.StartTime > model.EndTime) || (model.StartChoice > model.EndChoice))
            {
                throw new Exception();
            }
            wch_Term newTerm = dc.wch_Term.SingleOrDefault(a => a.TermID == model.TermID);
            newTerm.TermName = model.TermName;
            newTerm.StartTime = model.StartTime;
            newTerm.EndTime = model.EndTime;
            newTerm.StartChoice = model.StartChoice;
            newTerm.EndChoice = model.EndChoice;
            dc.SaveChanges();
        }

        public static void Add(string trem_json)
        {
            wchEntities dc = new wchEntities();
            wch_Term model = JsonConvert.DeserializeObject<wch_Term>(trem_json);
            if ((model.StartTime > model.EndTime) || (model.StartChoice > model.EndChoice))
            {
                throw new Exception();
            }
            dc.wch_Term.Add(model);
            dc.SaveChanges();
        }

        public static void Delete(string id)
        {
            int termid = Convert.ToInt32(id);
            wchEntities dc = new wchEntities();
            wch_Term model = dc.wch_Term.SingleOrDefault(a => a.TermID == termid);
            dc.wch_Term.Remove(model);
            dc.SaveChanges();
        }
    }
}
