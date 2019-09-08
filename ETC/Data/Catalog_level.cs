using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETC.Data
{
    public class Catalog_level
    {
        public int Id { get; set; }
        public int Parent_id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
