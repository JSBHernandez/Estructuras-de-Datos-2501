using System;

namespace Ronda
{

    public class Participante
    {
        public string Nombre { get; set; }
        public int ID { get; set; }
        public Participante Siguiente { get; set; }

        public Participante(string nombre, int id)
        {
            Nombre = nombre;
            ID = id;
            Siguiente = null;
        }
    }

    public class ListaCircular
    {
        private Participante cabeza;

        public ListaCircular()
        {
            cabeza = null;
        }

        public void AgregarParticipante(string nombre, int id)
        {
            Participante nuevo = new Participante(nombre, id);
            if (cabeza == null)
            {
                cabeza = nuevo;
                cabeza.Siguiente = cabeza;
            }
            else
            {
                Participante actual = cabeza;
                while (actual.Siguiente != cabeza)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevo;
                nuevo.Siguiente = cabeza;
            }
        }

        public void EliminarParticipante(int pasos)
        {
            if (cabeza == null) return;

            Participante actual = cabeza;
            Participante anterior = null;

            while (actual.Siguiente != actual)
            {
                for (int i = 0; i < pasos; i++)
                {
                    anterior = actual;
                    actual = actual.Siguiente;
                }
                Console.WriteLine($"Eliminando a: {actual.Nombre}, ID: {actual.ID}");
                anterior.Siguiente = actual.Siguiente;
                actual = anterior.Siguiente;
            }

            cabeza = actual;
        }

        public void MostrarGanador()
        {
            if (cabeza != null)
            {
                Console.WriteLine($"El ganador es: {cabeza.Nombre}, ID: {cabeza.ID}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            ListaCircular listaCircular = new ListaCircular();

            listaCircular.AgregarParticipante("Juanse", 1);
            listaCircular.AgregarParticipante("Benitez", 2);
            listaCircular.AgregarParticipante("Takeshi", 3);

            Console.WriteLine("Iniciando el juego...");
            listaCircular.EliminarParticipante(10);

            listaCircular.MostrarGanador();
        }
    }
}
