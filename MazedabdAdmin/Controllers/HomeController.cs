﻿using System;
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

        public ActionResult Banner()
        {
            List<Banner> allBanners = HomeManager.GetAllBanners();
            return View(allBanners);
        }

        public ActionResult InsertBanner()
        {
            AdminViewModel av = new AdminViewModel();
            av.Banner = new Banner();
            return View(av);
        }

        public ActionResult UpdateBanner(AdminViewModel av, long Id)
        {
            if (Id > 0)
            {
                av.Banner = HomeManager.GetBannerDetails(Id);
                if (av.Banner != null)
                {
                    return View("~/Views/Home/InsertBanner.cshtml", av);
                }
            }
            return RedirectToAction("Banner");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult InsertBanner(AdminViewModel av, HttpPostedFileBase image)
        {
            if (av.Banner != null && av.Banner.Id > 0)
            {
                if (av.File != null)
                {
                    av.Banner.ImageUrl = _UploadSingleImage(av, image);
                }
                if (av.SliderBgImgUrl.File != null)
                {
                    av.Banner.SliderBgImgUrl = _UploadSliderImg(av, image);
                }

                av.Banner.IsActive = true;
                av.Banner.CreatedBy = "Admin";
                av.Banner.CreatedDate = DateTime.Now;
                HomeManager.UpdateBanner(av.Banner);
            }
            else
            {
                if (av.Banner != null)
                {
                    if (av.SliderBgImgUrl.File != null)
                    {
                        av.Banner.SliderBgImgUrl = _UploadSliderImg(av, image);
                    }

                    av.Banner.IsActive = true;
                    av.Banner.CreatedBy = "Admin";
                    av.Banner.CreatedDate = DateTime.Now;
                    HomeManager.InsertBanner(av.Banner);
                }
            }

            return RedirectToAction("Banner");
        }
        
        public ActionResult DeleteBanner(long id)
        {
            HomeManager.DeleteBanner(id);
            return RedirectToAction("Banner");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateAbout(AdminViewModel av, HttpPostedFileBase image)
        {

            if (av.File != null)
            {
                av.AboutUs.ImageUrl = _UploadSingleImage(av, av.File);
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
                    savepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/Uploads/");
                    if (!Directory.Exists(savepath))
                        Directory.CreateDirectory(savepath);
                    savefile = Path.Combine(savepath, filename);
                    file.SaveAs(savefile);
                    pathUrl = "/img/Uploads/" + filename;
                }
            }
            return pathUrl;
        }

        private string _UploadSingleImage(AdminViewModel adminVwModel, HttpPostedFileBase images)
        {
            var file = images;
            string pathUrl = "";
            string savepath, savefile;
            var filename = Path.GetFileName(Guid.NewGuid() + file.FileName);
            savepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/Uploads/");
            if (!Directory.Exists(savepath))
                Directory.CreateDirectory(savepath);
            savefile = Path.Combine(savepath, filename);
            file.SaveAs(savefile);
            pathUrl = "/img/Uploads/" + filename;
            return pathUrl;
        }

        private string _UploadSliderImg(AdminViewModel adminVwModel, HttpPostedFileBase images)
        {
            var file = adminVwModel.SliderBgImgUrl.File;
            string pathUrl = "";
            string savepath, savefile;
            var filename = Path.GetFileName(Guid.NewGuid() + file.FileName);
            savepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/Uploads/");
            if (!Directory.Exists(savepath))
                Directory.CreateDirectory(savepath);
            savefile = Path.Combine(savepath, filename);
            file.SaveAs(savefile);
            pathUrl = "/img/Uploads/" + filename;
            return pathUrl;
        }
    }
}