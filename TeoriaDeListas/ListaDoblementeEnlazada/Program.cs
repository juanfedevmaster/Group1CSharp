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
            lista.InsertarInicio(25);
            lista.InsertarInicio(30);
            lista.InsertarInicio(35);

            lista.InsertarMitad(100);
            lista.InsertarAlFinal(300);

            lista.Recorrer();

            lista.EliminarElemento(35);
            lista.EliminarElemento(5);
            lista.EliminarElemento(100);
            lista.EliminarElemento(300);
            lista.Recorrer();

            lista.ActualizarNodo(10,200);
            lista.Recorrer();

        }
    }
}
