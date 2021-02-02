using Nancy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Caching;
namespace agriview_website
{
    public class Service1 : IService
    {
        public void WriteLog()
        {
            Console.WriteLine(123);
        }
        public bool DBCacgeAccess(Nancy.Request req, DateTime lastmodified)
        {
            //Trace.WriteLine(req.Headers.IfModifiedSince.Value);
            //Trace.WriteLine(lastmodified);
            if (!req.Headers.IfModifiedSince.HasValue)
            {
                Trace.WriteLine("IfModifiedSince does not have a value");
                foreach( var aa in req.Headers.Keys)
                {
                    Trace.WriteLine(aa);
                    
                }
                return false;
            }
            if (req.Headers.IfModifiedSince.Value.ToString() == lastmodified.ToString())
            {
                Trace.WriteLine("not modified");
                return true;
            }
            Trace.WriteLine("modified");
            return false;
        }
    }

}