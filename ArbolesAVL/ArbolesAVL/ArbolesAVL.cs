namespace ArbolesAVL
{
    using System;

    public class NodoAVL
    {
        public int Valor;
        public NodoAVL Izquierda;
        public NodoAVL Derecha;
        public int Altura;

        public NodoAVL(int valor)
        {
            Valor = valor;
            Altura = 1;
        }
    }

    public class ArbolAVL
    {
        private NodoAVL raiz;

        public void Insertar(int valor)
        {
            raiz = Insertar(raiz, valor);
        }

        private NodoAVL Insertar(NodoAVL nodo, int valor)
        {
            if (nodo == null)
                return new NodoAVL(valor);

            if (valor < nodo.Valor)
                nodo.Izquierda = Insertar(nodo.Izquierda, valor);
            else if (valor > nodo.Valor)
                nodo.Derecha = Insertar(nodo.Derecha, valor);
            else
                return nodo; // No se permiten duplicados

            // Actualizar altura
            nodo.Altura = 1 + Math.Max(ObtenerAltura(nodo.Izquierda), ObtenerAltura(nodo.Derecha));

            // Obtener factor de balanceo
            int balance = ObtenerBalance(nodo);

            // Aplicar rotaciones si es necesario

            // Rotación simple a la derecha
            if (balance > 1 && valor < nodo.Izquierda.Valor)
            {
                Console.WriteLine("Rotación Derecha (LL)");
                return RotarDerecha(nodo);
            }

            // Rotación simple a la izquierda
            if (balance < -1 && valor > nodo.Derecha.Valor)
            {
                Console.WriteLine("Rotación Izquierda (RR)");
                return RotarIzquierda(nodo);
            }

            // Rotación doble Izquierda-Derecha
            if (balance > 1 && valor > nodo.Izquierda.Valor)
            {
                Console.WriteLine("Rotación Izquierda-Derecha (LR)");
                nodo.Izquierda = RotarIzquierda(nodo.Izquierda);
                return RotarDerecha(nodo);
            }

            // Rotación doble Derecha-Izquierda
            if (balance < -1 && valor < nodo.Derecha.Valor)
            {
                Console.WriteLine("Rotación Derecha-Izquierda (RL)");
                nodo.Derecha = RotarDerecha(nodo.Derecha);
                return RotarIzquierda(nodo);
            }

            return nodo;
        }

        private int ObtenerAltura(NodoAVL nodo)
        {
            return nodo?.Altura ?? 0;
        }

        private int ObtenerBalance(NodoAVL nodo)
        {
            return nodo == null ? 0 : ObtenerAltura(nodo.Izquierda) - ObtenerAltura(nodo.Derecha);
        }

        private NodoAVL RotarDerecha(NodoAVL y)
        {
            NodoAVL x = y.Izquierda;
            NodoAVL T2 = x.Derecha;

            // Rotación
            x.Derecha = y;
            y.Izquierda = T2;

            // Actualizar alturas
            y.Altura = 1 + Math.Max(ObtenerAltura(y.Izquierda), ObtenerAltura(y.Derecha));
            x.Altura = 1 + Math.Max(ObtenerAltura(x.Izquierda), ObtenerAltura(x.Derecha));

            return x;
        }

        private NodoAVL RotarIzquierda(NodoAVL x)
        {
            NodoAVL y = x.Derecha;
            NodoAVL T2 = y.Izquierda;

            // Rotación
            y.Izquierda = x;
            x.Derecha = T2;

            // Actualizar alturas
            x.Altura = 1 + Math.Max(ObtenerAltura(x.Izquierda), ObtenerAltura(x.Derecha));
            y.Altura = 1 + Math.Max(ObtenerAltura(y.Izquierda), ObtenerAltura(y.Derecha));

            return y;
        }

        public void ImprimirPreOrden()
        {
            ImprimirPreOrden(raiz);
            Console.WriteLine();
        }

        private void ImprimirPreOrden(NodoAVL nodo)
        {
            if (nodo != null)
            {
                Console.Write(nodo.Valor + " ");
                ImprimirPreOrden(nodo.Izquierda);
                ImprimirPreOrden(nodo.Derecha);
            }
        }
    }

}
