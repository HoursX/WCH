using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using wch.lib;

namespace wch.bll
{
    public class user
    {
        public static void Update(string user_json, string photoPath)
        {
            wchEntities dc = new wchEntities();
            wch_Login model = JsonConvert.DeserializeObject<wch_Login>(user_json);
            wch_Login user = dc.wch_Login.SingleOrDefault(a => a.UserID == model.UserID);
            user.AllowLogin = model.AllowLogin;
            user.Identity = model.Identity;
            user.Nickname = model.Nickname;
            user.Passwd = DBHelper.GenerateMD5(model.Passwd);
            user.PhotoPath = photoPath;
            dc.SaveChanges();
        }

        public static void Delete(string userid)
        {
            wchEntities dc = new wchEntities();
            wch_Login user = dc.wch_Login.SingleOrDefault(a => a.UserID == userid);
            dc.wch_Login.Remove(user);
            dc.SaveChanges();
        }
        public static void Load()
        {
            //load stu
            wchEntities dc = new wchEntities();
            List<string> useridList = (from p in dc.wch_Login select p.UserID).ToList();
            List<string> newList = (from p in dc.wch_Student
                where (!useridList.Contains(p.StuID))
                select p.StuID).ToList();

            foreach (var s in newList)
            {
                wch_Login model = new wch_Login()
                {
                    UserID = s,
                    Passwd = wch.lib.DBHelper.GenerateMD5("123456"),
                    Identity = 3,
                    Nickname = "Student",
                    PhotoPath = "/upload/head.xsm.jpg",
                    AllowLogin = true,
                };
                dc.wch_Login.Add(model);
                dc.SaveChanges();
            }



            List<string> uuseridList = (from p in dc.wch_Login select p.UserID).ToList();
            List<string> unewList = (from p in dc.wch_Teacher
                where (!uuseridList.Contains(p.TeaID))
                select p.TeaID).ToList();

            foreach (var s in unewList)
            {
                wch_Login model = new wch_Login()
                {
                    UserID = s,
                    Passwd = wch.lib.DBHelper.GenerateMD5("123456"),
                    Identity = 2,
                    Nickname = "Teacher",
                    PhotoPath = "/upload/head.xsm.jpg",
                    AllowLogin = true,
                };
                dc.wch_Login.Add(model);
                dc.SaveChanges();
            }


        }
    }
}
