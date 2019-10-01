using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET.W._2019.Khadasevich._24._01.Handlers
{
    public class InfoHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string result = "<p>Hello! You IP: " + context.Request.UserHostAddress + "</p>";
            context.Response.Write(result);
        }
        public bool IsReusable
        {
            get { return false; }
        }
    }
}