using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceDB
{
    public class Device
    {
        public int DID { get; set; }
        public string Dname { get; set; }
        public string Dintroduction { get; set; }
        public int Dappearance { get; set; }
        public Device() { }
        public Device(int DID, string Dname, string Dintroduction, int Dappearance)
        {
            this.DID = DID;
            this.Dname = Dname;
            this.Dintroduction = Dintroduction;
            this.Dappearance = Dappearance;
        }
    }
   


}