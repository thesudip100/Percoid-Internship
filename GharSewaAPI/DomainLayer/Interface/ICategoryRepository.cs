using DomainLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interface
{
    public interface ICategoryRepository
    {
        public Task<string> AddCategoryAsync(ServiceCategoryDTO categoryDTO);
        public Task<IEnumerable<ServiceCategoryDTO>> GetAllAsync();
    }
}
