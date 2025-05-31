namespace ArbolesAVL
{
    internal class Program
    {
        static void Main()
        {
            ArbolAVL arbol = new ArbolAVL();
            int[] valores = { 65, 50, 23, 70, 82, 68, 39 };

            foreach (var valor in valores)
            {
                arbol.Insertar(valor);
            }

            Console.WriteLine("Recorrido en orden del árbol AVL:");
            arbol.ImprimirPreOrden();
        }
    }
}
