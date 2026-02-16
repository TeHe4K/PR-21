using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konevskii_PR21.Classes.Common
{
    public class DBConnection
    {
        public static readonly string Parh = @"Bin\Debug\DataBase\Database.accdb";

        public static OleDbConnection Connection()
        {
            OleDbConnection oleDbConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Parh);

            oleDbConnection.Open();
            return oleDbConnection;
        }

        public static OleDbDataReader Query(string Query, OleDbConnection Connection)
        {
            return new OleDbCommand(Query, Connection).ExecuteReader();
        }

        public static void CloseConnection(OleDbConnection oleDbConnection)
        {
            oleDbConnection.Close();
        }
    }
}
