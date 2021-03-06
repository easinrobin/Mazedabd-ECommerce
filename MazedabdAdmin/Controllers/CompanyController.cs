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
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult CompanySettings(AdminViewModel av, long Id = 1)
        {
            av.CompanySetting = CompanySettingsManager.GetCompanySettings(Id);
            return View(av);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateCompanySettings(AdminViewModel av, HttpPostedFileBase image)
        {
            if (av.File != null)
            {
                av.CompanySetting.LogoUrl = _UploadSingleImage(av, image);
            }
            CompanySettingsManager.UpdateSettings(av.CompanySetting);
            return RedirectToAction("CompanySettings");
        }

        private string _UploadSingleImage(AdminViewModel adminVwModel, HttpPostedFileBase images)
        {
            var file = adminVwModel.File;
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