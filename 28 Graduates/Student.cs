using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28_Graduates
{
    class Student
    {
        int id;
        string name;
        string education;
    

        public Student()
        {
            this.education ="";
 
        }
        public Student(int id, string name, string education)
        {
            this.id = id;
            this.name = name;
            this.education = education;
           
        }
        public int Id
        {
            get
            { return id; }
            set
            { id = value; }
        }
        public string Name
        {
            get
            { return name; }
            set
            { name = value; }
        }
        public string Education
        {
            get
            { return education; }
            set
            { education = value; }
        }
       
    }
}
