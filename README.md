# Ejercicio LINQ #

## Introducción ##
Ejercicio básico para empezar a practicar LINQ utilizando el lenguaje de programación C#.

Partimos de un documento Excel denominado Datos.xlsx que tiene las hojas Personas, Parejas y Mascotas.

Sabemos que la relación de Personas-Parejas es N:M  que la relación Personas-Mascotas es 1:N 

## Preparar el entorno ##
El ejercicio está realizado en Visual Studio, por lo que es necesario tenerlo instalado y configurado.

Lo primero que tenemos que hacer es abrir la solución en nuestro programa. Para ello abrimos la carpeta en Visual Studio y en el Explorador de Soluciones hacemos doble clic sobre "Ejemplo LINQ.sln"

Una vez abierta la solución vamos a instalar los paquetes necesarios. Para ello hacemos clic derecho sobre "Ejemplo LINQ" y seleccionamos la opción "Administrar paquetes NuGet..." En la pestaña que se abre tenemos que buscar e instalar los paquetes "ExcelDataReader" y "ExcelDataReader.DataSet".

Para poder probar la solución que planteo para el ejercicio hay que cambiar un par de variables:

- En el fichero Program.cs hay que cambiar el valor de la constante PATH(línea 13) y poner la ruta en la que se encuentra el Excel en tu equipo.
- En el fichero Queries.cs hay que cambiar el valor de la constante logFolder (línea 12) por la ruta en la que se encuentra la carpeta Logs dentro de tu equipo

Una vez realizados estos cambios se puede ejecutar el programa y comprobar su funcionamiento.

## Ejercicios realizados ##
En este programa se han realizado 4 ejercicios:

1. Mostrar las parejas de una persona. 
2. Mostrar las parejas y las mascotas de una persona.
3. Mostrar las mascotas de las personas que no tienen ninguna pareja.
4. Mostrar las mascotas de una persona y las mascotas de todas sus parejas.
