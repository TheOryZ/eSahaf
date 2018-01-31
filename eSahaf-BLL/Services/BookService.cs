using eSahaf_BLL.Models;
using eSahaf_DAL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSahaf_BLL.Models
{
    public class BookService
    {
        eSahafDbContext ent = new eSahafDbContext();

        // Best Seller ile ilgili olan Methodlar geçici olarak burada. BookSaleService sayfasına geçirilecek!!
        public List<Books> GetWereReading()
        {
            // Take(4); for Default Page
            var exc = (from x in ent.Bookss
                       where x.Deleted == false && x.AreWeRead == true
                       select x).Take(4).ToList();
            return exc;
        }
        public List<Books> GetBestSeller()
        {
            // Take(4); for Default Page
            var exc = (from x in ent.Bookss
                       where x.Deleted == false
                       select x).Take(4).ToList();
            return exc;
        }
        public List<Books> GetJustArrived()
        {
            // Take(4); for Default Page
            var exc = (from x in ent.Bookss
                       where x.Deleted == false
                       orderby x.ReleaseDate descending
                       select x).Take(4).ToList();
            return exc;
        }
        public List<Books> GetAllWhatWereReading()
        {
            var exc = (from x in ent.Bookss
                       where x.Deleted == false && x.AreWeRead == true
                       select x).ToList();
            return exc;
        }
        public List<Books> GetAllJustArrived()
        {
            var exc = (from x in ent.Bookss
                       where x.Deleted == false
                       orderby x.ReleaseDate descending
                       select x).ToList();
            return exc;
        }
        public List<Books> GetAllBestSellers()
        {
            var exc = (from x in ent.Bookss
                       where x.Deleted == false
                       select x).ToList();
            return exc;
        }

        public bool AddNewBook(Books book)
        {
            bool drm = false;
            ent.Bookss.Add(book);
            try
            {
                ent.SaveChanges();
                drm = true;
            }
            catch (Exception ex)
            {
                string mistake = ex.Message;
            }
            return drm;
        }
        public bool DeleteBook(int bookID)
        {
            bool drm = false;
            var exc = (from x in ent.Bookss
                       where x.BookID == bookID
                       select x).FirstOrDefault();
            exc.Deleted = true;
            try
            {
                ent.SaveChanges();
                drm = true;
            }
            catch (Exception ex)
            {
                string mistake = ex.Message;
            }
            return drm;
        }
        public Books GetBookByID(int ID)
        {
            var exc = (from x in ent.Bookss
                       where x.BookID == ID
                       select x).FirstOrDefault();
            return exc;
        }
    }
}
