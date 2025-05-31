namespace Veterinaria.WebAPI.Entidades
{

    public class Mascota
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Especie { get; set; }
        public string? Raza { get; set; }
        public DateTime FechaNacimiento { get; set; }

        // Calcula la edad de la mascota en años
        public int ObtenerEdad()
        {
            var hoy = DateTime.Today;
            var edad = hoy.Year - FechaNacimiento.Year;
            if (FechaNacimiento.Date > hoy.AddYears(-edad)) edad--;
            return edad;
        }

        // Devuelve una descripción breve de la mascota
        public string ObtenerDescripcion()
        {
            return $"{Nombre ?? "Sin nombre"} - {Especie ?? "Desconocida"} ({Raza ?? "Sin raza"})";
        }

        // Verifica si la mascota es de una especie específica
        public bool EsEspecie(string especie)
        {
            return string.Equals(Especie, especie, StringComparison.OrdinalIgnoreCase);
        }

        // Actualiza el nombre de la mascota
        public void CambiarNombre(string nuevoNombre)
        {
            if (!string.IsNullOrWhiteSpace(nuevoNombre))
            {
                Nombre = nuevoNombre;
            }
        }
    }
}
