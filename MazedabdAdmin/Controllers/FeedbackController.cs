using System.Web.Mvc;
using MZ.BusinessLayer;
using MZ.Models;

namespace MazedabdAdmin.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Feedback
        public ActionResult Index()
        {
            AdminViewModel av = new AdminViewModel();
            av.FeedbackList = FeedbackManager.GetAllFeedback();
            return View(av);
        }

        public ActionResult DeleteFeedback(long Id)
        {
            FeedbackManager.DeleteFeedback(Id);
            return RedirectToAction("Index");
        }
    }
}