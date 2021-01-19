using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo_LINQ
{
    class Person
    {
        // Atributos
        public int id { get; set; }
        public String name { get; set; }
        public int age { get; set; }
        public String gender { get; set; }
        public List<Person> relations { get; set; }
        public List<Pet> pets { get; set; }

        // Constructor
        public Person (int id, String name, int age, String gender, List<Person> relations, List<Pet> pets)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.relations = relations;
            this.pets = pets;
        }

        // Método toString
        public String toString()
        {
            String resul = "ID: " + this.id + " - Nombre: " + this.name + " - Edad: " + this.age + " - Genero: " + this.gender;
            return resul;
        }
    }
}
