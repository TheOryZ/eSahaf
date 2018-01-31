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
    [Table("BooksType")]
    public class BooksType
    {
        [Key]
        public int BooksTypeID { get; set; }
        [Required]
        [MaxLength(25)]
        public string BookTypeName { get; set; }
        public string Explanation { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool Deleted { get; set; }

        // Relations..

        public virtual List<Books> Books { get; set; }

    }
}
