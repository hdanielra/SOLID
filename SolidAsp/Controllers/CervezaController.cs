using Microsoft.AspNetCore.Mvc;
using SolidAsp.Models.ViewModels;
using SolidAsp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidAsp.Controllers
{
    public class CervezaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        /// <summary>
        /// Método para crear la cerveza
        /// </summary>
        /// <param name="cerveza">Objeto con la información de la cerveza</param>
        /// <returns></returns>
        public IActionResult Add(CervezaViewModel cerveza)
        {

            // si el estado del modelo no es válido --> retorne la vista con los datos del controlador CERVEZA
            if(!ModelState.IsValid)
            {
                return View(cerveza);
            }

            // crear el objeto del servicio
            var cervezaService = new CervezaService();





            // 1. Guardar BD
            // 2. Guardar Log


            // guardar bd (dentro de Crear está el guardado del log)
            cervezaService.Crear(cerveza);


            // 3. Enviar Correo:

            // en este caso acá en el controlador no se haría nada (principio de responsabilidad única SRP),
            // se modificaría el servicio y de ahí hacia atrás dependiendo dependiendo de hasta dónde 
            // llegué la abstracción

            return Ok();

        }
    }
}
