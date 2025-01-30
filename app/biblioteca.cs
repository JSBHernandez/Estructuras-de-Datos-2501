using System;
using System.Collections.Generic;

namespace Biblioteca
{
    internal class Libro
    {
        private string Titulo { get; set; }
        private string Autor { get; set; }
        private int ISBN { get; set; }
        private bool Disponible { get; set; }

        public List<Libro> LibrosPrestados {get; set;} = new List<Libro>();
        public List<Libro> Libros = new List<Libro>();
        public List<Prestamo> Prestamos = new List<Prestamo>();
        private string v1;
        private string v2;
        private long v3;

        public Libro(string titulo, string autor, int isbn)
        {
            Titulo = titulo;
            Autor = autor;
            ISBN = isbn;
            Disponible = true;
        }


        public void PrestarLibro(Libro libro, Usuario usuario)
        {
            if (libro.Disponible)
            {
                libro.Disponible = false;
                LibrosPrestados.Add(libro);
                Prestamo prestamo = new Prestamo(libro, usuario, DateTime.Now, DateTime.Now.AddDays(7));
                Prestamos.Add(prestamo);
                Console.WriteLine($"El libro {libro.Titulo} ha sido prestado a {usuario.Nombre}");
            }
            else {
                Console.WriteLine($"El libro {libro.Titulo} no está disponible");
            }
        }

    }
    internal class Usuario
    {
        public string Nombre { get; set; }

        private int ID { get; set; }

        public List<Usuario> Usuarios = new List<Usuario>();

        public Usuario(string nombre, int id)
        {
            Nombre = nombre;
            ID = id;
        }

        public void AgregarUsuario(Usuario usuario)
        {
            Usuarios.Add(usuario);
        }

    }

    internal class Prestamo 
    {
        public Libro Libro { get; set; }
        public Usuario Usuario { get; set; }
        private DateTime FechaPrestamo { get; set; }
        private DateTime FechaDevolucion { get; set; }

        public Prestamo(Libro libro, Usuario usuario, DateTime fechaPrestamo, DateTime fechaDevolucion)
        {
            Libro = libro;
            Usuario = usuario;
            FechaPrestamo = fechaPrestamo;
            FechaDevolucion = fechaDevolucion;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Libro libro1 = new Libro("El principito", "Antoine de Saint-Exupéry", 13);
            Libro libro2 = new Libro("Cien años de soledad", "Gabriel García Márquez", 12);

            Usuario usuario1 = new Usuario("Juan", 1);
            Usuario usuario2 = new Usuario("María", 2);

            libro1.PrestarLibro(libro1, usuario1);
            libro1.PrestarLibro(libro1, usuario2);

        }
    }
}