namespace HelloWorldConsoleApp
{
    /// <summary>
    /// Is the main class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Is the main method.
        /// </summary>
        /// <param name="args">are the argument to initialice the program.</param>
        static void Main(string[] args)
        {
            // >, <, ==, !=, >=, <= Operadores Relacionales
            // && - || Operadores Logicos
            var a = 1;
            var b = 2;
            
         
            var flag = (a > b) | ((a/0) > 0) | (a > 2);

            Console.WriteLine(flag);
            
            //Int16 Rango: -32,768 a 32,767 - 2^15
            //Int 32 Rango: -9,223,372,036,854,775,808 a 9,223,372,036,854,775,807 2^63
            //Int 64 Rango:  0 a 18,446,744,073,709,551,615 2^64 - 1
            //Int 128 170,141,183,460,469,231,731,687,303,715,884,105,727 2^128 - 1 

            //Console.WriteLine("Hello, what is your name?");
            //var name = Console.ReadLine();

            //Console.WriteLine("Nice, How old are you? ");

            //var years = Int32.Parse(Console.ReadLine());

            //Console.WriteLine($"Ok, you are: {name} with {years} years old.");
        }


    }
}
