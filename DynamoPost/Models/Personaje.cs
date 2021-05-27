using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamoPost.Models
{
    [DynamoDBTable("dynamopersonajes")]
    public class Personaje
    {
        [DynamoDBProperty("idpersonaje")]
        [DynamoDBHashKey]
        public int IdPersonaje { get; set; }

        [DynamoDBProperty("pelicula")]
        public String Pelicula { get; set; }

        [DynamoDBProperty("nombre")]
        public String Nombre { get; set; }

        [DynamoDBProperty("descripcion")]
        public Descripcion Descripcion { get; set; }

    }
}
