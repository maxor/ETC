using System;
using System.Collections.Generic;
using System.Linq;

namespace ETC.Data
{
    public class DataFunction
    {
        /// <summary>
        /// All levels information
        /// </summary>
        public List<Catalog_level> level { get; private set; }
        /// <summary>
        /// Get all data
        /// </summary>
        public void GetLevelData()
        {
            try
            {
                using (var context = new SparesContext())
                {
                    level = (from c in context.Catalog_levels
                             select c).ToList();
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Can't get data from catalog_levels");
            }
        }
    }
}
