using eSahaf_BLL.Models;
using eSahaf_DAL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eSahaf_Presantation.Controllers
{
    public class HomeController : Controller
    {
        BookService bs = new BookService();
        // GET: Home
        public ActionResult Index()
        {
            return View(bs.GetAllJustArrived());
        }
        public ActionResult ProductDetail(int bookID)
        {
            return View();
        }
        // Sepet'e ekleme işlemleri için ;
        public void AddToBasket(int ID)
        {
            BasketItem bsItem = new BasketItem();
            Books book = new Books();
            book = bs.GetBookByID(ID);

            bsItem.Book = book;
            bsItem.Copy = 1;

            Basket bskt = new Basket();
            bskt.AddBasket(bsItem);

            PartialsController pc = new PartialsController();
        }

    }
}