namespace Veterinaria.WebAPI.DTOs
{
    public class MascotaDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Especie { get; set; }
        public string? Raza { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad
        {
            get
            {
                return (int)((DateTime.Now - FechaNacimiento).TotalDays / 365.25);
            }
        }
    }
}
