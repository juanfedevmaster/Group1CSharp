using MongoDB.Driver;
using MongoDBExample.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBExample.Servicios
{
    public class ProductoDB
    {
        private readonly IMongoCollection<Producto> _productos;

        public ProductoDB() {
            var client = new MongoClient("mongodb+srv://juanfedevmaster:admin@clustertalentotech.ghmwc6y.mongodb.net/");
            var database = client.GetDatabase("TalentoTechDB");
            _productos = database.GetCollection<Producto>("Productos");
        }

        public bool CrearProductoDB(Producto p) { 
            this._productos.InsertOne(p);
            Console.WriteLine("Producto insertado");
            return true;
        }

        public bool ModificarProductoDB(long productId, string nombreModificar) {

            Producto p = ConsultarProductoDB(productId);
            p.Nombre = nombreModificar;
            _productos.ReplaceOne(p => p.IdProducto == productId, p);

            return true;
        }

        public Producto ConsultarProductoDB(long productId) {
            Producto p = _productos.Find(p => p.IdProducto == productId).FirstOrDefault();
            return p;
        }

        public void EliminarProductoDB(long productId) {
            _productos.DeleteOne(p => p.IdProducto == productId);
            Console.WriteLine("Producto Eliminado Correctamente");
        }
    }
}
