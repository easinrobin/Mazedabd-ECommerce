using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
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

            publicViewModel.OurClients = ClientManager.GetAllClients();
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
                return View(pv);
            }
            return RedirectToAction("ProductCategory");
        }

        public ActionResult Products(long id = 0)
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
                    publicViewModel.Products = CategoryManager.GetAllProductsBySubCategoryId(id);
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

            return RedirectToAction("Index", "NotFound");
        }

        [HttpPost]
        [ValidateInput(false)]
        [CaptchaValidator(
            PrivateKey = "6LcMg8MZAAAAAHo6fxgQF_hOnhg28SrB8CH4z8zS",
            ErrorMessage = "Invalid input captcha.",
            RequiredMessage = "The captcha field is required.")]
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
                string body = string.Empty;
                body += "Hi Team,";
                body += "<br/> This is from MazedaMart product enquiry:";
                body += "<br/>Name: " + pv.Feedback.Name;
                body += "<br/>Mobile No.: " + pv.Feedback.Mobile;
                body += "<br/>Message: " + pv.Feedback.Message;
                body += "<br/>Product Name: " + pv.Product.ProductName;
                body += "<br/>Product Price: " + pv.Product.Price;
                body += "<br/>Product Link: " + Request.Url?.AbsoluteUri;
                body += "<br/> Date: " + DateTime.Now.ToString("dd MMM yyyy");

                bool hasWords = HasBadWords(pv.Feedback.Message);

                if (hasWords == false)
                {
                    SendEmailFromGoDaddy("MazedaMart contact us inquiry", body, "hello@thebyteheart.com", "robin.byteheart@gmail.com", "robineasin@gmail.com", true,
                        "hello@thebyteheart.com", "He11o@S1tec0re");
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
        [CaptchaValidator(
            PrivateKey = "6LcMg8MZAAAAAHo6fxgQF_hOnhg28SrB8CH4z8zS",
            ErrorMessage = "Invalid input captcha.",
            RequiredMessage = "The captcha field is required.")]
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
                string body = string.Empty;
                body += "Hi Team,";
                body += "<br/> This is from MazedaMart Contact us enquiry:";
                body += "<br/>Name: " + pv.Feedback.Name;
                body += "<br/>Email: " + pv.Feedback.Email;
                body += "<br/>Subject: " + pv.Feedback.Subject;
                body += "<br/>Message: " + pv.Feedback.Message;
                body += "<br/> Date: " + DateTime.Now.ToString("dd MMM yyyy");

                bool hasWords = HasBadWords(pv.Feedback.Message);

                if (hasWords == false)
                {
                    SendEmailFromGoDaddy("MazedaMart contact us inquiry", body, "hello@thebyteheart.com", "robin.byteheart@gmail.com", "robineasin@gmail.com", true,
                        "hello@thebyteheart.com", "He11o@S1tec0re");
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

        private string SendEmailFromGoDaddy(string subject, string body, string sender, string recipient, string bcc, bool isHTML, string smtpUsername, string smtpPassword)
        {
            string msg = null;

            try
            {
                MailMessage mailMsg = new MailMessage(sender, recipient);
                mailMsg.Bcc.Add(bcc);
                mailMsg.Subject = subject;
                mailMsg.Body = body;
                mailMsg.IsBodyHtml = isHTML;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtpout.asia.secureserver.net";
                smtp.Credentials = new System.Net.NetworkCredential(smtpUsername, smtpPassword);
                smtp.Port = 80;
                smtp.EnableSsl = false;
                smtp.Send(mailMsg);
            }

            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return msg;   // If msg == null then the e-mail was sent without errors
        }
    }
}
