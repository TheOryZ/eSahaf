using eSahaf_BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eSahaf_Presantation.Controllers
{
    public class PartialsController : Controller
    {
        BookService bs = new BookService();
        public PartialViewResult BestSeller()
        {
            return PartialView(bs.GetBestSeller());
        }
        public PartialViewResult JustArrived()
        {
            return PartialView(bs.GetJustArrived());
        }
        public PartialViewResult WhatWereReading()
        {
            return PartialView(bs.GetWereReading());
        }
        public PartialViewResult Basket()
        {
            if (HttpContext.Session["ActiveBasket"] != null)
                return PartialView((Basket)HttpContext.Session["ActiveBasket"]);
            else
                return PartialView();

        }
    }
}