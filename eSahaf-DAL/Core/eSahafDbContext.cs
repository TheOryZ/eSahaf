using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSahaf_DAL.Core
{
    public class eSahafDbContext : DbContext
    {
        public virtual DbSet<BooksType> BookTypes { get; set; }
        public virtual DbSet<Writers> Writerss { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Books> Bookss { get; set; }
        public virtual DbSet<Users> Userss { get; set; }
        public virtual DbSet<BookSale> BookSales { get; set; }
        public virtual DbSet<SaleDetail> SaleDetails { get; set; }
    } 
}
 