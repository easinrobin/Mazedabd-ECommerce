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
    public class ImageAndVideoController : Controller
    {
       
            public ActionResult ImageGallery()
            {
                AdminViewModel av = new AdminViewModel();
                av.ImageGalleries = NewsEventsManager.GetAllImageGallery();
                return View(av);
            }

            public ActionResult InsertImage()
            {
                AdminViewModel av = new AdminViewModel();
                av.ImageGallery = new ImageGallery();
                return View(av);
            }

            public ActionResult UpdateImage(AdminViewModel av, long Id)
            {
                if (Id > 0)
                {
                    av.ImageGallery = NewsEventsManager.GetImageGalleryById(Id);
                    if (av.ImageGallery != null)
                    {
                        return View("~/Views/ImageAndVideo/InsertImage.cshtml", av);
                    }
                }

                return RedirectToAction("ImageGallery");
            }

            public ActionResult DeleteImage(long Id)
            {
                NewsEventsManager.DeleteImageGallery(Id);
                return RedirectToAction("ImageGallery");
            }

            [HttpPost]
            [ValidateInput(false)]
            public ActionResult InsertImage(AdminViewModel av, HttpPostedFileBase image)
            {
                if (av.ImageGallery != null && av.ImageGallery.Id > 0)
                {
                    if (av.File != null)
                    {
                        av.ImageGallery.ImagePath = _UploadSingleImage(av, image);
                    }

                    NewsEventsManager.UpdateImageGallery(av.ImageGallery);
                }
                else
                {
                    if (av.ImageGallery != null)
                    {
                        if (av.File != null)
                        {
                            av.ImageGallery.ImagePath = _UploadSingleImage(av, image);

                            NewsEventsManager.InsertImageGallery(av.ImageGallery);
                        }
                        else
                        {
                            FlashMessage.Danger("Image Required");
                            return View(av);
                        }
                    }
                }

                return RedirectToAction("ImageGallery");
            }



        public ActionResult VideoGallery()
        {
            AdminViewModel av = new AdminViewModel();
            av.VideoGalleries = NewsEventsManager.GetAllVideoGallery();
            return View(av);
        }

        public ActionResult InsertVideo()
        {
            AdminViewModel av = new AdminViewModel();
            av.VideoGallery = new VideoGallery();
            return View(av);
        }

        public ActionResult UpdateVideo(AdminViewModel av, long Id)
        {
            if (Id > 0)
            {
                av.VideoGallery = NewsEventsManager.GetVideoGalleryById(Id);
                if (av.VideoGallery != null)
                {
                    return View("~/Views/ImageAndVideo/InsertVideo.cshtml", av);
                }
            }

            return RedirectToAction("VideoGallery");
        }

        public ActionResult DeleteVideo(long Id)
        {
            NewsEventsManager.DeleteVideoGallery(Id);
            return RedirectToAction("VideoGallery");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult InsertVideo(AdminViewModel av)
        {
            if (av.VideoGallery != null && av.VideoGallery.Id > 0)
            {
                NewsEventsManager.UpdateVideoGallery(av.VideoGallery);
            }
            else
            {
                if (av.VideoGallery != null)
                {
                    NewsEventsManager.InsertVideoGallery(av.VideoGallery);
                }
            }

            return RedirectToAction("VideoGallery");
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