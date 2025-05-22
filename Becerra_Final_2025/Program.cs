using System;
using System.Collections.Generic;
 

namespace P1 {
    class Program
{
    static void Main()
    {
        Queue<int> cola = new Queue<int>();
        cola.Enqueue(8);
        cola.Enqueue(3);
        cola.Enqueue(7);
        cola.Enqueue(9);
        cola.Enqueue(5);
 
        Console.WriteLine("Elementos en la cola:");
        foreach (int num in cola)
        {
            Console.Write(num + " ");
        }
 
        int max = int.MinValue;
        foreach (int num in cola)
        {
            if (num > max)
                max = num;
        }
 
        Console.WriteLine("\nEl número mayor en la cola es: " + max);
    }
}
    
}