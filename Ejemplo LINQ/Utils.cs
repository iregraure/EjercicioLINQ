using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo_LINQ
{
    class Utils
    {
        // Métodos que añade relaciones a las personas
        public static void addRelations (List<Relation> relations)
        {
            foreach(Relation r in relations)
            {
                r.person1.relations.Add(r.person2);
                r.person2.relations.Add(r.person1);
            }
        }

        // Método que añade mascotas a las personas
        public static void addPets(List<Person> people, List<Pet> pets)
        {
            foreach(Person p in people)
            {
                p.pets.AddRange(pets.Where(pet => pet.ownerId == p.id));
            }
        }

        // Nétodo que pide id y comprueba que sea correcto
        public static int compruebaId(List<Person> people, List<String> logs) 
        {
            // Variable para guardar el id introducido
            int idPersona = -1;

            while(idPersona == -1)
            {
                try
                {
                    Console.Write("Introduce el id de la persona: ");
                    idPersona = Convert.ToInt32(Console.ReadLine());
                    if (idPersona <= 0 || idPersona > people.Count)
                    {
                        idPersona = -1;
                        Console.WriteLine("Id no válido");
                        logs.Add("Id no válido");
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("Id no válido, tienes que insertar un número entero positivo");
                    logs.Add("Id no válido, tienes que insertar un número entero positivo");
                }
            }
            return idPersona;
        }

        // Método que crea un fichero con el contenido de la lista de logs
        public static void creaFicheroLogs (List<String> logs, String logFolder)
        {
            Console.WriteLine("Guardando logs...");
            String date = DateTime.Now.ToString();
            date = date.Replace(" ", "_");
            date = date.Replace("/", "-");
            date = date.Replace(":", "-");
            String path = logFolder + date + "Log.txt";
            File.WriteAllLines(path, logs);

            Console.ReadKey();
            Console.Clear();
        }

        // Método que muestra un mensaje por consola y lo añade a los log
        public static void muestraMensaje(String mensaje, List<String> logs)
        {
            Console.WriteLine(mensaje);
            logs.Add(mensaje);
        }
    }
}
