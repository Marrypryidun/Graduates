using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28_Graduates
{
    abstract class Decorator : Student
    {
        protected Student student;

        public Decorator(int id, string name, string education,  Student student) : base(id, name, education)
        {
            this.student = student;
        }
    }
}
