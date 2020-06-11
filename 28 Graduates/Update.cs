using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace _28_Graduates
{
    class Update
    {
        public void UpdateAmoutProduction(Connection conect, int id, string a)
        {
            string sqlExpression = "SELECT MAX(Id) FROM Graduates";
            SqlCommand command = new SqlCommand(sqlExpression, conect.Open());
            object max = command.ExecuteScalar();
            conect.Close();
            if (id <= Convert.ToInt32(max))
            {
                command = new SqlCommand("UPDATE  Graduates SET Kafedra = @a WHERE StudentId = @id", conect.Open());
                command.Parameters.Add(new SqlParameter("@a", a));
                command.Parameters.Add(new SqlParameter("@id", id));
                int number = command.ExecuteNonQuery();
                Console.WriteLine("Updated object: {0}", number);
            }
            else
                Console.WriteLine("Entered id not valid.");
            conect.Close();

        }
    }
}
