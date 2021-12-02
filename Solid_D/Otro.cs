using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_D
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
    // Dependency inversion         - inversión de dependencia: Las clases de alto nivel no deberían depender de las clases de bajo nivel.
    //                                Ambas deberían depender de las abstracciones. Las abstracciones no deberían depender de los detalles.
    //                                Los detalles deberían depender de las abstracciones


    // Principio de inversión de dependencias
    // Establece que las dependencias deben estar en las abstracciones, no en las concreciones.Es decir:

    // Los módulos de alto nivel no deberían depender de módulos de bajo nivel.Ambos deberían depender de abstracciones.
    // Las abstracciones no deberían depender de detalles.Los detalles deberían depender de abstracciones.

    // En algún momento nuestro programa o aplicación llegará a estar formado por muchos módulos.Cuando esto pase,
    // es cuando debemos usar inyección de dependencias, lo que nos permitirá controlar las funcionalidades desde un
    // sitio concreto en vez de tenerlas esparcidas por todo el programa. Además, este aislamiento nos permitirá realizar testing mucho más fácilmente.

    class Otro
    {
    }
}
