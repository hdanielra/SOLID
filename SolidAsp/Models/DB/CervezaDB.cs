using SolidAsp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidAsp.Models.DB
{
    public class CervezaDB
    {

        public void Guardar(CervezaViewModel cerveza)
        {
            Console.WriteLine("Guardar en BD: " + cerveza.Nombre );

        }
    }
}
