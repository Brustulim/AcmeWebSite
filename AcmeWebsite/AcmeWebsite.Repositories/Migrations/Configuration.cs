using System.Data.Entity.Migrations;
using AcmeWebsite.Repositories.Seeds;

namespace AcmeWebsite.Repositories.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EfDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EfDbContext context)
        {
            ContactSeed.Seed(context);
        }
    }
}
