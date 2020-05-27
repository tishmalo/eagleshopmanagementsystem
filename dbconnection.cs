using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopsystem
{
    class dbconnection
    {
        public string MyConnection()
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tishm\OneDrive\Desktop\eagleshiet10001\shopsystem\mercy.mdf;Integrated Security=True";
            return con;
        }

    }
}
