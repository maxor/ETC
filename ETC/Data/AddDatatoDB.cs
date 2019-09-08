using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETC.Data
{
    public class AddDatatoDB
    {
        void SetCatalog()
        {
            using (var context = new SparesContext())
            {
                context.CatalogItems.Add(new Catalog() { Name = "Volvo" });
                context.CatalogItems.Add(new Catalog(){Name = "ER"});
                context.SaveChanges();
            }
        }
        void SetAggregates()
        {
            using (var context = new SparesContext())
            {
                List<Catalog_aggregate> catalogAggregate = new List<Catalog_aggregate>() {
                    new Catalog_aggregate() {Name ="КПП", Catalog_id = context.CatalogItems.Where(s => s.Id == 1).First() },
                    new Catalog_aggregate() {Name ="Двигатель", Catalog_id = context.CatalogItems.Where(s => s.Id == 2).First() },
                    new Catalog_aggregate() {Name ="КПП", Catalog_id = context.CatalogItems.Where(s => s.Id == 2).First() }
                };
                context.CatalogAggregates.AddRange(catalogAggregate);
                context.SaveChanges();
            }
        }

        void SetModels()
        {
            using (var context = new SparesContext())
            {
                List<Catalog_model> catalogModel = new List<Catalog_model>() {
                    new Catalog_model() {Model ="A365", Catalog_aggregate_id = context.CatalogAggregates.Where(s => s.Id == 1).First() },
                    new Catalog_model() {Model ="M4566", Catalog_aggregate_id = context.CatalogAggregates.Where(s => s.Id == 2).First() },
                    new Catalog_model() {Model ="FG4511", Catalog_aggregate_id = context.CatalogAggregates.Where(s => s.Id == 2).First() },
                    new Catalog_model() {Model ="T45459", Catalog_aggregate_id = context.CatalogAggregates.Where(s => s.Id == 3).First() },
                };
                context.CatalogModels.AddRange(catalogModel);
                context.SaveChanges();
            }
        }

        void SetCatalogLevels()
        {
            using (var context = new SparesContext())
            {
                //add catalog null levels
                List<Catalog> catalog = (from c in context.CatalogItems
                                         select c).ToList();
                foreach(Catalog c in catalog)
                {
                    context.Catalog_levels.Add(new Catalog_level() { Name = c.Name});
                }
                context.SaveChanges();
                //add aggregates
                List<Catalog_aggregate> catalogAggragate = (from ca in context.CatalogAggregates
                                                            select ca).ToList();
                List<Catalog_level> catalogLevel = new List<Catalog_level>();
                foreach (Catalog_aggregate ca in catalogAggragate)
                {
                    catalogLevel.Add(new Catalog_level() { Name = ca.Name, Parent_id = context.Catalog_levels.Where(s=>s.Name==ca.Catalog_id.Name).First().Id });
                }
                context.Catalog_levels.AddRange(catalogLevel);
                context.SaveChanges();
                catalogLevel.Clear();
                //add models
                List<Catalog_model> catalogModel = (from cm in context.CatalogModels
                                                            select cm).ToList();
                foreach (Catalog_model cm in catalogModel)
                {
                    string CatName = (from a in context.CatalogAggregates
                                  where a.Id == cm.Catalog_aggregate_id.Id
                                  select a.Catalog_id.Name).First();
                    int LevelCatId = (from a in context.Catalog_levels
                                      where a.Name == CatName
                                      select a.Id).First();
                    catalogLevel.Add(new Catalog_level() { Name = cm.Model, Parent_id = context.Catalog_levels.Where(s => s.Name == cm.Catalog_aggregate_id.Name).Where(s => s.Parent_id==LevelCatId).First().Id });
                }
                context.Catalog_levels.AddRange(catalogLevel);
                context.SaveChanges();
            }
        }


        public bool FillDB()
        {
            try
            {
               SetCatalog();
               SetAggregates();
               SetModels();
               SetCatalogLevels();
               return true;
            }
            catch 
            {
                return false;
            }
        }


    }
}
