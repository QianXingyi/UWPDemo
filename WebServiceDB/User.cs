using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceDB
{
    public class User
    {
        public int UID { get; set; }
        public string Uname { get; set; }
        public int Uage { get; set; }
        public string Usex { get; set; }
        public string Udate { get; set; }
        public string Password { get; set; }

        public User() { }
        public User(int UID, string Uname,int Uage, string Usex,string Udate)
        {
            this.UID = UID;
            this.Uname = Uname;
            this.Uage = Uage;
            this.Usex = Usex;
            this.Udate = Udate;
            this.Password = Password;
        }
    }
}