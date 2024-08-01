using DomainLayer.DTO;
using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interface
{
    public interface IFeedbackRepository
    {
        public Task<string> AddFeedbackAsync(feedbackDTO feedbackDTO, ClaimsPrincipal user);
        public Task<IEnumerable<Feedback>> GetAllFeedbacksAsync();
        public Task<string> DeleteFeedbacks(int feedback_id);
    }
}
