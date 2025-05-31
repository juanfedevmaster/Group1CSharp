using MongoDBExample.Entidades;
using MongoDBExample.Servicios;

namespace MongoDBExample
{
    internal class Program
    {
        private static ProductoDB _productoDB;
        static void Main(string[] args)
        {
            _productoDB = new ProductoDB();

            bool exit = false;
            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Crear producto");
                Console.WriteLine("2. Modificar producto");
                Console.WriteLine("3. Eliminar producto");
                Console.WriteLine("4. Consultar producto");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        CrearProducto();
                        break;
                    case "2":
                        ModificarProducto();
                        break;
                    case "3":
                        EliminarProducto();
                        break;
                    case "4":
                        ConsultarProducto();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida, intente de nuevo.");
                        break;
                }
            } while (!exit);
        }

        static void CrearProducto()
        {
            Console.Write("Ingre el nombre del Producto: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese la descripción del Producto: ");
            string descripcion = Console.ReadLine();
            Console.Write("Ingrese el precio del Producto: ");
            decimal precio = Decimal.Parse(Console.ReadLine());

            Producto p = new Producto(nombre, descripcion, precio);
            
            bool seInserto = _productoDB.CrearProductoDB(p);
            if (seInserto)
            {
                Console.WriteLine($"Producto creado: {p.Nombre}, {p.Descripcion}, {p.Precio}");
            }
        }

        static void ModificarProducto()
        {
            Console.Write("Ingre el Id del Producto: ");
            long id = long.Parse(Console.ReadLine());

            Console.Write("Ingrese el nuevo nombre del Producto: ");
            string nombre = Console.ReadLine();

            bool seModifico = _productoDB.ModificarProductoDB(id, nombre);
            if (seModifico) {
                Console.WriteLine($"Se modifico el producto con Id: {id}");
            }
        }

        static void EliminarProducto()
        {
            Console.Write("Ingre el Id del Producto: ");
            long id = long.Parse(Console.ReadLine());

            _productoDB.EliminarProductoDB(id);
        }

        static void ConsultarProducto()
        {
            Console.Write("Ingre el Id del Producto: ");
            long id = long.Parse(Console.ReadLine());

            Producto p = _productoDB.ConsultarProductoDB(id);
            if (p != null)
            {
                Console.WriteLine($"Producto encontrado: {p.Nombre}, {p.Descripcion}, {p.Precio}");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
            // Lógica para buscar el producto por ID y mostrarlo
        }
    }
}
