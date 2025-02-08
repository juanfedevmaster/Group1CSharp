using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDoblementeEnlazada
{
    public class Lista
    {
        public Nodo Cabeza { get; set; }
        public Nodo Final { get; set; }
        public int Tamaño { get; set; }

        public Lista()
        {
            Tamaño = 0;
        }

        public void InsertarInicio(int valor)
        {
            Nodo nuevoNodo = new Nodo(valor, null, null);

            if (Cabeza == null)
            {
                Cabeza = nuevoNodo;
            }
            else
            {
                nuevoNodo.Siguiente = Cabeza;
                Cabeza.Anterior = nuevoNodo;
                Cabeza = nuevoNodo;
            }

            Tamaño++;
        }

        public void InsertarMitad(int valor) {
            Nodo nuevoNodo = new Nodo(valor, null, null);

            int posicion = (Tamaño / 2);
            int cont = 0;

            Nodo actual = Cabeza;

            while (cont < posicion)
            {
                actual = actual.Siguiente;
                cont++;
            }

            Nodo nodoAnterior = actual.Anterior;

            actual.Anterior = nuevoNodo;
            nodoAnterior.Siguiente = nuevoNodo;

            nuevoNodo.Siguiente = actual;
            nuevoNodo.Anterior = nodoAnterior;

            Tamaño++;
        }

        public void Recorrer()
        {
            Nodo actual = Cabeza;
            int cont = 0;
            while (actual != null)
            {
                Console.WriteLine($"Valor del nodo #{cont}: {actual.Valor}");
                actual = actual.Siguiente;
                cont++;
            }

            Console.WriteLine($"Tamaño de la lista: {Tamaño}");
        }
    }
}
