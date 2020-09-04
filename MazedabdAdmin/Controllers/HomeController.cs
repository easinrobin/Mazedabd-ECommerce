using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MZ.BusinessLayer;
using MZ.Models;

namespace MazedabdAdmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About(AdminViewModel av, long Id = 1)
        {
            av.AboutUs = HomeManager.GetAboutUs(Id);
            return View(av);
        }

        public ActionResult UpdateAbout(AdminViewModel av, long Id)
        {
            if (Id > 0)
            {
                av.AboutUs = HomeManager.GetAboutUs(Id);
                if (av.AboutUs != null)
                {
                    return View("~/Views/Home/About.cshtml", av);
                }
            }

            return RedirectToAction("About");
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateAbout(AdminViewModel av, HttpPostedFileBase image)
        {

            if (av.File != null)
            {
                av.AboutUs.ImageUrl = _UploadSingleImage(av, image);
            }

            HomeManager.UpdateAbout(av.AboutUs);


            return RedirectToAction("About");
        }


        private string _UploadImage(AdminViewModel adminVwModel, HttpPostedFileBase images)
        {
            string pathUrl = "";
            foreach (var file in adminVwModel.Files.Take(1))
            {


                if (file.ContentLength > 0)
                {
                    string savepath, savefile;
                    var filename = Path.GetFileName(Guid.NewGuid() + file.FileName);
                    savepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/Images/");
                    if (!Directory.Exists(savepath))
                        Directory.CreateDirectory(savepath);
                    savefile = Path.Combine(savepath, filename);
                    file.SaveAs(savefile);
                    pathUrl = "/img/Images/" + filename;
                }
            }
            return pathUrl;
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

        private string _UploadSliderImg(AdminViewModel adminVwModel, HttpPostedFileBase images)
        {
            var file = adminVwModel.SliderBgImgUrl.File;
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