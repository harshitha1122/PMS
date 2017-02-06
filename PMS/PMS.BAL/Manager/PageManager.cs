using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.DAL.Service;
using PMS.Core.Entity;

namespace PMS.BAL.Manager
{

    public class PageManager
    {
        public PageService pageService = null;

        public PageManager()
        {
            pageService = new PageService();
        }

        public void Add(Page page)
        {
            pageService.Add(page);
        }

        public Boolean Delete(int pageId)
        {
            return pageService.Delete(pageId); ;
        }

        public List<Page> GetAll()
        {
            return pageService.GetAll();
        }

        public void Update(Page page)
        {
            pageService.Update(page);
        }

        public Page GetById(Int32 pageId)
        {
            return pageService.GetById(pageId);
        }
    }
}
