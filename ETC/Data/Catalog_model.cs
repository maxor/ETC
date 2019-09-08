using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETC.Data
{
    public class Catalog_model
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string Url{ get; set; }
        public virtual Catalog_aggregate Catalog_aggregate_id { get; set; }

    }
}
