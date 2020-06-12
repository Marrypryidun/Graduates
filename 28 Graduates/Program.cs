using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28_Graduates
{
    class Program
    {
        static void Main(string[] args)
        {
            Connection conect = new Connection();
            Query q = new Query();
            PrintTable print = new PrintTable();
            while (true)
            {

                Console.WriteLine("Menu");
                Console.WriteLine("1. Display the table of teachers and subjects using objects.");
                Console.WriteLine("2. Display all tables.");
                Console.WriteLine("3. Deduct the student.");
                Console.WriteLine("4. Change the department for a student.");
                Console.WriteLine("5. Display all graduates who graduated with a bachelor's degree in certain specialty 2 years ago .");
                Console.WriteLine("6. Display  the positions in which the largest number of graduates of a certain faculty works.");
                Console.WriteLine("7. Display  jobs of graduates of masters of a certain department for a certain period.");
                Console.WriteLine("8. Display graduates who have changed jobs more than 4 times.");
                Console.WriteLine("9. Display the years and specialties where there was the largest number of graduates.");


                string ch = Console.ReadLine();
                switch (ch)
                {
                    case "1":
                        Read r = new Read();
                        r.readStudent(conect);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "2":

                        print.Print(conect, "SELECT * FROM Student");
                        print.Print(conect, "SELECT * FROM Graduates");
                        print.Print(conect, "SELECT * FROM Jobs");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "3":
                        print.Print(conect, "SELECT * FROM Student");
                        Console.WriteLine("Enter id of student you want to delete");
                        int a = Convert.ToInt32(Console.ReadLine());
                        Delete del = new Delete();
                        del.DeleteStudent(conect, a);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "4":
                        Update change = new Update();
                        print.Print(conect, "SELECT * FROM Student INNER JOIN Graduates ON Student.Id=Graduates.StudentId");
                        Console.WriteLine("Enter id of student you want to change department:");
                        int au = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter new department:");
                        string na = Console.ReadLine();
                        change.UpdateAmoutProduction(conect, au, na);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "5":
                        print.Print(conect, "SELECT Speciality  FROM Graduates GROUP BY Speciality");
                        Console.WriteLine("Enter name of specialyty:");
                        string np = Console.ReadLine();
                        q.Query1(conect, np);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "6":
                        print.Print(conect, "SELECT Faculty FROM Graduates GROUP BY Faculty");
                        Console.WriteLine("Enter name of faculty ");
                        string p = Console.ReadLine();
                        q.Query2(conect, p);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "7":
                        print.Print(conect, "SELECT Kafedra FROM Graduates GROUP BY Kafedra");
                        Console.WriteLine("Enter name of kafedra:");
                        string k = Console.ReadLine();
                        DateTime first = new DateTime();
                        Console.WriteLine("Enter first date of period in format 20/06/2001:");
                        first = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Enter second date of period 2/06/2020:");
                        DateTime second = Convert.ToDateTime(Console.ReadLine());
                        q.Query3(conect, k,first,second);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "8":
                        print.Print(conect, "SSELECT Student.Name,COUNT(Jobs.Position) FROM Student INNER JOIN Jobs ON Student.Id = Jobs.StudentId GROUP BY Student.Name HAVING COUNT(Jobs.Position) > 4'");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "9":
                        print.Print(conect, "SELECT Graduates.Speciality, DATEPART(year,Graduates.EndDate),COUNT(*) FROM Student INNER JOIN Graduates ON Student.Id = Graduates.StudentId GROUP BY Graduates.Speciality, DATEPART(year, Graduates.EndDate)");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    default:
                        {
                            Console.WriteLine("Error! Enter an existing menu item.");
                            Console.ReadLine();
                            break;
                        }
                }

            }

        }
    }
}
