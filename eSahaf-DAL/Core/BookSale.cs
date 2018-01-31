using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSahaf_DAL.Core
{
    [Table("BookSale")]
    public class BookSale
    {
        [Key]
        public int BookSaleID { get; set; }
        public int UserID { get; set; }
        [Required]
        public DateTime DateOfSale { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        [DefaultValue(1)]
        public int Copy { get; set; }
        [Required]
        [DefaultValue(0)]
        public decimal Total { get; set; }
        public byte Status { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool Deleted { get; set; }

        //Relations..

        [ForeignKey("UserID")]
        public virtual Users user { get; set; }

        public virtual List<SaleDetail> SaleDetails { get; set; }
    }
}
