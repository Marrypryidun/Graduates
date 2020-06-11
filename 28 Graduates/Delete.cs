using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace _28_Graduates
{
    class Delete
    {
        public void DeleteStudent(Connection conect, int id)
        {
            string sqlExpression = "SELECT MAX(Id) FROM Student";
            SqlCommand command1 = new SqlCommand(sqlExpression, conect.Open());
            object max = command1.ExecuteScalar();
            conect.Close();
            if (id <= Convert.ToInt32(max))
            {
                SqlCommand command = new SqlCommand("DELETE FROM Student WHERE Id = @id", conect.Open());
                command.Parameters.Add(new SqlParameter("@id", id.ToString()));
                int number = command.ExecuteNonQuery();
                Console.WriteLine("Deleted student: {0}", number);
                conect.Close();
            }
            else
                Console.WriteLine("Entered id not valid.");

        }
    }
}
