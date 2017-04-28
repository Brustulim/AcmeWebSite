namespace AcmeWebsite.Repositories.Migrations
{
    using Seeds;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AcmeWebsite.Repositories.EfDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AcmeWebsite.Repositories.EfDbContext context)
        {
            ContactSeed.Seed(context);
        }
    }
}
