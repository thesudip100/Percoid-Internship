using ApplicationLayer.Services.Service_Interface;
using DomainLayer.DTO;
using DomainLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository repo;

        public CategoryService(ICategoryRepository _repo)
        {
            repo = _repo;
        }

        public Task<string> AddCategoryAsync(ServiceCategoryDTO categoryDTO)
        {
            return repo.AddCategoryAsync(categoryDTO);
        }

        public Task<IEnumerable<ServiceCategoryDTO>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }
    }
}
