using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MZ.Models;

namespace MZ.DataLayer
{
    public interface IFeedbackProvider
    {
        List<Feedback> GetAllFeedback();
        Feedback GetFeedbackById(long Id);
        long InsertFeedback(Feedback feedback);
        bool UpdateFeedback(Feedback feedback);
        bool DeleteFeedback(long Id);
    }
}
