using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebDinhDuong.Proxy
{

    class CoreProxy:ICore
    {
        int role;
        
        public string getLink()
        {
            if (role == 0)
            {
                Core core = new Core("/ManageFood/Index");
                return core.getLink();
            }           
                Core core2 = new Core("/Home/Index");               
                return core2.getLink();
        }
        public CoreProxy(int role)
        {
            this.role = role;     
        }
      
    }
}