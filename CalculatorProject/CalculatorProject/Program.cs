namespace CalculatorProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*  Crea un programa en C# que simule una calculadora básica.
                El programa debe cumplir con los siguientes requisitos:
                Presenta un menú con las siguientes opciones:
                    ================================
                    1. Sumar
                    2. Restar
                    3. Multiplicar
                    4. Dividir
                    5. Salir
                    Ingrese la opción deseada:
             */

            string? option = "5";

            do
            {
                Console.WriteLine("================================");
                Console.WriteLine("1. Sumar");
                Console.WriteLine("2. Restar");
                Console.WriteLine("3. Multiplicar");
                Console.WriteLine("4. Dividir");
                Console.WriteLine("5. Salir");
                Console.WriteLine("Ingrese la opción deseada: ");
                option = Console.ReadLine();

                if (option != null && option.Equals("1"))
                {
                    Console.WriteLine("Cuantos números desea sumar: ");
                    var amout = Convert.ToInt32(Console.ReadLine());
                    int resultSum = 0;

                    var resultFunction = Suma(amout, resultSum);

                    Console.WriteLine($"El resultado es: {resultFunction}");
                }
                else if (option != null && option.Equals("2"))
                {
                    Console.WriteLine("Cuantos números desea restar: ");
                    var amout = Convert.ToInt32(Console.ReadLine());
                    int result = 0;

                    for (int i = 0; i < amout; i ++)
                    {
                        Console.WriteLine("Ingrese número:");
                        result -= Convert.ToInt32(Console.ReadLine());
                    }
                    
                    Console.WriteLine($"El resultado es: {result}");
                }
                else if (option != null && option.Equals("3"))
                {
                    Console.WriteLine("Multiplique los números.");
                }
                else if (option != null && option.Equals("4"))
                {
                    Console.WriteLine("Divida los números.");
                }
                else if (option != null && option.Equals("5"))
                {
                    Console.WriteLine("Finalice el programa.");
                }
                else
                {
                    Console.WriteLine("Ingreso una opción inválida, intentelo nuevamente");
                }
            } while (!option.Equals("5"));
        }

        static int Suma(int amount, int result) {

            for (int i = 0; i < amount; i = i + 1)
            {
                Console.WriteLine("Ingrese número:");
                result = result + Convert.ToInt32(Console.ReadLine());
            }

            return result;
            
        }
    }
}
