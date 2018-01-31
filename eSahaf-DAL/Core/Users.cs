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
    [Table("Users")]
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }
        [MaxLength(15)]
        public string Phone { get; set; }
        public string Address { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool IsAdmin { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool Deleted { get; set; }

        //Relaitons..
        public virtual List<BookSale> BookSales { get; set; }

    }
}
