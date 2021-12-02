using System;
using System.Collections.Generic;

namespace Solid_L
{
    class Program
    {

        // Principios SOLID
        // SOLID tiene bastante relación con los patrones de diseño.


        // Single responsibility,       - responsabilidad única
        // Open-closed                  - abierto para su extensión pero cerrado para su modificación
        // Liskov substitution          - Bárbara Liskov: 1 clase padre que hereda a 1 clase hija, la hija no debe alterar el funcionamiento del padre (no deben sobrar métodos del padre)
        // Interface segregation
        // Dependency inversion.



        static void Main(string[] args)
        {
            // Liskov substitution

            List<IUpdate> cruds = new List<IUpdate>();
            User user = new User();
            Car car = new Car();


            // ojo que este método Add no es el de las clases que creamos, sino el de la clase List<>
            cruds.Add(user);
            cruds.Add(car);

            foreach (var crud in cruds)
            {
                crud.Update(); // solo puedo hacer llamado a métodos que se intercepten entre las clases/objetos
            }
        }



        //interface ICrud
        //{
        //    public void Add();
        //    public void Update();
        //    public void Delete();
        //    public void Get();
        //}
        //public class User : ICrud
        //{
        //    public void Add() => Console.WriteLine("Agrega usuario");

        //    public void Delete() => Console.WriteLine("Elimina usuario");

        //    public void Get() => Console.WriteLine("Obtiene usuario");

        //    public void Update() => Console.WriteLine("Actualiza usuario");
        //}


        // qué pasaría si piden implementar una clase carro que solo permite editar... qué pasa con los otros métodos de la interfaz?
        // si dejamos que el método(que no usa la clase hija) lance una excepción por defecto en algún momento que se llame, tumbará
        // el proceso o enviará información errónea





        // para resolverlo se dividen las interfaces, y creo una que las una a todas (o podría dejarlas separadas según el caso)

        interface ICrud : IAdd, IUpdate, IDelete, IGet
        {

        }


        interface IAdd
        {
            public void Add();
        }
        interface IUpdate
        {
            public void Update();
        }
        interface IDelete
        {
            public void Delete();
        }
        interface IGet
        {
            public void Get();
        }



        public class Car : IUpdate
        {
            public void Update() => Console.WriteLine("Actualiza carro");
        }


        public class User : ICrud
        {
            public void Add() => Console.WriteLine("Agrega usuario");

            public void Delete() => Console.WriteLine("Elimina usuario");

            public void Get() => Console.WriteLine("Obtiene usuario");

            public void Update() => Console.WriteLine("Actualiza usuario");
        }
    }


}
