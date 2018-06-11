using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DvisualStudio.API.Services
{
    public abstract class Service
    {
        protected const string APIKey = "AIzaSyCvYP9JLWZnivOdfQb4NX8474z4KYmYXmw";
        public string BuildUrl(string baseUrl, IDictionary<string, string> parameters)
        {
            var sb = new StringBuilder(baseUrl); 
            if (parameters?.Count > 0)
            {
                sb.Append('?');
                foreach (var p in parameters)
                {
                    sb.Append(p.Key);
                    sb.Append("=");
                    sb.Append(WebUtility.UrlEncode(p.Value));
                    sb.Append('&');
                }
                sb.Remove(sb.Length - 1, 1);
            }
            return sb.ToString();
        }
    }
}
