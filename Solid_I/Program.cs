using System;

namespace Solid_I
{
    class Program
    {
        // Principios SOLID
        // SOLID tiene bastante relación con los patrones de diseño.


        // Single responsibility,       - responsabilidad única
        // Open-closed                  - abierto para su extensión pero cerrado para su modificación
        // Liskov substitution          - Bárbara Liskov: 1 clase padre que hereda a 1 clase hija, la hija no debe alterar el funcionamiento del padre (no deben sobrar métodos del padre)
        // Interface segregation        - es mejor tener muchas clases pequeñas y especializadas que una enorme
        // Dependency inversion         -  



        static void Main(string[] args)
        {
            // Interface segregation       

        }

        //interface IAve
        //{
        //    void Volar();
        //    void Comer();
        //}

        //public class Loro : IAve
        //{
        //    public void Comer()
        //    {
        //        Console.WriteLine("Comer");
        //    }

        //    public void Volar()
        //    {
        //        Console.WriteLine("Volar");
        //    }
        //}

        //public class Tucan : IAve
        //{

        //    public void Volar()
        //    {
        //        Console.WriteLine("Comer");
        //    }

        //    public void Comer()
        //    {
        //        Console.WriteLine("Volar");
        //    }
        //}

        // Hasta aquí todo bien.Pero ahora imaginemos que queremos añadir a los pingüinos. Estos son aves, pero además tienen la habilidad de nadar.
        // Tendríamos que añadir el método nadar a la interfaz base. El problema es que el loro no nada, el pinguino no vuela. por lo tanto


        //public class Pinguino : IAve
        //{
        //    public void Comer()
        //    {
        //        Console.WriteLine("Comer");
        //    }

        //    public void Volar()
        //    {
        //        Console.WriteLine("Volar");
        //    }
        //}






        public interface IAveCome
        {
            void Comer();
        }

        public interface IAveVuela
        {
            void Volar();
        }

        public interface IAveNada
        {
            void Nadar();
        }



        public class Pinguino : IAveCome, IAveNada
        {
            public void Comer()
            {
                Console.WriteLine("Comer");
            }

            public void Nadar()
            {
                Console.WriteLine("Nada");
            }

        }


        public class Lora : IAveCome, IAveVuela
        {
            public void Comer()
            {
                Console.WriteLine("Comer");
            }

            public void Volar()
            {
                Console.WriteLine("Volar");
            }
        }




    }

}
