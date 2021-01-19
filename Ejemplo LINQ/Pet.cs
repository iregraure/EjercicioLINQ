using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo_LINQ
{
    class Pet
    {
        // Atributos
        public int id { get; set; }
        public String name { get; set; }
        public int age { get; set; }
        public String gender { get; set; }
        public int ownerId { get; set; }

        public Pet(int id, String name, int age, String gender, int ownerId)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.ownerId = ownerId;
        }

        // Método toString
        public String toString()
        {
            String resul = "ID: " + this.id + " - Nombre: " + this.name + " - Edad: " + this.age + " - Genero: " + this.gender;
            return resul;
        }
    }
}
