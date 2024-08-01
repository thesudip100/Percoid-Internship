using Dapper;
using DomainLayer.DTO;
using DomainLayer.Entities;
using DomainLayer.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace InfrastructureLayer.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;

        public FeedbackRepository(IConfiguration configuration) 
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
            this.configuration = configuration;
        }
        public async Task<string> AddFeedbackAsync(feedbackDTO feedbackDTO, ClaimsPrincipal user)
        {
            var userId= GetUserIdFromToken(user);
            using( var connection= new SqlConnection(connectionString))
            {
                var query = " Insert into Feedbacks(UserId,feedbackby,feedbackfor,Message) values(@id,@sender,@recipient,@message)";
                await connection.ExecuteAsync(query, new
                {
                    @id=userId,
                    @sender=feedbackDTO.feedbackby,
                    @recipient=feedbackDTO.feedbackfor,
                    @message=feedbackDTO.Message
                });
                return "Thank you for your feedback.Your feedback has been registered";
            }
        }

        public async Task<string> DeleteFeedbacks(int feedback_id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "Delete from Feedbacks where id=@id";
                await connection.ExecuteAsync(query, new
                {
                    @id = feedback_id,
                    
                });
                return " Feedback deleted successfully";
            }
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbacksAsync()
        {
            using(var connection = new SqlConnection(connectionString))
            {
                var query = "select * from feedbacks";
                var entities=await connection.QueryAsync<Feedback>(query);
                return entities.ToList();
            }
        }

        private int GetUserIdFromToken(ClaimsPrincipal user)
        {
            if (user.HasClaim(c => c.Type == ClaimTypes.SerialNumber))
            {
                return int.Parse(user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.SerialNumber)?.Value);
            }
            throw new Exception("User ID not found in token");
        }
    }
}
