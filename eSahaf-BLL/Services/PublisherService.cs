using eSahaf_DAL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSahaf_BLL.Services
{
    public class PublisherService
    {
        eSahafDbContext ent = new eSahafDbContext();

        public List<Publisher> GetAllPublishers()
        {
            var exc = (from x in ent.Publishers
                       where x.Deleted == false
                       select x).ToList();
            return exc;
        }
        public bool AddNewPublisher(Publisher publisher)
        {
            bool drm = false;
            ent.Publishers.Add(publisher);
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
        public bool DeletePublisher(int publisherID)
        {
            bool drm = false;
            var exc = (from x in ent.Publishers
                       where x.PublisherID == publisherID
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
