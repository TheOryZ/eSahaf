using eSahaf_DAL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace eSahaf_BLL.Models
{
    public class Basket
    {
        public static Basket ActiveBasket
        {
            get
            {
                HttpContext ctx = HttpContext.Current;
                if (ctx.Session["ActiveBasket"] == null)
                    ctx.Session["ActiveBasket"] = new Basket();
                return (Basket)ctx.Session["ActiveBasket"];
            }
        }
        private List<BasketItem> _books = new List<BasketItem>();

        public List<BasketItem> Books
        {
            get { return _books; }
            set { _books = value; }
        }

        public void AddBasket(BasketItem bskt)
        {
            if (HttpContext.Current.Session["ActiveBasket"] != null)
            {
                Basket bosket = (Basket)HttpContext.Current.Session["ActiveBasket"];

                // Aynı Kitap'tan bir tane daha var ise tekrar bir sıra açmasın ve Adetini artırsın..
                if (bosket.Books.Any(x => x.Book.BookID == bskt.Book.BookID))
                {
                    bosket.Books.FirstOrDefault(x => x.Book.BookID == bskt.Book.BookID).Copy++;
                }
                else
                {
                    bosket.Books.Add(bskt);
                }
            }
            else
            {
                Basket bsk = new Basket();
                bsk.Books.Add(bskt);

                HttpContext.Current.Session["ActiceBasket"] = bsk;
            }
        }
        // Sepet Toplam Tutar :
        public decimal AllTotal
        {
            get
            {
                return Books.Sum(x => x.Total);
            }
        }

    }
    public class BasketItem
    {
        public Books Book { get; set; }
        public int Copy { get; set; }
        public decimal Total
        {
            get
            {
                return Book.Price * Copy;
            }
        }
    }
}
