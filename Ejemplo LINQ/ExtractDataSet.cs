using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;
using System.Data;
using System.IO;

namespace Ejemplo_LINQ
{
    class ExtractDataSet
    {
        // Método que devuelve un DataSet con los datos del Excel
        public static DataSet extractDataSetFromExcel(String path)
        {
            // Creamos un stream a partir del fichero Excel
            FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);
            // Leemos y guardamos el fichero en una variable
            var excelReader = ExcelReaderFactory.CreateReader(stream);
            // Convertimos el fichero a DataSet
            DataSet resul = excelReader.AsDataSet();

            // Liberamos los recursos utilizados
            excelReader.Dispose();
            stream.Dispose();

            // Devolvemos el resultado
            return resul;
        }
    }
}
