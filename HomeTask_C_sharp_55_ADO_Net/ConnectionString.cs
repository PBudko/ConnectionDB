using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_C_sharp_55_ADO_Net
{
   public class ConnectionString
    {
        SqlConnectionStringBuilder Connection = new SqlConnectionStringBuilder();


        public ConnectionString() : this("", "", "")
        { }

        public ConnectionString(string servername, string userid,string password)
        {
            
            Connection.DataSource = servername;
            Connection.UserID = userid;
            Connection.Password = password;
        }


    }
}
