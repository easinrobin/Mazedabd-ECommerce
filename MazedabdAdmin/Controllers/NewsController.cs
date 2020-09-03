using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MZ.BusinessLayer;
using MZ.Models;
using Vereyon.Web;

namespace MazedabdAdmin.Controllers
{
    public class NewsController : Controller
    {
        public ActionResult News()
        {
            AdminViewModel av = new AdminViewModel();
            av.NewsList = NewsEventsManager.GetAllNews();
            return View(av);
        }

        public ActionResult InsertNews()
        {
            AdminViewModel av = new AdminViewModel();
            av.News = new News();
            return View(av);
        }

        public ActionResult UpdateNews(AdminViewModel av, long Id)
        {
            if (Id > 0)
            {
                av.News = NewsEventsManager.GetNewsById(Id);
                if (av.News != null)
                {
                    return View("~/Views/News/InsertNews.cshtml", av);
                }
            }

            return RedirectToAction("News");
        }

        public ActionResult DeleteNews(long Id)
        {
            NewsEventsManager.DeleteNews(Id);
            return RedirectToAction("News");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult InsertNews(AdminViewModel av, HttpPostedFileBase image)
        {
            if (av.News != null && av.News.Id > 0)
            {
                if (av.File != null)
                {
                    av.Service.ImageUrl = _UploadSingleImage(av, image);
                }

                NewsEventsManager.UpdateNews(av.News);
            }
            else
            {
                if (av.News != null)
                {
                    if (av.File != null)
                    {
                        av.News.ImagePath = _UploadSingleImage(av, image);
                       
                        NewsEventsManager.InsertNews(av.News);
                    }
                    else
                    {
                        FlashMessage.Danger("Image Required");
                        return View(av);
                    }
                }
            }

            return RedirectToAction("News");
        }

        private string _UploadSingleImage(AdminViewModel adminVwModel, HttpPostedFileBase images)
        {
            var file = adminVwModel.File;
            string pathUrl = "";
            string savepath, savefile;
            var filename = Path.GetFileName(Guid.NewGuid() + file.FileName);
            savepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/Images/");
            if (!Directory.Exists(savepath))
                Directory.CreateDirectory(savepath);
            savefile = Path.Combine(savepath, filename);
            file.SaveAs(savefile);
            pathUrl = "/img/Images/" + filename;
            return pathUrl;
        }
    }

}