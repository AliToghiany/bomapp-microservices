using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_lib.Utitlities
{
    public static class ServerUtilities
    {
        public static string GATEWAYURL = "http://localhost:5050";
        public static bool CheckForInternetConnection(int timeoutMs = 10000)
        {
            try
            {
               

                var request = (HttpWebRequest)WebRequest.Create(GATEWAYURL);
                request.KeepAlive = false;
                request.Timeout = timeoutMs;
                using (var response = (HttpWebResponse)request.GetResponse())
                    return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
