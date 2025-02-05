using System;

namespace EmisoraUPB
{
    public class Emisora
    {
        public string NombreCancion { get; set; }
        public string Artista { get; set; }
        public string Duracion { get; set; }
        public Emisora Anterior { get; set; }
        public Emisora Siguiente { get; set; }

        public Emisora(string nombreCancion, string artista, string duracion)
        {
            NombreCancion = nombreCancion;
            Artista = artista;
            Duracion = duracion;
            Siguiente = null;
            Anterior = null;
        }
    }

    public class ListaDobleEnlazada
    {
        private Emisora cabeza;

        public ListaDobleEnlazada()
        {
            cabeza = null;
        }

        public void AgregarCancion(string nombreCancion, string artista, string duracion)
        {
            Emisora nuevaCancion = new Emisora(nombreCancion, artista, duracion);
            if (cabeza == null)
            {
                cabeza = nuevaCancion;
            }
            else
            {
                Emisora actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevaCancion;
                nuevaCancion.Anterior = actual;
            }
        }

        public Emisora AnteriorCancion(string nombreCancion)
        {
            Emisora actual = cabeza;
            while (actual != null)
            {
                if (actual.NombreCancion == nombreCancion)
                {
                    return actual.Anterior;
                }
                actual = actual.Siguiente;
            }
            return null;
        }

        public Emisora SiguienteCancion(string nombreCancion)
        {
            Emisora actual = cabeza;
            while (actual != null)
            {
                if (actual.NombreCancion == nombreCancion)
                {
                    return actual.Siguiente;
                }
                actual = actual.Siguiente;
            }
            return null;
        }

        public Emisora ActualCancion(string nombreCancion)
        {
            Emisora actual = cabeza;
            while (actual != null)
            {
                if (actual.NombreCancion == nombreCancion)
                {
                    return actual;
                }
                actual = actual.Siguiente;
            }
            return null;
        }
        public Emisora EliminarCancion(string nombreCancion)
        {
            if (cabeza == null) return null;

            if (cabeza.NombreCancion == nombreCancion)
            {
                cabeza = cabeza.Siguiente;
                return cabeza;
            }

            Emisora actual = cabeza;
            while (actual.Siguiente != null)
            {
                if (actual.Siguiente.NombreCancion == nombreCancion)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    return actual.Siguiente;
                }
                actual = actual.Siguiente;
            }
            return null;
        }
        public Emisora MostrarListaReproduccion()
        {
            Emisora actual = cabeza;
            while (actual != null)
            {
                Console.WriteLine($"Nombre de la cancion: {actual.NombreCancion}, Artista: {actual.Artista}, Duracion: {actual.Duracion}");
                actual = actual.Siguiente;
            }
            return null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ListaDobleEnlazada lista = new ListaDobleEnlazada();
            lista.AgregarCancion("Honey!", "Tabber, Dean", "3:34");
            lista.AgregarCancion("Boy Comics", "Xdinary Heroes", "3:14");
            lista.AgregarCancion("OK!", "NCT U", "3:49");
            lista.AgregarCancion("Sugar", "System Of A Down", "2:33");
            lista.AgregarCancion("Easy", "Jaehyun", "3:14");
            lista.AgregarCancion("Venus", "Jey", "1:55");
            lista.AgregarCancion("Touch", "Katseye", "2:09");
            lista.AgregarCancion("I Get Around", "2Pac", "4:19");
            lista.AgregarCancion("Goodbye", "Yuta", "3:15");
            lista.AgregarCancion("She A Wolf", "WayV", "3:15");
            lista.MostrarListaReproduccion();
            Console.WriteLine("Cancion anterior a Easy");
            Console.WriteLine(lista.AnteriorCancion("Easy").NombreCancion);
            Console.WriteLine("Cancion siguiente a Easy");
            Console.WriteLine(lista.SiguienteCancion("Easy").NombreCancion);
            Console.WriteLine("Cancion actual Easy");
            Console.WriteLine(lista.ActualCancion("Easy").NombreCancion);
            Console.WriteLine("Eliminando Easy");
            lista.EliminarCancion("Easy");
            lista.MostrarListaReproduccion();
        }
    }
}
