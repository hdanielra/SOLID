using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SolidAsp.Util
{
    public class Log
    {
        // nombre del archivo de log
        private static string _name = "log.txt";

        /// <summary>
        /// Guardar en  log.txt
        /// </summary>
        /// <param name="content">Contenido del log</param>
        public async void Guardar(string content) 
        { 
            await File.WriteAllTextAsync(_name, content);
        }
    }
}
