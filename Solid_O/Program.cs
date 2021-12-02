using System;
using System.Collections.Generic;

namespace Solid_O
{
    class Program
    {

        // Principios SOLID
        // SOLID tiene bastante relación con los patrones de diseño.


        // Single responsibility,
        // Open-closed
        // Liskov substitution
        // Interface segregation
        // Dependency inversion.



        static void Main(string[] args)
        {
            // O: Open-closed - abierto para su extensión pero cerrado para su modificación
        }



        // El literal sin sufijo o con el sufijo d o D es del tipo double
        // El literal con el sufijo f o F es del tipo float
        // El literal con el sufijo m o M es del tipo decimal


        // Esta clase no debería modificarse... por ej si me dicen que agregar un
        // nuevo tipo de bebida energizante, para eso se debería usar la interfaz
        // la cual permite categorizar las clases, las cuales pueden implementar
        // interfaces: las cuales son como contratos que al ser implementados, deben
        // cumplirse sus anexos (métodos y atributos)




        //public class Drink
        //{
        //    public string Name { get; set; }
        //    public string Type { get; set; }
        //    public decimal Price { get; set; }
        //}

        //public class Invoce
        //{

        //    public decimal GetTotal(IEnumerable<Drink> lstDrink)
        //    {
        //        decimal total = 0;

        //        foreach (var drink in lstDrink)
        //        {
        //            if (drink.Type == "Agua") total += drink.Price;
        //            else if (drink.Type == "Azucar") total += drink.Price * 0.333m;
        //            else if (drink.Type == "Alcohol") total += drink.Price * 0.16m;
        //        }

        //        return total;
        //    }
        //}

        public interface IDrink
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public decimal Tax { get; set; } 

            // con C# 9, ya se pueden implementar los métodos en las interfaces
            // aunque acá lo vamos a dejar solo declarado
            public decimal GetPrice();
        }


        public class Water : IDrink
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public decimal Tax { get; set; }

            public decimal GetPrice()
            {
                return Price * Tax;
            }
        }

        public class Alcohol : IDrink
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public decimal Tax { get; set; }


            // es un campo particular de Alcohol, que no pertenece a la interfaz IDrink
            // quiere decir que hay promos en las bebidas alcohólicas
            public decimal Promo { get; set; }

            public decimal GetPrice()
            {
                return (Price * Tax) - Promo;
            }
        }

        public class Sugary : IDrink  // azucaradas
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public decimal Tax { get; set; }


            // es un campo particular de Sugary, que no pertenece a la interfaz IDrink
            // quiere decir que hay cerca de su caducidad se le descuenta al precio
            public decimal Expiration { get; set; }

            public decimal GetPrice()
            {
                return (Price * Tax) - Expiration;
            }
        }



        // Si tuviese que agregar un nuevo tipo de bebida, simplemente es crear la clase
        // e implementar la interfaz, y la clase pricipal invoice no se tocaría para nada
        public class Energizing : IDrink
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public decimal Tax { get; set; }

            public decimal GetPrice()
            {
                return Price * Tax;
            }
        }





        public class Invoce
        {

            public decimal GetTotal(IEnumerable<IDrink> lstDrink)
            {
                decimal total = 0;

                foreach (var drink in lstDrink)
                {
                    total += drink.GetPrice();
                }

                return total;
            }
        }


    }
}
