using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Magic
{
    /// <summary>
    /// Класс данных.
    /// Строка идентификатора "T:Magic.Data".
    /// </summary> 
    public class Data
    {
        /// <summary>
        /// Метод записи в файл.
        /// Строка идентификатора "M:Magic.Data.WriteInFile".
        /// </summary>
        public static void WriteInFile(string logFilePath, string text)
        {
            using StreamWriter log = File.AppendText(logFilePath);
            log.WriteLine(text);
        }
    }
}
