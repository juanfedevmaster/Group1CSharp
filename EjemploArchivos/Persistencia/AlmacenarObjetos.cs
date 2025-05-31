using Entidades;
using Entidades.Enum;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Persistencia
{
    public class AlmacenarObjetos
    {
        public string Path { get; set; }

        public string Name { get; set; }

        public TipoArchivoEnum Type { get; set; }

        public AlmacenarObjetos(string path, string name, TipoArchivoEnum type)
        {
            Path = path;
            Name = name;
            Type = type;
        }

        public bool GuardarObjeto(Vehiculo vehiculo, TipoVehiculoEnum tipoVehiculo)
        {
            switch (Type)
            {
                case TipoArchivoEnum.Texto:
                    return GuardarObjetoTexto(vehiculo, tipoVehiculo);
                case TipoArchivoEnum.Csv:
                    return GuardarObjetoCsv(vehiculo, tipoVehiculo);
                case TipoArchivoEnum.JSON:
                    return GuardarObjetoJson(vehiculo, tipoVehiculo);
            }

            return false;
        }

        private bool GuardarObjetoTexto(Vehiculo vehiculo, TipoVehiculoEnum tipoVehiculo)
        {
            if (vehiculo == null)
                return false;

            var sb = new StringBuilder();
            var fullPath = $"{Path}\\{Name}.txt";
            // Mas Legible pero menos generico.

            switch (tipoVehiculo)
            {
                case TipoVehiculoEnum.Coche:
                    var coche = (Coche)vehiculo;
                    sb.Append(coche.NumeroPuertas).Append("|");
                    break;
                case TipoVehiculoEnum.Motocicleta:
                    var moto = (Motocicleta)vehiculo;
                    sb.Append(moto.TipoMotor).Append("|");
                    break;
            }

            sb.Append(vehiculo.Marca).Append("|");
            sb.Append(vehiculo.Matricula).Append("|");
            sb.Append(vehiculo.Color).Append("|");
            sb.Append(vehiculo.Modelo).Append("|");
            sb.Append(vehiculo.Cilindrada).Append("|");
            sb.Append(tipoVehiculo);
            sb.AppendLine();

            File.AppendAllText(fullPath, sb.ToString(), Encoding.UTF8);

            /*
            
            Menos Legible pero mas generico

            PropertyInfo[] propiedades = vehiculo.GetType().GetProperties();
            
            var sb = new StringBuilder();
            foreach (var propiedad in propiedades)
            {
                object valor = propiedad.GetValue(vehiculo);
                string valorString = valor == null ? string.Empty : valor.ToString();
                sb.Append(valorString).Append("|");
            }

            sb.AppendLine();*/

            return true;
        }

        private bool GuardarObjetoCsv(Vehiculo vehiculo, TipoVehiculoEnum tipoVehiculo)
        {
            if (vehiculo == null)
                return false;

            var fullPath = $"{Path}\\{Name}.csv";

            var necesitaEncavezado = !File.Exists(fullPath) || new FileInfo(fullPath).Length == 0;

            using (var sw = File.AppendText(fullPath))
            {
                if (necesitaEncavezado)
                {
                    sw.WriteLine("TipoVehiculo,NumeroPuertas,TipoMotor,Marca,Matricula,Color,Modelo,Cilindrada");
                }

                switch (tipoVehiculo)
                {
                    case TipoVehiculoEnum.Coche:
                        var coche = (Coche)vehiculo;
                        sw.WriteLine($"{tipoVehiculo},{coche.NumeroPuertas},N/A,{coche.Marca},{coche.Matricula},{coche.Color},{coche.Modelo},{coche.Cilindrada}");
                        break;
                    case TipoVehiculoEnum.Motocicleta:
                        var moto = (Motocicleta)vehiculo;
                        sw.WriteLine($"{tipoVehiculo},N/A,{moto.TipoMotor},{moto.Marca},{moto.Matricula},{moto.Color},{moto.Modelo},{moto.Cilindrada}");
                        break;
                }
            }

            return true;
        }

        private bool GuardarObjetoJson(Vehiculo vehiculo, TipoVehiculoEnum tipoVehiculo)
        {
            if (vehiculo == null)
                return false;

            var fullPath = $"{Path}\\{Name}.json";

            var json = JsonSerializer.Serialize(vehiculo, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fullPath, json, Encoding.UTF8);

            return true;
        }

        public bool GuardarObjetoJsonLista(List<Vehiculo> vehiculoLista)
        {
            if (vehiculoLista == null)
                return false;

            var fullPath = $"{Path}\\{Name}.json";

            var json = JsonSerializer.Serialize(vehiculoLista, new JsonSerializerOptions { WriteIndented = false });
            File.WriteAllText(fullPath, json, Encoding.UTF8);

            return true;
        }
    }
}
