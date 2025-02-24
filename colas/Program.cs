using System;
namespace Colas {

    class Nodo {
        public int dato { get; set; }
        public Nodo siguiente { get; set; }
    }

    public class Cola {
        private Nodo frente;
        private Nodo fin;

        public Cola() {
            frente = null;
            fin = null;
        }

        public void Insertar(int dato) {
            Nodo nuevo = new Nodo();
            nuevo.dato = dato;
            nuevo.siguiente = null;
            if (frente == null) {
                frente = nuevo;
            } else {
                fin.siguiente = nuevo;
            }
            fin = nuevo;
        }

        public int Eliminar() {
            if (frente == null) {
                throw new Exception("Cola vacía");
            }
            int dato = frente.dato;
            frente = frente.siguiente;
            if (frente == null) {
                fin = null;
            }
            return dato;
        }

        public void Imprimir() {
            Nodo actual = frente;
            while (actual != null) {
                Console.WriteLine(actual.dato);
                actual = actual.siguiente;
            }
        }
    }

    class Program {
        static void Main(string[]args) {
            Cola cola = new Cola();
            cola.Insertar(10);
            cola.Insertar(20);
            cola.Insertar(30);
            cola.Imprimir();
            Console.WriteLine("Eliminando dato: " + cola.Eliminar());
            cola.Imprimir();
        }
    }

}