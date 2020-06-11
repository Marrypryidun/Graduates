using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace _28_Graduates
{
    class Connection
    {
        public SqlConnection Connect { get; set; }

        public Connection()
        {
            Connect =
                new SqlConnection(
            //  @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\rozum\OneDrive\Desktop\c#\exam\exam\Database1.mdf;Integrated Security=True");
            // @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = E:\2 курс\C#\Підготовка до кр\exam\exam\Database1.mdf; Integrated Security = True");
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\2 курс\C#\Підготовка до кр\28 Graduates\28 Graduates\Graduates.mdf;Integrated Security=True");
        }

        public SqlConnection Open()
        {
            try
            {
                Connect.Open();
                Console.WriteLine("Connection open");
                return Connect;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public void Close()
        {
            Connect.Close();
            Console.WriteLine("Connection close");
        }
    }
}
