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
                Console.WriteLine("7. Display products for a certain group that has the specified parameters.");
                Console.WriteLine("8. Production with parameters which were produced in the last quarter.");


                string ch = Console.ReadLine();
                switch (ch)
                {
                    //case "1":
                    //    Read r = new Read();
                    //    r.readProduct(conect);
                    //    Console.ReadLine();
                    //    Console.Clear();
                    //    break;
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
                        Console.WriteLine("Enter id of parameters that not existed in product: ");
                        string p = Console.ReadLine();
                        q.Query2(conect, p);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    //case "7":
                    //    print.Print(conect, "SELECT * FROM GroupsParameters");
                    //    Console.WriteLine("Enter id of group: ");
                    //    int g = Convert.ToInt32(Console.ReadLine());
                    //    q.Query3(conect, g);
                    //    Console.ReadLine();
                    //    Console.Clear();
                    //    break;
                    //case "8":
                    //    print.Print(conect, "SELECT Production.Name, Parameters.Name, ValuesProductionParameters.Value FROM ValuesProductionParameters " +
                    //        "INNER JOIN Production ON ValuesProductionParameters.ProductionId = Production.Id INNER JOIN Parameters ON ValuesProductionParameters.ParameterId = Parameters.Id" +
                    //        " WHERE  Production.ReleaseDate >= '20200101' AND Production.ReleaseDate < '20200501'");
                    //    Console.ReadLine();
                    //    Console.Clear();
                    //    break;
                    //case "9":
                    //    print.Print(conect, "SELECT Enterprises.Id, Enterprises.Name, (Enterprises.HomelessPeople * 100) / Enterprises.NumberWorkpeople as PrecentHomeless,(Enterprises.HomeProblemPeople * 100) / Enterprises.NumberWorkpeople as PrecentProblem  " +
                    //         "FROM Enterprises " +
                    //         "WHERE((Enterprises.HomelessPeople * 100) / Enterprises.NumberWorkpeople) > ((Enterprises.HomeProblemPeople* 100) / Enterprises.NumberWorkpeople)");
                    //    Console.ReadLine();
                    //    Console.Clear();
                    //    break;

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
