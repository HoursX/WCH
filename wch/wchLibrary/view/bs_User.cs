using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wch.view
{
    public class bs_User
    {
        public bs_User() 
        {
            userID = "";
            nickName = "";
        }
        public string userID { get; set; }
        public string nickName { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int rowCount { get; set; }
        public IEnumerable<wch.wch_Login> showData { get; set; }
        public wch.wch_Login entry { get; set; }
        public void search()
        {
            wchEntities dc = new wchEntities();
            var data = from a in dc.wch_Login select a;
            if (userID != "")
            {
                data = from a in data where a.UserID.Contains(userID) select a;
            }
            if (nickName != "")
            {
                data = from a in data where a.Nickname.Contains(nickName) select a;
            }
            this.rowCount = data.Count();
            data = (from a in data orderby a.UserID select a).Skip(pageIndex * pageSize).Take(pageSize);

            showData = data.ToList();
        }
    }
}
