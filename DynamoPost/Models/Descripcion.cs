using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamoPost.Models
{
    public class Descripcion
    {
        [DynamoDBProperty("pelo")]
        public String Pelo { get; set; }

        [DynamoDBProperty("ojos")]
        public String Ojos { get; set; }

        [DynamoDBProperty("villano")]
        public bool Villano { get; set; }
    }
}
