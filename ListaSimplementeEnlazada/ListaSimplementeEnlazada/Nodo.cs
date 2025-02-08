namespace ListaSimplementeEnlazada
{
    public class Nodo
    {
        public int Valor { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo() { }

        public Nodo(int valor, Nodo siguiente)
        {
            Valor = valor;
            Siguiente = siguiente;
        }
    }
}
