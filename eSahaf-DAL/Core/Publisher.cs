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
    [Table("Publisher")]
    public class Publisher
    {
        [Key]
        public int PublisherID { get; set; }
        [Required]
        [MaxLength(50)]
        public string PublisherName { get; set; }
        [MaxLength(15)]
        public string Phone { get; set; }
        public string Address { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool Deleted { get; set; }

        //Relations..

        public virtual List<Books> Books { get; set; }
    }
}
