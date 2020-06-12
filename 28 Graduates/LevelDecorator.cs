using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28_Graduates
{
    class LevelDecorator:Decorator
    {
        public LevelDecorator(Student student, string l)
             : base(student.Id, student.Name, student.Education+l, student)
        { }
    }
}
