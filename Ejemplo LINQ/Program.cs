using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace Ejemplo_LINQ
{
    class Program
    {
        private const String PATH = @"C:\Users\Irene\Desktop\Datos.xlsx";   // Cambiar por la ruta del propio equipo
        static void Main(string[] args)
        {
            // Extraemos los datos del Excel
            DataSet datos = ExtractDataSet.extractDataSetFromExcel(PATH);
            // Guardamos cada hoja en un elemento DataTable
            DataTable tablePeople = datos.Tables["Personas"];
            DataTable tableRelations = datos.Tables["Parejas"];
            DataTable tablePets = datos.Tables["Mascotas"];

            // Obtenemos los datos de cada objeto y hacemos una lista con ellos
            var extractedPeople = from row in tablePeople.AsEnumerable()
                                  where row.Table.Rows.IndexOf(row) > 0
                                  select new Person(
                                      int.Parse(row.ItemArray[0].ToString()),
                                      row.ItemArray[1].ToString(),
                                      int.Parse(row.ItemArray[2].ToString()),
                                      row.ItemArray[3].ToString(),
                                      new List<Person>(),
                                      new List<Pet>()
                                      );
            List<Person> people = extractedPeople.ToList();

            var extractedRelations = from row in tableRelations.AsEnumerable()
                                     where row.Table.Rows.IndexOf(row) > 0
                                     select new Relation(
                                         people.Find(p => p.id == int.Parse(row.ItemArray[0].ToString())),
                                         people.Find(p => p.id == int.Parse(row.ItemArray[1].ToString()))
                                         );
            List<Relation> relations = extractedRelations.ToList();

            var extractedPets = from row in tablePets.AsEnumerable()
                                where row.Table.Rows.IndexOf(row) > 0
                                select new Pet(
                                    int.Parse(row.ItemArray[0].ToString()),
                                    row.ItemArray[1].ToString(),
                                    int.Parse(row.ItemArray[2].ToString()),
                                    row.ItemArray[3].ToString(),
                                    int.Parse(row.ItemArray[4].ToString())
                                    );
            List<Pet> pets = extractedPets.ToList();

            // Añadimos a las personas sus relaciones y mascotas
            Utils.addRelations(relations);
            Utils.addPets(people, pets);

            // Mostramos el menú y llamamos al método correspondiente
            int op = -1;
            do
            {
                Console.WriteLine("Elije una de las siguientes opciones: ");
                Console.WriteLine("1. Mostrar las parejas de una persona");
                Console.WriteLine("2. Mostrar las parejas de una persona y sus mascotas");
                Console.WriteLine("3. Mostrar las mascotas de las personas que no tienen parejas");
                Console.WriteLine("4. Mostrar las mascotas de una persona y sus parejas");
                Console.WriteLine("5. Salir del programa");
                try
                {
                    op = int.Parse(Console.ReadLine());
                    switch (op)
                    {
                        case 1:
                            Queries.ejer1(people);
                            break;
                        case 2:
                            Queries.ejer2(people);
                            break;
                        case 3:
                            Queries.ejer3(people);
                            break;
                        case 4:
                            Queries.ejer4(people);
                            break;
                        case 5:
                            Console.WriteLine("Saliendo del programa...");
                            break;
                        default:
                            Console.WriteLine("Has introducido una opción incorrecta");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Tienes que introducir un número");
                }
            } while (op != 5);
        }
    }
}
