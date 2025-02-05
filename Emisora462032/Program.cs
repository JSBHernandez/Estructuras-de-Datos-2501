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
            lista.AgregarCancion("Cancion1", "Artista1", "3:00");
            lista.AgregarCancion("Cancion2", "Artista2", "3:30");
            lista.AgregarCancion("Cancion3", "Artista3", "4:00");
            lista.AgregarCancion("Cancion4", "Artista4", "4:30");
            lista.AgregarCancion("Cancion5", "Artista5", "5:00");
            lista.AgregarCancion("Cancion6", "Artista6", "5:30");
            lista.AgregarCancion("Cancion7", "Artista7", "6:00");
            lista.AgregarCancion("Cancion8", "Artista8", "6:30");
            lista.AgregarCancion("Cancion9", "Artista9", "7:00");
            lista.AgregarCancion("Cancion10", "Artista10", "7:30");
            lista.MostrarListaReproduccion();
            Console.WriteLine("Cancion anterior a Cancion5");
            Console.WriteLine(lista.AnteriorCancion("Cancion5").NombreCancion);
            Console.WriteLine("Cancion siguiente a Cancion5");
            Console.WriteLine(lista.SiguienteCancion("Cancion5").NombreCancion);
            Console.WriteLine("Cancion actual Cancion5");
            Console.WriteLine(lista.ActualCancion("Cancion5").NombreCancion);
            Console.WriteLine("Eliminando Cancion5");
            lista.EliminarCancion("Cancion5");
            lista.MostrarListaReproduccion();
        }
    }
}
