namespace ListaDoblementeEnlazada
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lista lista = new Lista();

            lista.InsertarInicio(5);
            lista.InsertarInicio(10);
            lista.InsertarInicio(15);
            lista.InsertarInicio(20);

            lista.InsertarMitad(100);

            lista.Recorrer();

            List<int> lista2 = new List<int>();

            lista2.OrderByDescending(x => x);
            lista2.OrderBy(x => x);
        }
    }
}
