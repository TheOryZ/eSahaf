using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSahaf_BLL.Models
{
    public class cSale
    {
        public int SaleID { get; set; }
        public int BookID { get; set; }
        public string BookName { get; set; }
        public int Copy { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }

        public List<cSale> EmptySale()
        {
            return new List<cSale>();
        }

        public int TotalItem(List<cSale> basket)
        {
            int total = 0;
            foreach (cSale item in basket)
            {
                total += item.Copy;
            }
            return total;
        }

        public decimal TotalPrice(List<cSale> basket)
        {
            decimal total = 0;
            foreach (cSale item in basket)
            {
                total += item.Price;
            }
            return total;
        }

    }
}
