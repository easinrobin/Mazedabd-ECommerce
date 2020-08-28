using System.Collections.Generic;
using MZ.DataLayerSql;
using MZ.Models;

namespace MZ.BusinessLayer
{
    public class FeedbackManager
    {
        public static List<Feedback> GetAllFeedback()
        {
            SqlFeedbackProvider provider = new SqlFeedbackProvider();
            return provider.GetAllFeedback();
        }

        public static Feedback GetFeedbackById(long Id)
        {
            SqlFeedbackProvider provider = new SqlFeedbackProvider();
            return provider.GetFeedbackById(Id);
        }

        public static bool UpdateFeedback(Feedback feedback)
        {
            SqlFeedbackProvider provider = new SqlFeedbackProvider();
            return provider.UpdateFeedback(feedback);
        }

        public static long InsertFeedback(Feedback feedback)
        {
            SqlFeedbackProvider provider = new SqlFeedbackProvider();
            return provider.InsertFeedback(feedback);
        }

        public static bool DeleteFeedback(long Id)
        {
            SqlFeedbackProvider provider = new SqlFeedbackProvider();
            return provider.DeleteFeedback(Id);
        }
    }
}
