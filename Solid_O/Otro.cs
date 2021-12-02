using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_O
{
    // O: Open/Closed Principle
    // The Open/closed Principle says "A software module/class is open for extension and closed for modification"


    // Here "Open for extension" means, we need to design our module/class in such a way
    // that the new functionality can be added only when new requirements are generated.
    // "Closed for modification" means we have already developed a class and it has gone
    // through unit testing.We should then not alter it until we find bugs.As it says,
    // a class should be open for extensions, we can use inheritance to do this. Okay, let's dive into an example.


    // Principios SOLID
    // SOLID tiene bastante relación con los patrones de diseño.


    // Single responsibility,
    // Open-closed
    // Liskov substitution
    // Interface segregation
    // Dependency inversion.

    // O: Open-closed - abierto para su extensión pero cerrado para su modificación


    public class Otro
    {
    }

    //public class Rectangle
    //{
    //    public double Height { get; set; }
    //    public double Width { get; set; }
    //}

    public class AreaCalculatorIni
    {
        public double TotalArea(Rectangle[] arrRectangles)
        {
            double area = 0;
            foreach (var objRectangle in arrRectangles)
            {
                area += objRectangle.Height * objRectangle.Width;
            }

            return area;
        }

    }



    // qué pasa si ahora quiero calcular el área del círculo... el anterior método no me funcionaría

    //public class Circle
    //{
    //    public double Radius { get; set; }
    //}

    // But every time we introduce a new shape we need to alter the TotalArea method.So the AreaCalculator class is not closed for modification.
    public class AreaCalculatorDos
    {
        public double TotalArea(object[] arrObjects)
        {
            double area = 0;
            Rectangle objRectangle;
            Circle objCircle;

            foreach (var obj in arrObjects)
            {
                if (obj is Rectangle)
                {
                    objRectangle = ((Rectangle)obj);
                    area += objRectangle.Height * objRectangle.Width;
                }
                else
                {
                    objCircle = (Circle)obj;
                    area += objCircle.Radius * objCircle.Radius * Math.PI;
                }
            }
            return area;
        }
    }



    //How can we make our design to avoid this situation? Generally, we can do this by referring
    //to abstractions for dependencies, such as interfaces or abstract classes, rather than using
    //concrete classes.Such interfaces can be fixed once developed so the classes that depend upon
    //them can rely upon unchanging abstractions.Functionality can be added by creating new classes
    //that implement the interfaces.So let's refract our code using an interface.



    // Existen diferencias técnicas entre las clases abstractas y las interfaces,
    // ya que ser una clase abstracta puede contener la implementación de métodos,
    // campos, constructores, etc., mientras que una interfaz solo contiene prototipos
    // de métodos y propiedades.
    // Una clase puede implementar múltiples interfaces,
    // pero solo puede heredar una clase(abstracta o no).
   

    public abstract class Shape
    {
        public abstract double Area();
    }


    // Inheriting from Shape, the Rectangle and Circle classes now look like this:
    public class Rectangle : Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public override double Area()
        {
            return Height * Width;
        }
    }


    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override double Area()
        {
            return Radius * Radius * Math.PI;
        }
    }


    //Every shape contains its area with its own way of calculation functionality and our AreaCalculator class will become simpler than before.

    public class AreaCalculator
    {
        public double TotalArea(Shape[] arrShapes)
        {
            double area = 0;

            foreach (var shape in arrShapes)
            {
                area += shape.Area();
            }

            return area;
        }
    }

    // Now our code is following SRP and OCP both. Whenever you introduce a new shape by deriving
    // from the "Shape" abstract class, you need not change the "AreaCalculator" class. Awesome. Isn't it?

}
