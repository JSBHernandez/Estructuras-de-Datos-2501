using System;

class Nodo
{
    public string Corredor { get; set; }
    public int Posicion { get; set; }
    public Nodo Siguiente { get; set; }

    public Nodo(string corredor, int posicion)
    {
        Corredor = corredor;
        Posicion = posicion;
        Siguiente = null;
    }
}

class ListaEnlazada
{
    public Nodo Cabeza { get; private set; }

    public void Agregar(string corredor, int posicion)
    {
        Nodo nuevoNodo = new Nodo(corredor, posicion);
        if (Cabeza == null)
        {
            Cabeza = nuevoNodo;
        }
        else
        {
            Nodo actual = Cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo;
        }
    }

    public void Mostrar()
    {
        Nodo actual = Cabeza;
        while (actual != null)
        {
            Console.WriteLine($"{actual.Corredor} está en la posición {actual.Posicion}");
            actual = actual.Siguiente;
        }
    }

    public string DeterminarGanador(int meta)
    {
        Nodo actual = Cabeza;
        string ganador = null;
        while (actual != null)
        {
            if (actual.Posicion >= meta)
            {
                ganador = actual.Corredor;
                break;
            }
            actual = actual.Siguiente;
        }
        return ganador;
    }
}

class Program
{
    static void Main()
    {
        ListaEnlazada carrera = new ListaEnlazada();
        int posicionLiebre = 0;
        int posicionTortuga = 0;
        int meta = 20;
        Random random = new Random();

        while (posicionLiebre < meta && posicionTortuga < meta)
        {
            posicionLiebre += random.Next(2, 6);
            posicionTortuga += 1;

            carrera.Agregar("Liebre", posicionLiebre);
            carrera.Agregar("Tortuga", posicionTortuga);
        }

        carrera.Mostrar();

        string ganador = carrera.DeterminarGanador(meta);
        if (ganador != null)
        {
            Console.WriteLine($"El ganador es: {ganador}");
        }
        else
        {
            Console.WriteLine("No hay ganador.");
        }
    }
}