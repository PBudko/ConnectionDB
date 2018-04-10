using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_C_sharp_55_ADO_Net
{
    public class ServerName
    {
       public string servername { get; set; }

        public ServerName(string nameserver)
        {
            if(nameserver!=null || nameserver!="")
            servername = nameserver;
        }

        public override string ToString()
        {
            return servername;
        }
    }
}
