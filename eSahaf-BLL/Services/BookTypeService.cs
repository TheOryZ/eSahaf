using eSahaf_DAL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSahaf_BLL.Services
{
    public class BookTypeService
    {
        eSahafDbContext ent = new eSahafDbContext();

        public List<BooksType> GetAllBookTypes()
        {
            var exc = (from x in ent.BookTypes
                       where x.Deleted == false
                       select x).ToList();
            return exc;
        }
        public bool AddNewBookType(BooksType type)
        {
            bool drm = false;
            ent.BookTypes.Add(type);
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
        public bool DeleteBookType(int bookTypeID)
        {
            bool drm = false;
            var exc = (from x in ent.BookTypes
                       where x.BooksTypeID == bookTypeID
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
    }
}
