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
                Final = nuevoNodo;
            }
            else
            {
                nuevoNodo.Siguiente = Cabeza;
                Cabeza.Anterior = nuevoNodo;
                Cabeza = nuevoNodo;
            }

            Tamaño++;
        }

        public void InsertarMitad(int valor)
        {
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

        public void InsertarAlFinal(int valor)
        {
            Nodo nuevoNodo = new Nodo(valor, null, null);

            if (Cabeza == null)
            {
                Cabeza = nuevoNodo;
                Final = nuevoNodo;
            }
            else { 
                Final.Siguiente = nuevoNodo;
                nuevoNodo.Anterior = Final;
                Final = nuevoNodo;
            }

            Tamaño++;
        }

        public bool EliminarElemento(int valor)
        {
            Nodo actual = Buscar(valor);

            Nodo nodoAnterior = null;
            Nodo nodoSiguiente = null;

            bool encontrado = actual == null ? false : true;

            if (!encontrado)
            {
                return false;
            }


            if (actual == Cabeza)
            {
                Cabeza = actual.Siguiente;
                Cabeza.Anterior = null;
                actual.Siguiente = null;
            }
            else if (actual == Final)
            {
                Final = actual.Anterior;
                Final.Siguiente = null;
                actual.Anterior = null;
            }
            else
            {

                nodoAnterior = actual.Anterior;
                nodoSiguiente = actual.Siguiente;

                nodoAnterior.Siguiente = nodoSiguiente;
                nodoSiguiente.Anterior = nodoAnterior;

                actual.Siguiente = null;
                actual.Anterior = null;
            }

            Tamaño--;

            return true;
        }

        public bool ActualizarNodo(int valor, int valorActualizado)
        {
            Nodo actual = Buscar(valor);

            if (actual == null)
            {
                return false;
            }

            actual.Valor = valorActualizado;
            return true;
        }

        public Nodo Buscar(int valor)
        {

            Nodo actual = Cabeza;

            while (actual != null)
            {
                if (actual.Valor == valor)
                {
                    return actual;
                }
                else
                {
                    actual = actual.Siguiente;
                }
            }

            return null;
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
