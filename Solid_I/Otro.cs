using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_I
{


    // Principios SOLID
    // SOLID tiene bastante relación con los patrones de diseño.


    // Single responsibility,       - responsabilidad única: establece que una clase, componente o microservicio debe ser responsable de una
    //                                sola cosa (el tan aclamado término “decoupled” en inglés). 
    // Open-closed                  - abierto/cerrado...abierto para su extensión pero cerrado para su modificación
    // Liskov substitution          - sustitución de Liskov...Bárbara Liskov: 1 clase padre que hereda a 1 clase hija, la hija no debe
    //                                alterar el funcionamiento del padre (no deben sobrar métodos del padre)
    // Interface segregation        - segregación de interfaces: no dar más información de la necesaria...separar tanto como se puedan las
    //                                interfaces...es mejor tener muchas clases pequeñas y especializadas que una enorme...
    //                                los clientes no deberían verse forzados a depender de interfaces que no usan.
    // Dependency inversion         -  



    class Otro
    {
    }




    //--------------------------------------------------------------------------------------
    public interface ILead1
    {
        void CreateSubTask();
        void AssignTask();
        void WorkOnTask();
    }
    public class TeamLead1 : ILead1
    {
        public void AssignTask()
        {
            //Code to assign a task.  
        }
        public void CreateSubTask()
        {
            //Code to create a sub task  
        }
        public void WorkOnTask()
        {
            //Code to implement perform assigned task.  
        }
    }

    public class Manager1 : ILead1
    {
        public void AssignTask()
        {
            //Code to assign a task.  
        }
        public void CreateSubTask()
        {
            //Code to create a sub task.  
        }
        public void WorkOnTask()
        {
            throw new Exception("Manager can't work on Task");
        }
    }
    //--------------------------------------------------------------------------------------





    //--------------------------------------------------------------------------------------
    public interface IProgrammer
    {
        void WorkOnTask();
    }

    public interface ILead
    {
        void AssignTask();
        void CreateSubTask();
    }


    public class Programmer : IProgrammer
    {
        public void WorkOnTask()
        {
            //code to implement to work on the Task.  
        }
    }
    public class Manager : ILead
    {
        public void AssignTask()
        {
            //Code to assign a Task  
        }
        public void CreateSubTask()
        {
            //Code to create a sub taks from a task.  
        }
    }


    public class TeamLead : IProgrammer, ILead
    {
        public void AssignTask()
        {
            //Code to assign a Task  
        }
        public void CreateSubTask()
        {
            //Code to create a sub task from a task.  
        }
        public void WorkOnTask()
        {
            //code to implement to work on the Task.  
        }
    }
}
