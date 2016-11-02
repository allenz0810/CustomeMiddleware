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

        //public void Connect(string server, string UserName, string Password)
        //{
        //    try
        //    {
        //        if (_isConnected)
        //        {
        //            return;
        //        }
        //        if (!UseSSL)
        //        {
        //            Connect(server, PortNumber);
        //            string response = Response();
        //            if (!response.Trim().StartsWith("+OK"))
        //            {
        //                //TODO: Raise Error Event
        //            }
        //            else
        //            {
        //                ExecuteCommand("USER", UserName);
        //                ExecuteCommand("PASS", Password);
        //            }
        //            _isConnected = true;
        //        }
        //        else
        //        {
        //            byte[] bts;
        //            int res;
        //            string responseString = "";
        //            ResponseList.Clear();
        //            Connect(server, PortNumber);
        //            inStream = new SslStream(this.GetStream(), false,
        //               new RemoteCertificateValidationCallback(ValidateServerCertificate),
        //                new LocalCertificateSelectionCallback(SelectLocalCertificate));
        //            inStream.AuthenticateAsClient(server);
        //            bts = new byte[1024];
        //            res = inStream.Read(bts, 0, bts.Length);
        //            ResponseList.Add(Encoding.ASCII.GetString(bts, 0, res));
        //            responseString = ExecuteCommand("USER", UserName);
        //            ResponseList.Add(responseString);
        //            responseString = ExecuteCommand("PASS", Password);
        //            ResponseList.Add(responseString);
        //            if (!responseString.Trim().StartsWith("+OK"))
        //            {
        //                //TODO: Raise Error Event
        //            }
        //            else
        //                _isConnected = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //TODO: Raise Error Event
        //    }
        //}
    }
}