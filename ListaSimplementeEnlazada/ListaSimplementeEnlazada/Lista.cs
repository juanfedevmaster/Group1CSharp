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
        public Nodo Final { get; set; }

        public Lista() { }

        public void InsertarInicio(int valor)
        {
            Nodo nuevoNodo = new Nodo(valor, null);

            if (Cabeza == null)
            {
                Cabeza = nuevoNodo;
            }
            else
            {
                nuevoNodo.Siguiente = Cabeza;
                Cabeza = nuevoNodo;
            }
        }

        public void InsertarFinal(int valor)
        {

            Nodo nuevoNodo = new Nodo(valor, null);

            if (Cabeza == null)
            {
                Cabeza = nuevoNodo;
                Final = nuevoNodo;
            }
            else
            {

                Final.Siguiente = nuevoNodo;
                Final = nuevoNodo;

                // TODO: Implementación Basica de Insertar al final
                /*
                    Nodo actual = Cabeza;
                    while (actual.Siguiente != null)
                    {
                        actual = actual.Siguiente;
                    }
                    actual.Siguiente = nuevoNodo;
                */
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

        public void Buscar(int valor)
        {
            Nodo actual = Cabeza;
            int i = 0;
            while (actual != null)
            {

                if (actual.Valor == valor)
                {
                    Console.WriteLine($"Valor encontrado: {valor} en la posición {i}");
                    return;
                }

                Console.WriteLine("Valor no encontrado");
                actual = actual.Siguiente;
                i++;
            }

            Console.WriteLine("Valor no existe en la lista");
        }
    }
}
