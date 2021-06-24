using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDinhDuong.Proxy
{
    class Core:ICore
    {
        private string link;
       // private int role;
        public string getLink()
        {
            return this.link;
        }
        public Core(string link)
        {
            this.link = link;
        }
    }
}