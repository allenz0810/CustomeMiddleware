using System;
using System.Collections.Generic;
using System.Linq;


namespace CustomeMiddleware
{
    public class Email
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Domain { get; set; }
        public string Uri { get; set; }
        public int port { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public byte[] Attchment { get; set; }
    }
}
