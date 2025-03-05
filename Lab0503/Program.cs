using System;
using System.Collections.Generic;

namespace ServicioAlClienteBanco
{
    public enum Prioridad
    {
        Baja,
        Media,
        Alta,
        Urgente
    }

    public class Cliente
    {
        public string Nombre { get; set; }
        public string Operacion { get; set; }
        public Prioridad Prioridad { get; set; }

        public Cliente(string nombre, string operacion, Prioridad prioridad)
        {
            Nombre = nombre;
            Operacion = operacion;
            Prioridad = prioridad;
        }

        public override string ToString()
        {
            return $"{Nombre} - {Operacion} - {Prioridad}";
        }
    }

    public class ColaDePrioridad
    {
        private List<Cliente> _cola = new List<Cliente>();

        public void Encolar(Cliente cliente)
        {
            _cola.Add(cliente);
            _cola.Sort((x, y) => y.Prioridad.CompareTo(x.Prioridad));
        }

        public Cliente Desencolar()
        {
            if (_cola.Count == 0)
                throw new InvalidOperationException("La cola está vacía");

            var cliente = _cola[0];
            _cola.RemoveAt(0);
            return cliente;
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

            cola.Encolar(new Cliente("Juan", "Deposito", Prioridad.Media));
            cola.Encolar(new Cliente("Sebastian", "Retiro", Prioridad.Baja));
            cola.Encolar(new Cliente("Becerra", "Transferencia Internacional", Prioridad.Urgente));
            cola.Encolar(new Cliente("Hernandez", "Consulta", Prioridad.Alta));

            while (!cola.EstaVacia())
            {
                Cliente cliente = cola.Desencolar();
                Console.WriteLine($"Atendiendo a: {cliente}");
            }
        }
    }
}
