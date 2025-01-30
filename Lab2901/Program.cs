using System;

namespace UPBClinic
{
    class Paciente
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public int ID { get; set; }
        public Paciente Siguiente { get; set; }

        public Paciente(string nombre, int edad, int id)
        {
            Nombre = nombre;
            Edad = edad;
            ID = id;
            Siguiente = null;
        }
    }

    class ListaPacientes
    {
        private Paciente cabeza;

        public ListaPacientes()
        {
            cabeza = null;
        }

        public void AgregarPaciente(string nombre, int edad, int id)
        {
            Paciente nuevoPaciente = new Paciente(nombre, edad, id);
            if (cabeza == null)
            {
                cabeza = nuevoPaciente;
            }
            else
            {
                Paciente actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoPaciente;
            }
        }

        public Paciente BuscarPaciente(int id)
        {
            Paciente actual = cabeza;
            while (actual != null)
            {
                if (actual.ID == id)
                {
                    return actual;
                }
                actual = actual.Siguiente;
            }
            return null;
        }

        public void EliminarPaciente(int id)
        {
            if (cabeza == null) return;

            if (cabeza.ID == id)
            {
                cabeza = cabeza.Siguiente;
                return;
            }

            Paciente actual = cabeza;
            while (actual.Siguiente != null)
            {
                if (actual.Siguiente.ID == id)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    return;
                }
                actual = actual.Siguiente;
            }
        }

        public void MostrarPacientes()
        {
            Paciente actual = cabeza;
            while (actual != null)
            {
                Console.WriteLine($"Nombre: {actual.Nombre}, Edad: {actual.Edad}, ID: {actual.ID}");
                actual = actual.Siguiente;
            }
        }

        public void AtenderPaciente()
        {
            if (cabeza != null)
            {
                Console.WriteLine($"Atendiendo a: {cabeza.Nombre}, Edad: {cabeza.Edad}, ID: {cabeza.ID}");
                cabeza = cabeza.Siguiente;
            }
            else
            {
                Console.WriteLine("No hay pacientes en la lista.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ListaPacientes lista = new ListaPacientes();

            lista.AgregarPaciente("Juanse", 20, 1);
            lista.AgregarPaciente("Francisco", 22, 2);
            lista.AgregarPaciente("Maycol", 21, 3);

            Console.WriteLine("Lista de pacientes:");
            lista.MostrarPacientes();

            Console.WriteLine("\nBuscando paciente con ID 2:");
            Paciente paciente = lista.BuscarPaciente(2);
            if (paciente != null)
            {
                Console.WriteLine($"Nombre: {paciente.Nombre}, Edad: {paciente.Edad}, ID: {paciente.ID}");
            }
            else
            {
                Console.WriteLine("Paciente no encontrado.");
            }

            Console.WriteLine("\nEliminando paciente con ID 2:");
            lista.EliminarPaciente(2);
            Console.WriteLine("\nPacientes luego de eliminar:")
            lista.MostrarPacientes();

            Console.WriteLine("\nAtendiendo al primer paciente:");
            lista.AtenderPaciente();
            Console.WriteLine("\nCola de Espera:");
            lista.MostrarPacientes();
        }
    }
}