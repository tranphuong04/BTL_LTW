using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Qly_Danhba
{
    class Connection
    {
        private static string stringConnection = @"Data Source=DESKTOP-JQG8MM1;Initial Catalog=QLY_DANHBA;Integrated Security=True"; // kết nối CSDL
        public static SqlConnection getConnection()
        {
            return new SqlConnection(stringConnection);
        }
    }
}
