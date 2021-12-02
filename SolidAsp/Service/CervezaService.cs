using SolidAsp.Models.DB;
using SolidAsp.Models.ViewModels;
using SolidAsp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidAsp.Service
{
    public class CervezaService
    {

        /// <summary>
        /// Crear una cerveza
        /// </summary>
        /// <param name="cerveza">Objeto que tiene la información a guardar</param>
        public void Crear(CervezaViewModel cerveza)
        {
            //-----------------------------------------------------------------------
            // OBJETOS:

            // crear el objeto de conexión con la BD
            var cervezaDB = new CervezaDB();
            // crear el objeto para guardar el log
            var log = new Log();
            
            //-----------------------------------------------------------------------




            // guardar en la BD
            cervezaDB.Guardar(cerveza);


            // guardar el log
            log.Guardar("Se guardó una cerveza " + cerveza.ObtenerInfo());
        }
    }
}
