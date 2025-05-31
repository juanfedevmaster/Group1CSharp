using PrincipiosSOLID.DependencyInversion;
using PrincipiosSOLID.DependencyInversion.TiposDeMotor;
using PrincipiosSOLID.InterfaceSegregation;
using PrincipiosSOLID.OpenClose;
using PrincipiosSOLID.SingleResponsability;

namespace PrincipiosSOLID
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ejemplo Single Resposability");
            // Crear un nuevo empleado
            Empleado empleado = new Empleado("Juan", "Pérez", "Desarrollador", 50000);
            ImpuestoEmpleados impuestoEmpleados = new ImpuestoEmpleados();
            EmpleadoRespository empleadoRespository = new EmpleadoRespository();

            Console.WriteLine($"Impuesto de Retefuente al Empleado es de: {impuestoEmpleados.CalcularImpuestoRetencionFuente(empleado)}");
            Console.WriteLine($"Impuesto Solidario al Empleado es de: {impuestoEmpleados.CalcularImpuestoSolidario(empleado)}");

            var empleados = empleadoRespository.ObtenerTodos();
            foreach (var emp in empleados)
            {
                Console.WriteLine($"Empleado: {emp.Nombre} {emp.Apellido}, Cargo: {emp.Puesto}, Salario: {emp.Salario}");
            }
            Console.WriteLine("*********************************");
            Console.WriteLine("Ejemplo Open Close");
            var empleadosPorPuesto = empleadoRespository.ObtenerPorPuesto("Desarrollador");
            foreach (var emp in empleadosPorPuesto)
            {
                Console.WriteLine($"Empleado: {emp.Nombre} {emp.Apellido}, Cargo: {emp.Puesto}, Salario: {emp.Salario}");
            }
            Console.WriteLine("*********************************");
            Console.WriteLine("Liskov Sustitution");
            // Crear un nuevo empleado
            Empleado empleado1 = new Empleado("Ana", "Gómez", "Diseñadora", 40000);
            Empleado empleado2 = new Empleado("Pedro", "López", "Gerente", 80000);

            IEmpleadoRepository empRepo = new EmpleadoRespository();
            IEmpleadoRepository empRepoOracle = new EmpleadoRepositoryOracle();

            empRepoOracle.Guardar(empleado1);
            empRepo.Guardar(empleado1);
            Console.WriteLine("*********************************");
            Console.WriteLine("Interface Segregation");

            IEliminarRepo eliminarRepo = new EmpleadoRepositoryOracle();
            eliminarRepo.Eliminar(empleado1);
            Console.WriteLine("*********************************");
            Console.WriteLine("Dependency Inversion");
            IMotor motor1 = new M3BMW();
            IMotor motor2 = new vTechHonda();
            IMotor motor3 = new YamahaE040J();



            Vehiculo bmwm30 = new Carro(motor1);
            Vehiculo hondaCivic2001 = new Carro(motor2);
            Vehiculo lanchaRapida = new Barco(motor3);
            
            bmwm30.Encender();
            hondaCivic2001.Encender();
            lanchaRapida.Encender();


            bmwm30.Apagar();
            hondaCivic2001.Apagar();
            lanchaRapida.Apagar();

            Console.WriteLine("El BmwE30 se le fundio el motor, se le cambia por motor VTEC");
            bmwm30.Motor = new vTechHonda();
            bmwm30.Encender();
            bmwm30.Apagar();
            Console.WriteLine("*********************************");
        }
    }
}
