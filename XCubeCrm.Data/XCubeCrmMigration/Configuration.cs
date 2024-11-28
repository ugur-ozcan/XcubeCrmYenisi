using System.Data.Entity.Migrations;
using XCubeCrm.Data.Context;

namespace XCubeCrm.Data.Context.XCubeCrmMigration
{
    public class Configuration : DbMigrationsConfiguration<XCubeCrmContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; // migration işlerini otomatik yap
            AutomaticMigrationDataLossAllowed = true; // migration sırasında veri kaybı olursa devam et
        }
    }
}
