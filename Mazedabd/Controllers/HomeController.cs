using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MZ.BusinessLayer;
using MZ.Models;
using reCAPTCHA.MVC;

namespace Mazedabd.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            PublicViewModel publicViewModel = new PublicViewModel();
            if (Session["CompanySetting"] != null)
            {
                publicViewModel.CompanySetting = (CompanySetting)Session["CompanySetting"];
            }
            else
            {
                publicViewModel.CompanySetting = CompanySettingsManager.GetCompanySettings(1);
            }

            //publicViewModel.OurClients = ClientManager.GetAllClients();
            publicViewModel.Banners = HomeManager.GetAllBanners();
            publicViewModel.ProductCategories = CategoryManager.GetAllProductCategory();
            return View(publicViewModel);
        }

        public ActionResult About()
        {
            PublicViewModel publicViewModel = new PublicViewModel();
            publicViewModel.OurClients = ClientManager.GetAllClients();
            publicViewModel.AboutUs = HomeManager.GetAboutUs(1);
            return View(publicViewModel);
        }

        public ActionResult ProductCategory()
        {
            PublicViewModel publicViewModel = new PublicViewModel();
            if (Session["CompanySetting"] != null)
            {
                publicViewModel.CompanySetting = (CompanySetting)Session["CompanySetting"];
            }
            else
            {
                publicViewModel.CompanySetting = CompanySettingsManager.GetCompanySettings(1);
            }
            publicViewModel.ProductCategories = CategoryManager.GetAllProductCategory();
            if (publicViewModel.ProductCategories.Any() && publicViewModel.ProductCategories.Count > 0)
            {
                return View(publicViewModel);
            }

            return RedirectToAction("Index");
        }

        public ActionResult SubCategory(long id = 0)
        {
            PublicViewModel pv = new PublicViewModel();
            if (Session["CompanySetting"] != null)
            {
                pv.CompanySetting = (CompanySetting)Session["CompanySetting"];
            }
            else
            {
                pv.CompanySetting = CompanySettingsManager.GetCompanySettings(1);
            }

            if (id > 0)
            {
                pv.ProductSubCategories = CategoryManager.GetSubCategoryByCategoryId(id);
                pv.ProductCategory = CategoryManager.GetProductCategoryById(id);
                if (pv.ProductSubCategories.Count == 0)
                {
                    //pv.Products = CategoryManager.GetAllProductsByCategoryId(id);
                    var routeValues = new RouteValueDictionary {
                        { "id", id },
                        { "category", "category" }
                    };
                    return RedirectToAction("Products", routeValues);
                }
                return View(pv);
            }
            return RedirectToAction("ProductCategory");
        }

        public ActionResult Products(long id = 0, string category = "")
        {
            Session["EmailStatus"] = null;
            PublicViewModel publicViewModel = new PublicViewModel();
            if (Session["CompanySetting"] != null)
            {
                publicViewModel.CompanySetting = (CompanySetting)Session["CompanySetting"];
            }
            else
            {
                publicViewModel.CompanySetting = CompanySettingsManager.GetCompanySettings(1);
            }

            if (!string.IsNullOrEmpty(id.ToString()))
            {
                if (id == 0)
                {
                    publicViewModel.Products = ProductManager.GetAllProduct();
                }
                else
                {
                    //publicViewModel.ProductSubCategories = CategoryManager.GetSubCategoryByCategoryId(id);
                    if (category.ToLower() != "category")
                    {
                        publicViewModel.Products = CategoryManager.GetAllProductsBySubCategoryId(id);
                    }
                    else
                    {
                        publicViewModel.Products = CategoryManager.GetAllProductsByCategoryId(id);
                    }
                }

                publicViewModel.ProductSubCategory = CategoryManager.GetProductSubCategoryById(id);
                publicViewModel.Feedback = new Feedback();
                return View(publicViewModel);
            }

            return RedirectToAction("ProductCategory");
        }

        public ActionResult ProductDetails(long? id)
        {
            PublicViewModel publicViewModel = new PublicViewModel();
            if (Session["CompanySetting"] != null)
            {
                publicViewModel.CompanySetting = (CompanySetting)Session["CompanySetting"];
            }
            else
            {
                publicViewModel.CompanySetting = CompanySettingsManager.GetCompanySettings(1);
            }

            if (!string.IsNullOrEmpty(id.ToString()) && id > 0)
            {
                publicViewModel.Product = ProductManager.GetProductById(id);
                if (publicViewModel.Product != null)
                {
                    try
                    {
                        publicViewModel.ProductGalleries = ProductManager.GetAllProductGalleriesByProductId(id);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        publicViewModel.ProductGalleries = new List<ProductGallery>();
                    }
                    return View(publicViewModel);
                }
            }

            return View(publicViewModel);
        }

        public ActionResult SearchResult(string searchKey = "")
        {
            PublicViewModel pv = new PublicViewModel();
            if (!string.IsNullOrEmpty(searchKey))
            {
                pv.SearchResults = SearchManager.GetSearchResults(searchKey);
                return View(pv);
            }

            return View();
        }

        public ActionResult News(long? newsId)
        {
            PublicViewModel publicViewModel = new PublicViewModel();
            if (Session["CompanySetting"] != null)
            {
                publicViewModel.CompanySetting = (CompanySetting)Session["CompanySetting"];
            }
            else
            {
                publicViewModel.CompanySetting = CompanySettingsManager.GetCompanySettings(1);
            }

            if (string.IsNullOrEmpty(newsId.ToString()))
            {
                publicViewModel.NewsList = NewsEventsManager.GetAllNews();
                if (publicViewModel.NewsList.Any() && publicViewModel.NewsList.Count > 0)
                {
                    publicViewModel.News = publicViewModel.NewsList.FirstOrDefault();
                }
            }
            else
            {
                publicViewModel.NewsList = NewsEventsManager.GetAllNews();
                publicViewModel.News = NewsEventsManager.GetNewsById(newsId);
            }

            return View(publicViewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        [CaptchaValidator]
        public ActionResult ProductDetails(PublicViewModel pv)
        {
            if (!ModelState.IsValid)
            {
                pv.ProductGalleries = ProductManager.GetAllProductGalleriesByProductId(pv.Product.Id);
                return View(pv);
            }
            if (Session["CompanySetting"] != null)
            {
                pv.CompanySetting = (CompanySetting)Session["CompanySetting"];
            }
            else
            {
                pv.CompanySetting = CompanySettingsManager.GetCompanySettings(1);
            }

            FeedbackManager.InsertFeedback(pv.Feedback);

            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath("~/Mail/mz-email.html");
                string html = System.IO.File.ReadAllText(path);
                html = html.Replace("{name}", pv.Feedback.Name);
                html = html.Replace("{mobile}", pv.Feedback.Mobile);
                html = html.Replace("{message}", pv.Feedback.Message);
                html = html.Replace("{p_name}", pv.Product.ProductName);
                html = html.Replace("{p_price}", pv.Product.Price.ToString());
                html = html.Replace("{p_link}", Request.Url?.AbsoluteUri);
                html = html.Replace("{date}", DateTime.Now.ToString("dd MMM yyyy"));
                
                bool hasWords = HasBadWords(pv.Feedback.Message);

                if (hasWords == false)
                {
                    SendEmailFromGoDaddy("MazedaMart contact us inquiry", html);
                }

                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("<div class=\"alert alert-success\" id=\"contactSuccess\">");
                sb.AppendFormat("<strong>Success!</strong> Your message has been sent to us.");
                sb.AppendFormat("</div>");
                //pv.EmailStatus = sb.ToString();
                Session["EmailStatus"] = sb.ToString();
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("<div class=\"alert alert-success\" id=\"contactSuccess\">");
                sb.AppendFormat(" <strong>Error!</strong> There was an error sending your message.{0} - {1}", ex.Message, ex.InnerException?.Message);
                sb.AppendFormat("<span class=\"font-size-xs mt-sm display-block\" id=\"mailErrorMessage\"></span>");
                sb.AppendFormat("</div>");
                //pv.EmailStatus = sb.ToString();
                Session["EmailStatus"] = sb.ToString();
            }

            return Redirect("/Home/ProductDetails/" + pv.Product.Id);
        }

        public ActionResult Contact()
        {
            PublicViewModel publicViewModel = new PublicViewModel();
            if (Session["CompanySetting"] != null)
            {
                publicViewModel.CompanySetting = (CompanySetting)Session["CompanySetting"];
            }
            else
            {
                publicViewModel.CompanySetting = CompanySettingsManager.GetCompanySettings(1);
            }

            return View(publicViewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        [CaptchaValidator]
        public ActionResult Contact(PublicViewModel pv)
        {

            if (Session["CompanySetting"] != null)
            {
                pv.CompanySetting = (CompanySetting)Session["CompanySetting"];
            }
            else
            {
                pv.CompanySetting = CompanySettingsManager.GetCompanySettings(1);
            }
            if (!ModelState.IsValid)
            {
                return View(pv);
            }
            FeedbackManager.InsertFeedback(pv.Feedback);

            try
            {
                string path = System.Web.HttpContext.Current.Server.MapPath("~/Mail/mz-email.html");
                string html = System.IO.File.ReadAllText(path);
                html = html.Replace("{name}", pv.Feedback.Name);
                html = html.Replace("{mobile}", pv.Feedback.Mobile);
                html = html.Replace("{message}", pv.Feedback.Message);
                html = html.Replace("{date}", DateTime.Now.ToString("dd MMM yyyy"));

                bool hasWords = HasBadWords(pv.Feedback.Message);

                if (hasWords == false)
                {
                    SendEmailFromGoDaddy("MazedaMart contact us inquiry", html);
                }

                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("<div class=\"alert alert-success\" id=\"contactSuccess\">");
                sb.AppendFormat("<strong>Success!</strong> Your message has been sent to us.");
                sb.AppendFormat("</div>");
                Session["EmailStatus"] = sb.ToString();
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("<div class=\"alert alert-success\" id=\"contactSuccess\">");
                sb.AppendFormat(" <strong>Error!</strong> There was an error sending your message.{0} - {1}", ex.Message, ex.InnerException?.Message);
                sb.AppendFormat("<span class=\"font-size-xs mt-sm display-block\" id=\"mailErrorMessage\"></span>");
                sb.AppendFormat("</div>");
                Session["EmailStatus"] = sb.ToString();
            }

            return RedirectToAction("Contact");
        }

        public ActionResult Gallery()
        {
            PublicViewModel pv = new PublicViewModel();
            pv.ImageGalleries = NewsEventsManager.GetAllImageGallery();
            pv.VideoGalleries = NewsEventsManager.GetAllVideoGallery();

            return View(pv);
        }

        public bool HasBadWords(string inputWords)
        {
            Regex wordFilter = new Regex("(eаrn mоnеy оnlinе|mystrikingly|makemoney|earnmoney|sеx|adult|fucк|dating|woman|girls)");
            return wordFilter.IsMatch(inputWords.ToLower());
        }

        private string SendEmailFromGoDaddy(string subject, string body)
        {
            string msg = null;

            var fromAddress = new MailAddress("info.mazedabd@gmail.com", "Info@Mazeda");
            var toAddress = new MailAddress("robin.byteheart@gmail.com", "Robin");
            string fromPassword = ConfigurationManager.AppSettings["mailPass"];

            try
            {
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 20000
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }
            }
            catch(Exception ex)
            {
                msg = ex.Message;
            }

            return msg;
        }
    }
}
