using ApplicationLayer.Services.Service_Interface;
using DomainLayer.DTO;
using DomainLayer.Entities;
using DomainLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.Service
{
    public class FeedbackService:IFeedbackService
    {
        private readonly IFeedbackRepository _repository;

        public FeedbackService(IFeedbackRepository repository) 
        {
            _repository = repository;
        }

        public Task<string> AddFeedbackAsync(feedbackDTO feedbackDTO, ClaimsPrincipal user)
        {
            return _repository.AddFeedbackAsync(feedbackDTO,user);
        }

        public Task<string> DeleteFeedbacks(int feedback_id)
        {
            return _repository.DeleteFeedbacks(feedback_id);
        }

        public Task<IEnumerable<Feedback>> GetAllFeedbacksAsync()
        {
            return _repository.GetAllFeedbacksAsync();
        }
    }
}
