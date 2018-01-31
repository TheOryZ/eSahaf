using eSahaf_DAL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSahaf_BLL.Services
{
    public class WriterService
    {
        eSahafDbContext ent = new eSahafDbContext();

        public List<Writers> GetAllWriters()
        {
            var exc = (from x in ent.Writerss
                       where x.Deleted == false
                       select x).ToList();
            return exc;
        }
        public bool AddNewWriter(Writers writer)
        {
            bool drm = false;
            ent.Writerss.Add(writer);
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
        public bool DeleteWriter(int writerID)
        {
            bool drm = false;
            var exc = (from x in ent.Writerss
                       where x.WriterID == writerID
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
        public Writers GetWriterByID(int writerID)
        {
            var exc = (from x in ent.Writerss
                       where x.WriterID == writerID
                       select x).FirstOrDefault();
            return exc;
        }
        public bool EditWriter(Writers wrt)
        {
            bool drm = false;
            var exc = (from x in ent.Writerss
                       where x.WriterID == wrt.WriterID
                       select x).FirstOrDefault();
            exc.WriterName = wrt.WriterName;
            exc.About = wrt.About;
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
