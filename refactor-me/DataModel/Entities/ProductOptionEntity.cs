using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace refactor_me
{
    [Table("productoption")]
    public partial class ProductOptionEntity
    {
        public Guid id { get; set; }

        public Guid productid { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string description { get; set; }
    }
}
