using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace _28_Graduates
{
    class Read
    {
        public void readStudent(Connection connection)
        {

            string sqlExpression = "SELECT Student.Id,Student.Name, Graduates.Faculty,Graduates.Kafedra,Graduates.Speciality,Graduates.Level " +
                "FROM Student LEFT JOIN Graduates ON Student.Id = Graduates.StudentId ORDER BY Student.Name";
            SqlCommand command = new SqlCommand(sqlExpression, connection.Open());
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                //Console.WriteLine("{0}\t{1}", reader.GetName(0), reader.GetName(1));
                int i = 0;
                string pr = "";
                Student stud = new Student();
                while (reader.Read()) // построчно считываем данные
                {


                    object id = reader.GetValue(0);
                    object name = reader.GetValue(1);
                    object faculty = reader.GetValue(2);
                    object kafedra = reader.GetValue(3);
                    object speciality = reader.GetValue(4);
                    object level = reader.GetValue(5);
                    if (i == 0)
                    {
                        pr = name.ToString();
                        stud = new Student(Convert.ToInt32(id),pr, level.ToString() + ": " + faculty.ToString()+ ", " + kafedra.ToString() + ", " + speciality.ToString() + " ");
                    }
                    else if (pr == name.ToString())
                    {
                        stud = new LevelDecorator(stud, level.ToString() + ": " + faculty.ToString() + ", " + kafedra.ToString() + ", " + speciality.ToString() + " ");
                    }
                    else
                    {
                        Console.WriteLine("Id: {0} Name: {1}, Education: {2} ", stud.Id, stud.Name,stud.Education);
                        pr = name.ToString();
                        stud = new Student(Convert.ToInt32(id), pr, level.ToString() + ": " + faculty.ToString() + ", " + kafedra.ToString() + ", " + speciality.ToString() + " ");
                    }
                    i++;
                }
            }

            reader.Close();
            connection.Close();
        }
    }
}

