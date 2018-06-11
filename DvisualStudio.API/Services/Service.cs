﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DvisualStudio.API.Services
{
    public abstract class Service
    {
        protected const string APIKey = "AIzaSyBeFMfHbCI8R_-f2b4Yae-9CBDDHIut94o";
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
