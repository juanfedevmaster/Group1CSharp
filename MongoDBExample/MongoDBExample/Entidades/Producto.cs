using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBExample.Entidades
{
    public class Producto
    {
        public ObjectId Id { get; set; }

        public long IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        public Producto() { }
        public Producto(string nombre, string descripcion, decimal precio)
        {
            IdProducto = new Random().Next(1, 1000000);
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
        }
    }
}
