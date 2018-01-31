using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSahaf_DAL.Core
{ [Table("SaleDetail")]
    public class SaleDetail
    {
        [Key]
        public int SaleDetailID { get; set; }
        public int BookID { get; set; }
        public int BookSaleID { get; set; }
        [Required]
        [DefaultValue(1)]
        public int Copy { get; set; }
        [Required]
        [DefaultValue(0)]
        public decimal Price { get; set; }
        [Required]
        [DefaultValue(0)]
        public decimal Total { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool Deleted { get; set; }

        //Relations..

        [ForeignKey("BookID")]
        public virtual Books book { get; set; }
        [ForeignKey("BookSaleID")]
        public virtual BookSale bookSale { get; set; }
    }
}
