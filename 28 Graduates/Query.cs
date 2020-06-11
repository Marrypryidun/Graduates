using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace _28_Graduates
{
    class Query
    {
        public void Query1(Connection conect, string n)
        {
            SqlCommand command = new SqlCommand("SELECT Student.Id, Student.Name " +
                "FROM Student " +
                "INNER JOIN Graduates ON Student.Id = Graduates.StudentId " +
                "WHERE DATEPART(year, Graduates.EndDate) = '2018' AND Graduates.Speciality = @n", conect.Open());
            command.Parameters.Add(new SqlParameter("@n", n));
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine("{0}\t{1}", reader.GetName(0), reader.GetName(1));

                while (reader.Read()) // построчно считываем данные
                {

                    object Id = reader.GetValue(0);
                    object name = reader.GetValue(1);


                    Console.WriteLine("{0}\t{1}", Id, name);
                }
            }

            reader.Close();
            conect.Close();
        }
        public void Query2(Connection conect, string f)
        {
            SqlCommand command = new SqlCommand("SELECT Jobs.Position, COUNT(Jobs.Position) AS Number  FROM Jobs  " +
                "INNER JOIN  " +
                "(SELECT Student.Id, Graduates.Faculty " +
                "FROM  Student INNER JOIN Graduates ON  Student.Id = Graduates.StudentId " +
                "WHERE Graduates.Faculty = 'FIOT' " +
                "GROUP BY Student.Id, Graduates.Faculty) AS S " +
                "ON Jobs.StudentId = S.Id " +
                "GROUP BY Jobs.Position " +
                "HAVING COUNT(Jobs.Position) >= ALL( " +
                "SELECT  COUNT(Jobs.Position)  FROM Jobs " +
                "INNER JOIN " +
                "(SELECT Student.Id, Graduates.Faculty " +
                "FROM  Student INNER JOIN Graduates ON  Student.Id = Graduates.StudentId " +
                "WHERE Graduates.Faculty = @f " +
                "GROUP BY Student.Id, Graduates.Faculty) AS S " +
                "ON Jobs.StudentId = S.Id " +
                "GROUP BY Jobs.Position)", conect.Open());
            command.Parameters.Add(new SqlParameter("@f", f));
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine("{0}\t{1}", reader.GetName(0), reader.GetName(1));

                while (reader.Read()) // построчно считываем данные
                {

                    object position = reader.GetValue(0);
                    object number = reader.GetValue(1);


                    Console.WriteLine("{0}\t{1}", position, number);
                }
            }

            reader.Close();
            conect.Close();
        }
       
//    public void Query3Connection conect, string f)
//        {
//            SqlCommand command = new SqlCommand(" SELECT Jobs.PositionFROM Student
//INNER JOIN Graduates ON Student.Id = Graduates.StudentId
//INNER JOIN Jobs ON Student.Id = Jobs.StudentId
//WHERE Graduates.Level = 'Master' AND Graduates.Kafedra = 'asoiu' AND Graduates.EndDate < '20200628'
//GROUP By Jobs.Position", conect.Open());
//            command.Parameters.Add(new SqlParameter("@f", f));
//            SqlDataReader reader = command.ExecuteReader();
//            if (reader.HasRows) // если есть данные
//            {
//                // выводим названия столбцов
//                Console.WriteLine("{0}\t{1}", reader.GetName(0), reader.GetName(1));

//                while (reader.Read()) // построчно считываем данные
//                {

//                    object position = reader.GetValue(0);
//                    object number = reader.GetValue(1);


//                    Console.WriteLine("{0}\t{1}", position, number);
//                }
//            }

//            reader.Close();
//            conect.Close();
//        }
    }
}
