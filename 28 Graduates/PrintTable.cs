using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace _28_Graduates
{
    class PrintTable
    {
        public void Print(Connection conect, string sql)
        {

            SqlDataAdapter adapter = new SqlDataAdapter(sql, conect.Open());

            DataSet dataSet = new DataSet();
            // заповнення об'єкту данними sql результату
            adapter.Fill(dataSet);
            DataTable dt = dataSet.Tables[0];
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            // вивід атрибутів таблиці результату
            foreach (DataColumn column in dt.Columns)
            {
                Console.Write("{0, 15}", column.ColumnName);
            }
            Console.WriteLine();

            // вивід вмісту результуючої таблиці
            foreach (DataRow row in dt.Rows)
            {
                var cells = row.ItemArray;
                foreach (object cell in cells)
                    Console.Write("{0, 15}", cell);
                Console.WriteLine();
            }

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
            conect.Close();
        }
    }
}
