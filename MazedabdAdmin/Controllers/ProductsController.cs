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
    public class ProductsController : Controller
    {
        // GET: Projects
        public ActionResult Index()
        {
            AdminViewModel av = new AdminViewModel();
            av.ProductList = ProductManager.GetAllProduct();
            return View(av);
        }

        public ActionResult Create()
        {
            AdminViewModel av = new AdminViewModel();
            av.Product = new Product();
            _loadProjects();
            _loadSubCategory();
            return View(av);
        }

        public ActionResult GalleryList(int Id)
        {
            if (Id != 0)
            {
                ViewBag.ProjectId = Id;
                AdminViewModel av = new AdminViewModel();
                av.ProductGalleryList = ProductManager.GetProductGalleryById(Id);
                return View(av);
            }

            return View("Index");
        }

        public ActionResult CreateGallery(long Id)
        {
            AdminViewModel av = new AdminViewModel();
            ProductGallery gallery = new ProductGallery
            {
                ProductId = Id
            };
            av.ProductGallery = gallery;
            return View(av);
        }

        public ActionResult DeleteGalleryItem(long Id)
        {
            ProductManager.DeleteProductGallery(Id);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateProduct(int Id)
        {
            if (Id > 0)
            {
                _loadSubCategory();
                AdminViewModel av = new AdminViewModel();
                av.ProductGallery = ProductManager.GetGalleryById(Id);
                if (av.ProductGallery != null)
                {
                    return View("~/Views/Products/UpdateGalleryItem.cshtml", av);
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult GetProductImgById(long Id)
        {
            if (Id > 0)
            {
                _loadSubCategory();
                _loadProjects();
                AdminViewModel av = new AdminViewModel();
                av.Product = ProductManager.GetProductById(Id);
                if (av.Product != null)
                {
                    return View("~/Views/Products/UpdateProduct.cshtml", av);
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(long Id)
        {
            ProductManager.DeleteProduct(Id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(AdminViewModel av, HttpPostedFileBase image)
        {
            av.Product.ImageUrl = _UploadSingleImage(av, image);
            av.Product.IsActive = true;
            av.Product.CreatedBy = "Admin";
            av.Product.CreatedDate = DateTime.Today;
            av.Product.ImageUrl = _UploadSingleImage(av, image);
            var projectId = ProductManager.InsertProduct(av.Product);

            if (projectId > 0)
            {
                //av.ProjectCategory.ImageUrl = _UploadSingleImage(av, image);
                //av.ProjectCategory.IsActive = true;
                //var categoryId = ProjectManager.InsertProjectCategory(av.ProjectCategory);

                _Gallery(projectId, av);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UpdateProduct(AdminViewModel av, HttpPostedFileBase image)
        {
            av.Product.IsActive = true;
            av.Product.CreatedBy = "Admin";
            av.Product.CreatedDate = DateTime.Today;
            av.Product.ImageUrl = _UploadSingleImage(av, image);

            bool isUpdateProduct = ProductManager.UpdateProduct(av.Product);
            bool isUpdateProductCategory = CategoryManager.UpdateProductCategory(av.ProductCategory);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UpdateProjectG(AdminViewModel av)
        {
            av.ProductGallery.IsActive = true;
            av.ProductGallery.CreatedBy = "Admin";
            av.ProductGallery.CreatedDate = DateTime.Today;


            bool isUpdateProduct = ProductManager.UpdateProductGallery(av.ProductGallery);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CreateGallery(AdminViewModel av, HttpPostedFileBase image)
        {
            if (av != null)
            {
                foreach (var file in av.Files)
                {
                    if (Request.Url != null)
                    {
                        string pathUrl = "";

                        if (file.ContentLength > 0)
                        {
                            string savepath, savefile;
                            var filename = Path.GetFileName(Guid.NewGuid() + file.FileName);
                            savepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/Offices/");
                            if (!Directory.Exists(savepath))
                                Directory.CreateDirectory(savepath);
                            savefile = Path.Combine(savepath, filename);
                            file.SaveAs(savefile);
                            pathUrl = "/img/Offices/" + filename;
                        }

                        var gallery = new ProductGallery
                        {
                            ImageUrl = pathUrl,
                            ProductId = av.ProductGallery.ProductId,
                            CreatedBy = "Admin",
                            CreatedDate = DateTime.Now,
                            IsActive = true
                        };
                        var galleryId = ProductManager.InsertProductGallery(gallery);
                    }
                }
            }
            return RedirectToAction("GalleryList", new
            {
                Id = av.ProductGallery.ProductId
            });
        }

        private void _Gallery(long productId, AdminViewModel av)
        {
            if (av.Files != null)
            {
                foreach (var file in av.Files)
                {
                    string pathUrl = "";

                    if (file != null && file.ContentLength > 0)
                    {
                        string savepath, savefile;
                        var filename = Path.GetFileName(Guid.NewGuid() + file.FileName);
                        savepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img/Offices/");
                        if (!Directory.Exists(savepath))
                            Directory.CreateDirectory(savepath);
                        savefile = Path.Combine(savepath, filename);
                        file.SaveAs(savefile);
                        pathUrl = "/img/Offices/" + filename;

                        var gallery = new ProductGallery
                        {
                            ImageUrl = pathUrl,
                            ProductId = productId,
                            IsActive = true,
                            CreatedBy = "Admin",
                            CreatedDate = DateTime.Now
                        };
                        var galleryId = ProductManager.InsertProductGallery(gallery);
                    }
                }
            }
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
        public void _loadSubCategory()
        {
            List<ProductSubCategory> dataList = CategoryManager.GetAllProductSubCategory();
            ViewBag.SubCategoryList = new SelectList(dataList, "Id", "Name");
        }

        [HttpGet]
        public JsonResult LoadSubCategoryByCategoryId(int id)
        {
            List<ProductSubCategory> dataList = CategoryManager.GetSubCategoryByCategoryId(id);
            return Json(dataList, JsonRequestBehavior.AllowGet);
        }
    }
}