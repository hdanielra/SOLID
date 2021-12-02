using System;

namespace Solid_S
{
    class Program
    {

        // Principios SOLID
        // SOLID tiene bastante relación con los patrones de diseño.


        // Single responsibility,       - responsabilidad única: establece que una clase, componente o microservicio debe ser responsable de una sola cosa (el tan aclamado término “decoupled” en inglés). 
        // Open-closed                  - abierto para su extensión pero cerrado para su modificación
        // Liskov substitution
        // Interface segregation
        // Dependency inversion.


        // ver explicación
        // https://enmilocalfunciona.io/principios-solid/


        //        ¿QUÉ ES SOLID?

        // Los principios SOLID son una serie de recomendaciones para que puedas escribir un mejor código que te
        // ayuda a implementar una alta cohesión y bajo acoplamiento.
        // Implementar SOLID en tus proyectos puede ser una tarea simple o compleja, todo esto dependerá de la práctica
        // pero tenerlos en cuenta desde un comienzo será más fácil de trabajar.La idea es buscar un punto de equilibrio
        // ya que tal vez no todo nuestro proyecto necesite de dichos principios.


        // 1. Single Responsibility Principle (SRP)     una clase debería estar destinada a una única responsabilidad y no mezclar la de otros o las que no le incumben a su dominio.
        // 2. Open/Closed Principle (OCP)
        // 3. Liskov substitution Principle (LSP)
        // 4. Interface Segregation Principle (ISP)
        // 5. Dependency Inversion Principle (DIP)



        static void Main(string[] args)
        {
            // S: Single Responsability Principle(SRP)
        }
    }






    // Principios SOLID: El Principio de Responsabilidad Única SRP
    // Cada clase debe separarse para que sea responsable de un solo servicio (por eso responsabilidad única)
    // Separamos funcionalidad por clase. Si hay que modificar algo (por ejemplo agregar un nuevo campo),
    // solo se afectaría/modificaría el servicio respectivo


    // The 5 principles: S O L I D

    // S: Single Responsability Principle(SRP)


    //----------------------------------------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------------------------------------
    public class Cerveza
    {
        public string Nombre { get; set; }
        public string Marca { get; set; }

        public Cerveza(string pNombre, string pMarca)
        {
            this.Nombre = Nombre;
            this.Marca = Marca;
        }
    }
    //----------------------------------------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------------------------------------





    //----------------------------------------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------------------------------------
    public class GuardarBD
    {

        public Cerveza cerveza { get; set; }

        public GuardarBD(Cerveza pCerveza)
        {
            this.cerveza = pCerveza;
        }

        public void Guardar()
        {
            Console.WriteLine($"Guardamos {cerveza.Nombre} y {cerveza.Marca}");
        }

    }
    //----------------------------------------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------------------------------------




    //----------------------------------------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------------------------------------
    public class EnviarCerveza
    {

        public Cerveza cerveza { get; set; }

        public EnviarCerveza(Cerveza pCerveza)
        {
            this.cerveza = pCerveza;
        }

        public void Enviar()
        {
            Console.WriteLine($"Enviamos {cerveza.Nombre} y {cerveza.Marca}");
        }
    }
    //----------------------------------------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------------------------------------

}


