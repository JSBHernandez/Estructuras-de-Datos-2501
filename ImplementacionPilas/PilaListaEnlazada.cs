using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementacionPilas
{
    internal class PilaListaEnlazada
    {
        private Nodo cabeza;
        private int longitud;

        public PilaListaEnlazada()
        {
            cabeza = null;
            longitud = 0;
        }

        // Agregar al inicio (necesario para la pila)
        public void AgregarAlInicio(int dato)
        {
            Nodo nuevoNodo = new Nodo(dato);

            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                nuevoNodo.Siguiente = cabeza;
                cabeza = nuevoNodo;
            }

            longitud++;
        }

        // Eliminar del inicio (necesario para la pila)
        public int EliminarDelInicio()
        {
            if (cabeza == null)
            {
                throw new InvalidOperationException("La lista está vacía");
            }

            int datoEliminado = cabeza.Dato;
            cabeza = cabeza.Siguiente;
            longitud--;

            return datoEliminado;
        }

        // Obtener el primer elemento sin eliminarlo
        public int ObtenerPrimero()
        {
            if (cabeza == null)
            {
                throw new InvalidOperationException("La lista está vacía");
            }

            return cabeza.Dato;
        }

        // Verificar si la lista está vacía
        public bool EstaVacia()
        {
            return cabeza == null;
        }

        // Obtener la longitud de la lista
        public int Longitud()
        {
            return longitud;
        }

        // Método para mostrar todos los elementos
        public void MostrarElementos()
        {
            if (cabeza == null)
            {
                Console.WriteLine("La lista está vacía");
                return;
            }

            Nodo actual = cabeza;
            int indice = 0;

            Console.WriteLine("Elementos de la lista:");
            while (actual != null)
            {
                Console.WriteLine($"[{indice}] -> {actual.Dato}");
                actual = actual.Siguiente;
                indice++;
            }
        }

        // Obtener tamaño de la pila
        public int Tamano()
        {
            return longitud;
        }

    }
}
