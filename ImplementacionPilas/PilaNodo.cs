using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementacionPilas
{
    internal class PilaNodo
    {
        #region métodos de la clase PilaNodo

        #region Declaración de variables y constructor para la clase
        
        private Nodo tope;

        // Constructor
        public PilaNodo()
        {
            tope = null;
        }
        #endregion

        #region Verificar si la pila está vacía

        public bool EstaVacia()
        {
            return tope == null;
        }

        #endregion

        #region Insertar un elemento (Push)
        public void Push(int valor)
        {
            Nodo nuevoNodo = new Nodo(valor);

            if (EstaVacia())
            {
                tope = nuevoNodo;
            }




            else
            {
                nuevoNodo.Siguiente = tope;
                tope = nuevoNodo;
            }

            Console.WriteLine($"Push: {valor} agregado a la pila");
        }

        #endregion

        #region Eliminar un elemento (Pop)
        public int Pop()
        {
            if (EstaVacia())
            {
                Console.WriteLine("Error: La pila está vacía");
                return -1; // Valor de error
            }

            int valorRetornado = tope.Dato;
            tope = tope.Siguiente;
            return valorRetornado;
        }

        #endregion

        #region Verificar elemento (Peek)
        public int Peek()
        {
            if (EstaVacia())
            {
                Console.WriteLine("Error: La pila está vacía");
                return -1; // Valor de error
            }

            return tope.Dato;
        }
        #endregion

        #region Mostrar elementos de la pila
        public void MostrarPila()
        {
            if (EstaVacia())
            {
                Console.WriteLine("La pila está vacía");
                return;
            }

            Console.WriteLine("Elementos de la pila (desde el tope):");
            Nodo actual = tope;
            int i = 0;

            while (actual != null)
            {
                Console.WriteLine($"[{i}] -> {actual.Dato}");
                actual = actual.Siguiente;
                i++;
            }

        }

        #endregion

        #endregion
    }
}
