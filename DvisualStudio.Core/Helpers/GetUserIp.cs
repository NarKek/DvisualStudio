using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DvisualStudio.Core.Helpers
{
    public static class GetUserIp
    {
        public static string GetIp() 
            //from https://stackoverflow.com/questions/25132356/get-user-ip-address
        {

            string strHostName = "";
            strHostName = Dns.GetHostName(); 

            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);

            string ipaddress = Convert.ToString(ipEntry.AddressList[2]);

            return ipaddress;
        }
    }
}
