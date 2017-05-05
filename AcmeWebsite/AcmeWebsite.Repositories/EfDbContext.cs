using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using AcmeWebsite.Domain.Entities;
using AcmeWebsite.Repositories.EntityTypeConfigurations;

namespace AcmeWebsite.Repositories
{
    public class EfDbContext : DbContext
    {

        //ConnectionString need to be created on WebApi Project (or Asp.Net MVC) in web.config
        public EfDbContext() : base("AcmeWebsiteConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Contact> Contacts { get; set; }
        //Others Entities (Tables) goes here

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Previne DB Columns be created as nVarchar
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            //Previne Db Columns (without configuration) be created as nvarchar(max)
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(50));

            //Entities (tables) Configurations
            modelBuilder.Configurations.Add(new ContactConfigurations());
        }
    

    }
}
