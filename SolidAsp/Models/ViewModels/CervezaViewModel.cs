using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidAsp.Models.ViewModels
{
    public class CervezaViewModel
    {
        public string Nombre { get; set; }
        public string Marca { get; set; }


        // En c# el operador => se conoce como operador lambda.
        // Sirve para crear un Func<>, Action<> o Expression<Func<>> según se necesite.

        // es como una función lambda que retorna el concatenado
        public string ObtenerInfo() => Nombre + " " + Marca;
    }
}
