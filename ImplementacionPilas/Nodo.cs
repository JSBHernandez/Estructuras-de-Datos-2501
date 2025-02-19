using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementacionPilas
{
    internal class Nodo
    {
        #region Declaración de atributos y propiedades de la clase
        
        private int _dato;
        private Nodo _siguiente;

        public int Dato { get; set; }
        public Nodo Siguiente { get; set; }

        #endregion

        #region Constructor de la clase
        public Nodo(int dato)
        {
            Dato = dato;
            Siguiente = null;
        }

        #endregion
    }
}
