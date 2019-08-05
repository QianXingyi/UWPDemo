using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceDB
{
    public class Chat
    {
        public int ChatID;
        public int DID;
        public int UID;
        public string Comment;
        public Chat() { }
        public Chat(int ChatID, int DID, int UID, string Comment)
        {
            this.ChatID = ChatID;
            this.DID = DID;
            this.UID = UID;
            this.Comment = Comment;
        }
    }
}