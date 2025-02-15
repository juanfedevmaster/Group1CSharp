namespace ListaSimplementeEnlazada
{
    public class Program
    {
        static void Main(string[] args)
        {
            Lista lista = new Lista();

            for (int i = 0; i < 1000000; i++)
            {
                Random rand = new Random();
                lista.InsertarInicio(rand.Next(1, 1000000));
            }

            lista.Buscar(58701);

            //lista.Recorrer();

            /*List<int> listaReal = new List<int>();
            listaReal.Add(5);
            listaReal.Add(10);
            listaReal.Add(15);
            listaReal.Add(20);
            listaReal.Add(25);

            Console.WriteLine("=================================");

            for (int i = 0; i < listaReal.Count; i++)
            {
               Console.WriteLine(listaReal[i]);
            }*/
        }
    }
}
