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
    [Table("Books")]
    public class Books
    {
        [Key]
        public int BookID { get; set; }
        public int? BookTypeID { get; set; }
        public int WriterID { get; set; }
        public int PublisherID { get; set; }
        [Required]
        [MaxLength(50)]
        public string BookName { get; set; }
        [MaxLength(200)]
        public string Summary { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [DefaultValue(0)]
        public decimal Price { get; set; }
        public Nullable<DateTime> ReleaseDate { get; set; }
        [StringLength(100)]
        public string ImagePath { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool AreWeRead { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool Deleted { get; set; }

        //Relations..

        [ForeignKey("BookTypeID")]
        public virtual BooksType bookType { get; set; }

        [ForeignKey("WriterID")]
        public virtual Writers writer { get; set; }

        [ForeignKey("PublisherID")]
        public virtual Publisher publisher { get; set; }

        public virtual List<SaleDetail> SaleDetails { get; set; }
    }
}
