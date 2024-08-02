using DomainLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.Service_Interface
{
    public interface ICategoryService
    {
        public Task<string> AddCategoryAsync(ServiceCategoryDTO categoryDTO);
        public Task<IEnumerable<ServiceCategoryDTO>> GetAllAsync();
    }
}
