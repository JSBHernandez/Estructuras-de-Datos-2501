using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementacionPilas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Implementación de una pila con Nodos

            PilaNodo pila = new PilaNodo();

            // Prueba de operaciones
            pila.Push(10);
            pila.Push(20);
            pila.Push(30);

            pila.MostrarPila();

            Console.WriteLine($"Peek: El elemento en el tope es {pila.Peek()}");

            Console.WriteLine($"Pop: Se removió {pila.Pop()}");
            Console.WriteLine($"Pop: Se removió {pila.Pop()}");

            pila.MostrarPila();

            pila.Push(40);
            pila.Push(50);

            pila.MostrarPila();

            Console.ReadKey();

            #endregion

            /*

            #region Implementación de una pila con Listas enlazadas

            Console.WriteLine("=== Demostración de Pila con Lista Enlazada Manual ===\n");

            PilaListaEnlazada pilas = new PilaListaEnlazada();

            Console.WriteLine("--- Agregando elementos ---");
            pilas.AgregarAlInicio(50);
            pilas.AgregarAlInicio(60);
            pilas.AgregarAlInicio(70);

            Console.WriteLine("\n--- Mostrando estado actual ---");
            pilas.MostrarElementos();

            Console.WriteLine($"\nPeek: El elemento en el tope es {pilas.ObtenerPrimero()}");

            Console.WriteLine("\n--- Removiendo elementos ---");
            Console.WriteLine($"Pop: Se removió {pilas.EliminarDelInicio()}");
            Console.WriteLine($"Pop: Se removió {pilas.EliminarDelInicio()}");

            Console.WriteLine("\n--- Mostrando estado actual ---");
            pilas.MostrarElementos();

            Console.WriteLine("\n--- Agregando más elementos ---");
            pilas.AgregarAlInicio(60);
            pilas.AgregarAlInicio(70);

            Console.WriteLine("\n--- Estado final de la pila ---");
            pilas.MostrarElementos();
            Console.WriteLine($"Tamaño actual: {pilas.Longitud()} elementos");

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();

            #endregion
            */
        }
    }
}
