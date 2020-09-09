using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MZ.BusinessLayer;
using MZ.Models;

namespace MazedabdAdmin.Controllers
{
    public class SeoController : Controller
    {
        // GET: Seo
        public ActionResult Index()
        {
            AdminViewModel av = new AdminViewModel();
            av.Seos = SEOManager.GetAllSeo();
            return View(av);
        }

        public ActionResult InsertSeo()
        {
            AdminViewModel av = new AdminViewModel();
            av.Seo = new SETag();
            return View(av);
        }

        public ActionResult UpdateSeo(AdminViewModel av, int id)
        {
            if (id > 0)
            {
                av.Seo = SEOManager.GetSeoById(id);
                if (av.Seo != null)
                {
                    return View("~/Views/SEO/InsertSeo.cshtml", av);
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult DeleteSeo(int id)
        {
            SEOManager.DeleteSeo(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult InsertSeo(AdminViewModel av)
        {
            if (av.Seo != null && av.Seo.id > 0)
            {
                SEOManager.UpdateSeo(av.Seo);
            }
            else
            {
                if (av.Seo != null)
                {
                    SEOManager.InsertSeo(av.Seo);
                }
            }

            return RedirectToAction("Index");
        }

    }
}