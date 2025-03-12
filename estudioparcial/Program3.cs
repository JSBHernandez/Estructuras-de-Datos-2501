using System;
using System.Collections.Generic;
using System.IO;

class Pedido : IComparable<Pedido>
{
    public int Id { get; set; }
    public DateTime FechaHoraRecepcion { get; set; }
    public int IdCliente { get; set; }
    public string NivelImportancia { get; set; }
    public string Descripcion { get; set; }

    public Pedido(int id, DateTime fechaHoraRecepcion, int idCliente, string nivelImportancia, string descripcion)
    {
        Id = id;
        FechaHoraRecepcion = fechaHoraRecepcion;
        IdCliente = idCliente;
        NivelImportancia = nivelImportancia;
        Descripcion = descripcion;
    }

    public int CompareTo(Pedido other)
    {
        int fechaComparacion = FechaHoraRecepcion.CompareTo(other.FechaHoraRecepcion);
        if (fechaComparacion != 0)
        {
            return fechaComparacion;
        }

        return CompararNivelImportancia(NivelImportancia, other.NivelImportancia);
    }

    private int CompararNivelImportancia(string nivel1, string nivel2)
    {
        var niveles = new List<string> { "premium", "normal", "promo" };
        return niveles.IndexOf(nivel1).CompareTo(niveles.IndexOf(nivel2));
    }

    public override string ToString()
    {
        return $"Pedido ID: {Id}, Fecha y Hora: {FechaHoraRecepcion}, Cliente ID: {IdCliente}, Nivel de Importancia: {NivelImportancia}, Descripción: {Descripcion}";
    }
}

class Program
{
    static void Main()
    {
        string filePath = "order.in";
        List<Pedido> pedidos = LeerPedidosDesdeArchivo(filePath);

        pedidos.Sort();

        foreach (var pedido in pedidos)
        {
            Console.WriteLine(pedido);
        }
    }

    static List<Pedido> LeerPedidosDesdeArchivo(string filePath)
    {
        List<Pedido> pedidos = new List<Pedido>();

        foreach (var linea in File.ReadLines(filePath))
        {
            var partes = linea.Split(',');

            int id = int.Parse(partes[0]);
            DateTime fechaHoraRecepcion = DateTime.Parse(partes[1]);
            int idCliente = int.Parse(partes[2]);
            string nivelImportancia = partes[3];
            string descripcion = partes[4];

            Pedido pedido = new Pedido(id, fechaHoraRecepcion, idCliente, nivelImportancia, descripcion);
            pedidos.Add(pedido);
        }

        return pedidos;
    }
}