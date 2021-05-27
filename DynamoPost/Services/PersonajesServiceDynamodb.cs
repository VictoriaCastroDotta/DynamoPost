using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using DynamoPost.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamoPost.Services
{
    public class PersonajesServiceDynamodb
    {
        private DynamoDBContext context;

        public PersonajesServiceDynamodb()
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            this.context = new DynamoDBContext(client);
        }

        public async Task CreatePersonaje(Personaje personaje)
        {
            await this.context.SaveAsync<Personaje>(personaje);
        }

        public async Task<List<Personaje>> GetPersonajes()
        {
            var tabla = this.context.GetTargetTable<Personaje>();
            var scanOptions = new ScanOperationConfig();
            var results = tabla.Scan(scanOptions);
            List<Document> data = await results.GetNextSetAsync();
            IEnumerable<Personaje> personajes = this.context.FromDocuments<Personaje>(data);
            return personajes.ToList();
        }

        public async Task<Personaje> FindPersonaje(int idpersonaje)
        {
            return await this.context.LoadAsync<Personaje>(idpersonaje);
        }

        public async Task DeletePersonaje(int idpersonaje)
        {
            await this.context.DeleteAsync<Personaje>(idpersonaje);
        }
    }
}
