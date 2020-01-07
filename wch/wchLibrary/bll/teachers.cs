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
    }
}
