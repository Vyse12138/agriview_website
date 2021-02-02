using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agriview_website
{
    interface IService
    {
        void WriteLog();
        bool DBCacgeAccess(Nancy.Request req, DateTime lastmodified);
    }
}
