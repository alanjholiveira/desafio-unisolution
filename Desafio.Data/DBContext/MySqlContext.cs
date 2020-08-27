using Microsoft.EntityFrameworkCore;
using Desafio.Domain.Entities;

namespace Desafio.Data.DBContext
{
    public class MySqlContext : DbContext
    {
        public MySqlContext() {}

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

        public DbSet<Tanque> Tanques { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
