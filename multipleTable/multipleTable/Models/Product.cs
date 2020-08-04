using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace multipleTable.Models
{
    public class Product
    {
        public int Id { set; get; }
        public string Name { set; get; }
        [Required]
        [Range(minimum: 0.01, maximum: (double)decimal.MaxValue)]
        public decimal Price { set; get; }
        [Required]
        [Range(minimum: 0.01, maximum: (double)decimal.MaxValue)]
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public int ViewCount { set; get; }
        public int CategoryId { set; get; }
        public DateTime DateCreated { set; get; }
        public string SeoAlias { set; get; }


    }
}
