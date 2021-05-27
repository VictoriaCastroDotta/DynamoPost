using Microsoft.EntityFrameworkCore;
using DynamoPost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamoPost.Data
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Personaje> Personajes { get; set; }
    }
}
