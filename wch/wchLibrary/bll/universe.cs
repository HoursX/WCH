using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wch.bll
{
    public class universe
    {
        public static List<wch.wch_Department> getDepartment()
        {
            wchEntities dc = new wchEntities();
            return dc.wch_Department.ToList();
        }

        //public static  getClass()
        //{
        //    wchEntities dc = new wchEntities();
        //    var list = (from p in dc.wch_Class
        //                                select new
        //                                    {
        //                                        ClassID = p.ClassID,
        //                                        ClassName = p.ClassName
        //                                    });
        //    return list;
        //}

        public static List<wch.wch_Login> getUser()
        {
            wchEntities dc = new wchEntities();
            return dc.wch_Login.ToList();
        }

        public static List<wch.wch_Term> getTerm()
        {
            wchEntities dc = new wchEntities();
            return dc.wch_Term.ToList();
        }

        public static List<wch.wch_Theatre> getTheatre()
        {
            wchEntities dc = new wchEntities();
            return dc.wch_Theatre.ToList();
        }
    }
}
