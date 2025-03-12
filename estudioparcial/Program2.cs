using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[,] bodega = {
            { 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 0, 0, 1 },
            { 1, 0, 0, 0, 2, 1 },
            { 1, 0, 0, 3, 1, 1 },
            { 1, 1, 1, 1, 1, 1 }
        };

        var inicio = (3, 3);
        var fin = (2, 4);

        var ruta = CalcularRuta(bodega, inicio, fin);

        if (ruta != null)
        {
            Console.WriteLine("Ruta encontrada:");
            foreach (var paso in ruta)
            {
                Console.WriteLine($"[{paso.Item1}, {paso.Item2}]");
            }
        }
        else
        {
            Console.WriteLine("No se encontró una ruta.");
        }
    }

    static List<(int, int)> CalcularRuta(int[,] bodega, (int, int) inicio, (int, int) fin)
    {
        int filas = bodega.GetLength(0);
        int columnas = bodega.GetLength(1);
        bool[,] visitado = new bool[filas, columnas];
        (int, int)[,] predecesor = new (int, int)[filas, columnas];

        Queue<(int, int)> cola = new Queue<(int, int)>();
        cola.Enqueue(inicio);
        visitado[inicio.Item1, inicio.Item2] = true;

        int[] dirFilas = { -1, 1, 0, 0 };
        int[] dirColumnas = { 0, 0, -1, 1 };

        while (cola.Count > 0)
        {
            var actual = cola.Dequeue();

            if (actual == fin)
            {
                return ReconstruirRuta(predecesor, inicio, fin);
            }

            for (int i = 0; i < 4; i++)
            {
                int nuevaFila = actual.Item1 + dirFilas[i];
                int nuevaColumna = actual.Item2 + dirColumnas[i];

                if (EsValido(nuevaFila, nuevaColumna, filas, columnas) && bodega[nuevaFila, nuevaColumna] != 1 && !visitado[nuevaFila, nuevaColumna])
                {
                    cola.Enqueue((nuevaFila, nuevaColumna));
                    visitado[nuevaFila, nuevaColumna] = true;
                    predecesor[nuevaFila, nuevaColumna] = actual;
                }
            }
        }

        return null;
    }

    static bool EsValido(int fila, int columna, int filas, int columnas)
    {
        return fila >= 0 && fila < filas && columna >= 0 && columna < columnas;
    }

    static List<(int, int)> ReconstruirRuta((int, int)[,] predecesor, (int, int) inicio, (int, int) fin)
    {
        List<(int, int)> ruta = new List<(int, int)>();
        var actual = fin;

        while (actual != inicio)
        {
            ruta.Add(actual);
            actual = predecesor[actual.Item1, actual.Item2];
        }

        ruta.Add(inicio);
        ruta.Reverse();

        return ruta;
    }
}