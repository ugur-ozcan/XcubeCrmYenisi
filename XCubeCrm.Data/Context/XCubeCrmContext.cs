using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using XCubeCrm.Data.Context.XCubeCrmMigration;
using XCubeCrm.Model.Entities;

namespace XCubeCrm.Data.Context
{
    public class XCubeCrmContext : BaseDbContext<XCubeCrmContext, Configuration>
    {
        public XCubeCrmContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }
        public XCubeCrmContext(string connectionString) : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
        public DbSet<Il> Il { get; set; }
        public DbSet<Ilce> Ilce { get; set; }
        public DbSet<Okul> Okul { get; set; }
        public DbSet<Filtre> Filter { get; set; }
        public DbSet<Parametreler> Parametreler { get; set; }
        public DbSet<Tip> Tip { get; set; }
        public DbSet<NumaralamaKontrol> NumaralamaKontrol { get; set; }
        public DbSet<AcikFatura> AcikFatura { get; set; }
        public DbSet<Tanimlar> Tanimlar { get; set; }
        public DbSet<HesaplamaParametreleri> HesaplamaParametreleri { get; set; }
        public DbSet<Firma> Firma { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Mutabakat> Mutabakat { get; set; }
    }
}
