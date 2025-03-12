using System;

class Nodo
{
    public string Valor { get; set; }
    public Nodo Siguiente { get; set; }

    public Nodo(string valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}

class ListaCircular
{
    public Nodo Cabeza { get; private set; }
    public Nodo Cola { get; private set; }

    public ListaCircular()
    {
        Cabeza = null;
        Cola = null;
    }

    public void Agregar(string valor)
    {
        Nodo nuevoNodo = new Nodo(valor);
        if (Cabeza == null)
        {
            Cabeza = nuevoNodo;
            Cola = nuevoNodo;
            nuevoNodo.Siguiente = Cabeza;
        }
        else
        {
            Cola.Siguiente = nuevoNodo;
            Cola = nuevoNodo;
            Cola.Siguiente = Cabeza;
        }
    }

    public void Mostrar()
    {
        if (Cabeza == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo actual = Cabeza;
        do
        {
            Console.WriteLine(actual.Valor);
            actual = actual.Siguiente;
        } while (actual != Cabeza);
    }

    public bool Buscar(string valor)
    {
        if (Cabeza == null)
        {
            return false;
        }

        Nodo actual = Cabeza;
        do
        {
            if (actual.Valor == valor)
            {
                return true;
            }
            actual = actual.Siguiente;
        } while (actual != Cabeza);

        return false;
    }
}

class Program
{
    static void Main()
    {
        ListaCircular lista = new ListaCircular();

        lista.Agregar("A");
        lista.Agregar("B");
        lista.Agregar("C");
        lista.Agregar("D");

        Console.WriteLine("Elementos en la lista circular:");
        lista.Mostrar();

        string valorABuscar = "C";
        bool encontrado = lista.Buscar(valorABuscar);
        Console.WriteLine($"¿El valor '{valorABuscar}' está en la lista? {encontrado}");
    }
}