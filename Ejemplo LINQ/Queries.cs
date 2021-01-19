using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo_LINQ
{
    class Queries
    {
        private const String logFolder = @"C:\Users\Irene\source\repos\Ejemplo LINQ\logs\";     // Cambiar por la ruta del propio equipo
        // 1. Mostrar las parejas de una persona
        internal static void ejer1(List<Person> people)
        {
            // Variable para guardar el id de la persona cuyas parejas queremos mostrar
            int idPersona;
            // Lista de String para mantener un log de lo que hace la aplicación
            List<String> logs = new List<String>();

            logs.Add("EJERCICIO 1: Mostrar las parejas de una persona");

            // Pedimos el id y comprobamos que sea válido
            idPersona = Utils.compruebaId(people, logs);

            // Queries para obtener las parejas de la persona indicada y su nombre
            var relationsQuery = from p in people.AsEnumerable()
                                 where p.id == idPersona
                                 select p.relations;
            var nameQuery = from p in people
                            where p.id == idPersona
                            select p.name;


            // Mostrar los resultados
            Console.Clear();
            foreach (List<Person> partners in relationsQuery)
            {
                if (partners.Count() != 0)
                {
                    Utils.muestraMensaje("Lista de parejas de " + nameQuery.First(), logs);
                    foreach (Person p in partners)
                    {
                        Utils.muestraMensaje(p.toString(), logs);
                    }
                }
                else
                {
                    Utils.muestraMensaje("No se han encontrado parejas para " + nameQuery.First(), logs);
                }
            }

            // Guardar el contenido de la variable logs en un fichero
            Utils.creaFicheroLogs(logs, logFolder);

        }

        // 2. Mostrar las parejas de una persona y sus mascotas
        internal static void ejer2(List<Person> people)
        {
            // Variable para guardar el id de la persona
            int idPersona;
            // Variable para guardar los logs
            List<String> logs = new List<String>();

            logs.Add("EJERCICIO 2: Mostrar las parejas de una persona y sus mascotas");

            // Pedimos el id y comprobamos que sea válido
            idPersona = Utils.compruebaId(people, logs);

            // Queries para obtener las aparejas de la persona indicada y su nombre
            var relationsQuery = from p in people.AsEnumerable()
                                 where p.id == idPersona
                                 select p.relations;
            var nameQuery = from p in people
                            where p.id == idPersona
                            select p.name;

            // Mostrar los resultados
            Console.Clear();
            foreach (List<Person> partners in relationsQuery)
            {
                if (partners.Count() != 0)
                {
                    Utils.muestraMensaje("Lista de parejas de " + nameQuery.First(), logs);
                    foreach (Person p in partners)
                    {
                        if (p.pets.Count != 0)
                        {
                            Utils.muestraMensaje(p.toString() + ". Sus mascotas son:", logs);
                            foreach (Pet pet in p.pets)
                            {
                                Utils.muestraMensaje("\t" + pet.toString(), logs);
                            }
                        }
                        else
                        {
                            Utils.muestraMensaje(p.toString() + "\n\tSin mascotas", logs);
                        }
                    }
                }
                else
                {
                    Utils.muestraMensaje("No se han encontrado parejas para " + nameQuery.First(), logs);
                }
            }

            // Guardar el contenido de la variable logs en un fichero
            Utils.creaFicheroLogs(logs, logFolder);
        }

        // 3. Mostrar las mascotas de las personas que no tienen parejas
        internal static void ejer3(List<Person> people)
        {
            // Variable para mantener un log de lo que hace la aplicación
            List<String> logs = new List<String>();

            logs.Add("EJERCICIO 3: Mostrar las mascotas de las personas que no tienen parejas");

            // Query para obtener las personas que no tienen parejas
            var relationsQuery = from p in people.AsEnumerable()
                                 where p.relations.Count == 0
                                 select p.pets;

            // Recorremos la lista de personas y si no tienen pareja mostramos sus mascotas
            Console.Clear();
            foreach (List<Pet> pets in relationsQuery)
            {
                var nameQuery = from p in people
                                where p.id == pets.First().ownerId
                                select p.name;
                if (pets.Count != 0)
                {
                    Utils.muestraMensaje("Lista de mascotas de " + nameQuery.First(), logs);
                    foreach (Pet pet in pets)
                    {
                        Utils.muestraMensaje("\t" + pet.toString(), logs);
                    }
                }
                else
                {
                    Utils.muestraMensaje(nameQuery.First() + " no tiene mascotas", logs);
                }
            }

            // Guardar el contenido de la variable logs en un fichero
            Utils.creaFicheroLogs(logs, logFolder);
        }

        // 4. Mostrar las mascotas de una persona y las mascotas de sus parejas
        internal static void ejer4(List<Person> people)
        {
            // Variable para guardar el id de una persona
            int idPersona;
            // Variable para guardar los logs
            List<String> logs = new List<String>();

            logs.Add("EJERCICIO 4: Mostrar las mascotas de una persona y las mascotas de sus parejas");

            // Pedimos el id y comprobamos que sea válido
            idPersona = Utils.compruebaId(people, logs);

            // Queries para obtener las relaciones de la persona, sus mascotas y su nombre
            var relationsQuery = from p in people
                                 where p.id == idPersona
                                 select p.relations;
            var petsQuery = from p in people
                            where p.id == idPersona
                            select p.pets;
            var nameQuery = from p in people
                            where p.id == idPersona
                            select p.name;

            // Mostrar los resultados
            Console.Clear();
            // Mostramos las mascotas
            foreach (List<Pet> pets in petsQuery)
            {
                if (pets.Count != 0)
                {
                    Utils.muestraMensaje("Lista de mascotas de " + nameQuery.First(), logs);
                    foreach (Pet pet in pets)
                    {
                        Utils.muestraMensaje("\t" + pet.toString(), logs);
                    }
                }
                else
                {
                    Utils.muestraMensaje(nameQuery.First() + " no tiene mascotas", logs);
                }
            }
            // Mostramos las mascotas de las parejas
            foreach (List<Person> relations in relationsQuery)
            {
                if(relations.Count != 0)
                {
                    Utils.muestraMensaje("Mascotas de las parejas de " + nameQuery.First(), logs);
                    foreach (Person p in relations)
                    {
                        if(p.pets.Count != 0)
                        {
                            Utils.muestraMensaje("\tMascotas de " + p.name, logs);
                            foreach (Pet pet in p.pets)
                            {
                                Utils.muestraMensaje("\t\t" + pet.toString(), logs);
                            }
                        }
                        else
                        {
                            Utils.muestraMensaje("\t" + p.name + " no tiene mascotas", logs);
                        }
                    }
                }
                else
                {
                    Utils.muestraMensaje(nameQuery.First() + " no tiene parejas", logs);
                }
            }

            // Guardamos el contenido de la variable logs en un fichero
            Utils.creaFicheroLogs(logs, logFolder);
        }
    }
}