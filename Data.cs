using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Magic
{
    public class Data
    {
        public static void WriteInFile(string logFilePath, string text)
        {
            using StreamWriter log = File.AppendText(logFilePath);
            log.WriteLine(text);
        }
    }
}
