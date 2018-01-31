using eSahaf_BLL.Models;
using eSahaf_BLL.Services;
using eSahaf_DAL.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eSahaf_Presantation.Controllers
{
    public class AdminController : Controller
    {
        BookService bs = new BookService();
        WriterService ws = new WriterService();
        BookTypeService bts = new BookTypeService();
        PublisherService ps = new PublisherService();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Products()
        {
            return View(bs.GetAllJustArrived());
        }
        public ActionResult AddNewProduct()
        {
            // ViewBag'ler içerisine Yazarlar , Kitap Türleri ve yayın evlerini getirmemiz gerekicek!
            ViewBag.Writers = ws.GetAllWriters();
            ViewBag.BookTypes = bts.GetAllBookTypes();
            ViewBag.Publishers = ps.GetAllPublishers();
            return View(); 
        }
        [HttpPost]
        public ActionResult AddNewProduct(Books Book, HttpPostedFileBase FileUpload)
        {
            if (FileUpload != null)
            {
                Image img = Image.FromStream(FileUpload.InputStream);

                int Width = Convert.ToInt32(ConfigurationManager.AppSettings["BookWidth"].ToString());
                int Height = Convert.ToInt32(ConfigurationManager.AppSettings["BookHeight"].ToString());

                // Resime random bir isim atadık ki içeridekilerle karşımasın. ve sonuna file uzantısını verdik getExtension ile
                string name = "/Content/Images/BooksImages/" + Guid.NewGuid() + Path.GetExtension(FileUpload.FileName);

                Bitmap bm = new Bitmap(img, Width, Height);
                bm.Save(Server.MapPath(name));

                Book.ImagePath = name;
            }
            bs.AddNewBook(Book);
            return RedirectToAction("Products");
        }
        public ActionResult DeleteProduct(int bookID)
        {
            bs.DeleteBook(bookID);
            return RedirectToAction("Products");
        }
        public ActionResult BookTypes()
        {
            return View(bts.GetAllBookTypes());
        }
        public ActionResult AddNewBookType()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBookType(BooksType type)
        {
            bts.AddNewBookType(type);
            return RedirectToAction("BookTypes");
        }
        public ActionResult DeleteBookTypes(int bookTypeID)
        {
            bts.DeleteBookType(bookTypeID);
            return RedirectToAction("BookTypes");
        }
        public ActionResult Writers()
        {
            return View(ws.GetAllWriters());
        }
        public ActionResult AddNewWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewWriter(Writers writer)
        {
            ws.AddNewWriter(writer);
            return RedirectToAction("Writers");
        }
        public ActionResult DeleteWriter(int writerID)
        {
            ws.DeleteWriter(writerID);
            return RedirectToAction("Writers");
        }
        public ActionResult EditWriter(int writerID)
        {
            Writers wrt = ws.GetWriterByID(writerID);
            return View(wrt);
        }
        [HttpPost]
        public ActionResult EditWriter(Writers wrt)
        {
            ws.EditWriter(wrt);
            return RedirectToAction("Writers");
        }
        public ActionResult Publishers()
        {
            return View(ps.GetAllPublishers());
        }
        public ActionResult AddNewPublisher()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewPublisher(Publisher publisher)
        {
            ps.AddNewPublisher(publisher);
            return RedirectToAction("Publishers");
        }
        public ActionResult DeletePublisher(int publisherID)
        {
            ps.DeletePublisher(publisherID);
            return RedirectToAction("Publisher");
        }
        public ActionResult Users()
        {
            return View();
        }
        public ActionResult ProductsReports()
        {
            return View();
        }
        public ActionResult SalesReports()
        {
            return View();
        }
        public ActionResult UsersReports()
        {
            return View();
        }
    }
}