using System;
using System.Collections.Generic;
using System.Linq;


namespace CustomeMiddleware
{
    public class Email
    {
        public string From { get; set; }
        public string To { get; set; }
        public string url { get; set; }
        public string port { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public byte[] Attchment { get; set; }
    }
}
