using System;
using System.Collections.Generic;

namespace SistemaDeEmergenciasMedicas
{
    public enum Gravedad
    {
        Baja,
        Media,
        Alta,
        Urgente
    }

    public class Paciente
    {
        public string Nombre { get; set; }
        public string Condicion { get; set; }
        public Gravedad Gravedad { get; set; }

        public Paciente(string nombre, string condicion, Gravedad gravedad)
        {
            Nombre = nombre;
            Condicion = condicion;
            Gravedad = gravedad;
        }

        public override string ToString()
        {
            return $"{Nombre} - {Condicion} - {Gravedad}";
        }
    }

    public class ColaDePrioridad
    {
        private List<Paciente> _cola = new List<Paciente>();

        public void Encolar(Paciente paciente)
        {
            _cola.Add(paciente);
            _cola.Sort((x, y) => y.Gravedad.CompareTo(x.Gravedad));
        }

        public Paciente Desencolar()
        {
            if (_cola.Count == 0)
                throw new InvalidOperationException("La cola está vacía");

            var paciente = _cola[0];
            _cola.RemoveAt(0);
            return paciente;
        }

        public bool EstaVacia()
        {
            return _cola.Count == 0;
        }
    }

    class Programa
    {
        static void Main(string[] args)
        {
            ColaDePrioridad cola = new ColaDePrioridad();

            cola.Encolar(new Paciente("Juan", "Dolor de cabeza", Gravedad.Baja));
            cola.Encolar(new Paciente("Sebastian", "Infarto", Gravedad.Urgente));
            cola.Encolar(new Paciente("Becerra", "Brazo roto", Gravedad.Media));
            cola.Encolar(new Paciente("Hernandez", "Hemorragia severa", Gravedad.Alta));

            while (!cola.EstaVacia())
            {
                Paciente paciente = cola.Desencolar();
                Console.WriteLine($"Atendiendo a: {paciente}");
            }
        }
    }
}