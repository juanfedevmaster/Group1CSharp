namespace ListaSimplementeEnlazada
{
    public class Program
    {
        static void Main(string[] args)
        {
            Lista lista = new Lista();
            lista.InsertarInicio(5);
            lista.InsertarInicio(10);
            lista.InsertarInicio(15);
            lista.InsertarInicio(20);
            lista.InsertarInicio(25);

            lista.Recorrer();

            List<int> listaReal = new List<int>();
            listaReal.Add(5);
            listaReal.Add(10);
            listaReal.Add(15);
            listaReal.Add(20);
            listaReal.Add(25);

            Console.WriteLine("=================================");

            for (int i = 0; i < listaReal.Count; i++)
            {
               Console.WriteLine(listaReal[i]);
            }
        }
    }
}
