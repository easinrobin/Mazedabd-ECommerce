using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MZ.BusinessLayer;
using MZ.Models;

using Vereyon.Web;

namespace MazedabdAdmin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Categories()
        {
            AdminViewModel av = new AdminViewModel();
            av.ProductCategoryList = CategoryManager.GetAllProductCategory();
            return View(av);
        }

        public ActionResult InsertCategory()
        {
            AdminViewModel av = new AdminViewModel();
            av.ProductCategory = new ProductCategory();
            return View(av);
        }

        public ActionResult UpdateCategory(AdminViewModel av, long Id)
        {
            if (Id > 0)
            {
                av.ProductCategory = CategoryManager.GetProductCategoryById(Id);
                if (av.ProductCategory != null)
                {
                    return View("~/Views/Category/InsertCategory.cshtml", av);
                }
            }

            return RedirectToAction("Categories");
        }

        public ActionResult DeleteCategory(long Id)
        {
            CategoryManager.DeleteProductCategory(Id);
            return RedirectToAction("Categories");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult InsertCategory(AdminViewModel av, HttpPostedFileBase image)
        {
            if (av.ProductCategory != null && av.ProductCategory.Id > 0)
            {
                if (av.File != null)
                {
                    av.Service.ImageUrl = _UploadSingleImage(av, image);
                }
                av.ProductCategory.IsActive = true;
                av.ProductCategory.CreatedDate = DateTime.Today;
                av.ProductCategory.CreatedBy = "Admin";
                CategoryManager.UpdateProductCategory(av.ProductCategory);
            }
            else
            {
                if (av.ProductCategory != null)
                {
                    if (av.File != null)
                    {
                        av.ProductCategory.ImageUrl = _UploadSingleImage(av, image);
                        av.ProductCategory.IsActive = true;
                        av.ProductCategory.CreatedDate = DateTime.Today;
                        av.ProductCategory.CreatedBy = "Admin";
                        CategoryManager.InsertProductCategory(av.ProductCategory);
                    }
                    else
                    {
                        FlashMessage.Danger("Image Required");
                        return View(av);
                    }
                }
            }

            return RedirectToAction("Categories");
        }




        public ActionResult SubCategories()
        {
            AdminViewModel av = new AdminViewModel();
            av.ProductSubCategories = CategoryManager.GetAllProductSubCategory();
            return View(av);
        }

        public ActionResult InsertSubCategory()
        {
            _loadProjects();
            AdminViewModel av = new AdminViewModel();
            av.ProductSubCategory = new ProductSubCategory();
            return View(av);
        }

        public ActionResult UpdateSubCategory(AdminViewModel av, long Id)
        {
            if (Id > 0)
            {
                _loadProjects();
                av.ProductSubCategory = CategoryManager.GetProductSubCategoryById(Id);
                if (av.ProductSubCategory != null)
                {
                    return View("~/Views/Category/InsertSubCategory.cshtml", av);
                }
            }

            return RedirectToAction("SubCategories");
        }

        public ActionResult DeleteSubCategory(long Id)
        {
            CategoryManager.DeleteProductSubCategory(Id);
            return RedirectToAction("SubCategories");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult InsertSubCategory(AdminViewModel av, HttpPostedFileBase image)
        {
            if (av.ProductSubCategory != null && av.ProductSubCategory.Id > 0)
            {
                if (av.File != null)
                {
                    av.Service.ImageUrl = _UploadSingleImage(av, image);
                }
                av.ProductSubCategory.IsActive = true;
                av.ProductSubCategory.CreatedDate = DateTime.Today.ToString(CultureInfo.InvariantCulture);
                av.ProductSubCategory.CreatedBy = "Admin";
                CategoryManager.UpdateProductSubCategory(av.ProductSubCategory);
            }
            else
            {
                if (av.ProductSubCategory != null)
                {
                    if (av.File != null)
                    {
                        av.ProductSubCategory.ImageUrl = _UploadSingleImage(av, image);
                        av.ProductSubCategory.IsActive = true;
                        av.ProductSubCategory.CreatedDate = DateTime.Today.ToString(CultureInfo.InvariantCulture);
                        av.ProductSubCategory.CreatedBy = "Admin";
                        CategoryManager.InsertProductSubCategory(av.ProductSubCategory);
                    }
                    else
                    {
                        FlashMessage.Danger("Image Required");
                        return View(av);
                    }
                }
            }

            return RedirectToAction("SubCategories");
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

        public void _loadProjects()
        {
            List<ProductCategory> dataList = CategoryManager.GetAllProductCategory();
            ViewBag.CategoryList = new SelectList(dataList, "Id", "Name");
        }
    }
}