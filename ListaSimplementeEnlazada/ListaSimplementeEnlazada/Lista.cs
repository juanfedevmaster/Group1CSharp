using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaSimplementeEnlazada
{
    public class Lista
    {
        public Nodo Cabeza { get; set; }

        public Lista() { }

        public void InsertarInicio(int valor)
        {
            Nodo nuevoNodo = new Nodo(valor, null);

            if (Cabeza == null)
            {
                Cabeza = nuevoNodo;
            }
            else {
                nuevoNodo.Siguiente = Cabeza;
                Cabeza = nuevoNodo;
            }
        }

        public void Recorrer()
        {
            Nodo actual = Cabeza;
            while (actual != null)
            {
                Console.WriteLine(actual.Valor);
                actual = actual.Siguiente;
            }
        }
    }
}
