using Afro.Ranking.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Afro.Ranking.Persistance
{
    public class ApplicationContext : IdentityDbContext<Admin>
    {
      public ApplicationContext() { }
       public ApplicationContext(DbContextOptions<ApplicationContext> options) :base(options) { }
       public DbSet<Admin> Admin { get; set; }
        public DbSet<Influencer> Influencer { get; set; }
        public DbSet<YouTube> YouTube { get; set; }
        public DbSet<FaceBook> FaceBook { get; set; }
        public DbSet<Instagram> Instagram { get; set; }
        public DbSet<CountryMapData> Country { get; set; }
        public DbSet<CityMapData> City { get; set; }

        public DbSet<Twitter> Twitter { get; set; }
        public DbSet<TikTok> TikTok { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-7CRO7SVO\\SQLEXPRESS;Initial Catalog=Afro-Ranging;Integrated Security=True;Connect Timeout=60;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder builder) => base.OnModelCreating(builder);
    }
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        ApplicationContext IDesignTimeDbContextFactory<ApplicationContext>.CreateDbContext(string[] args)
        {
            var dbOptionBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            dbOptionBuilder.UseSqlServer("Data Source=LAPTOP-7CRO7SVO\\SQLEXPRESS;Initial Catalog=Afro-Ranging;Integrated Security=True;Connect Timeout=60;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            return new ApplicationContext(dbOptionBuilder.Options);
        }
    }
}