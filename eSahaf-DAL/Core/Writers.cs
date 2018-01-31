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
    [Table("Writers")]
    public class Writers
    {
        [Key]
        public int WriterID { get; set; }
        [Required]
        [MaxLength(35)]
        public string WriterName { get; set; }
        public string About { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool Deleted { get; set; }

        //Relations..

        public virtual List<Books> Books { get; set; }
    }
}
