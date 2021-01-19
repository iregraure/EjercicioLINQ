using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo_LINQ
{
    class Relation
    {
        // Atributos
        public Person person1 { get; set; }
        public Person person2 { get; set; }

        // Constructor
        public Relation (Person person1, Person person2)
        {
            this.person1 = person1;
            this.person2 = person2;
        }
    }
}
