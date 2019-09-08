namespace ETC.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SparesContext : DbContext
    {
        public SparesContext()
            : base("name=SparesContext")
        {
        }
        public DbSet<Catalog> CatalogItems { get; set; }
        public DbSet<Catalog_aggregate> CatalogAggregates { get; set; }
        public DbSet<Catalog_model> CatalogModels { get; set; }
        public DbSet<Catalog_level> Catalog_levels{ get; set; }
    }

}