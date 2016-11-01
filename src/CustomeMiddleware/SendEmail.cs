using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace CustomeMiddleware
{
    public static class SendEmail
    {
        public static void Send()
        {
            using (var client = new HttpClient())
            {
                //client.
                //    .Connect("smtp.example.com", 587, false);
                //client.AuthenticationMechanisms.Remove("XOAUTH2");
                //// Note: since we don't have an OAuth2 token, disable 	// the XOAUTH2 authentication mechanism.     client.Authenticate("anuraj.p@example.com", "password");
                //client.Send(message);
                //client.Disconnect(true);
            }
        }
    }
}