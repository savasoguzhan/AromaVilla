using Web.Interfaces;

namespace Web.Services
{
    public class HomeModelService : IHomeViewModelService
    {
        private readonly IRepository<Category> _categoryRepo;
        private readonly IRepository<Brand> _brandRepo;
        private readonly IRepository<Product> _productRepo;

        public HomeModelService(IRepository<Category> categoryRepo, IRepository<Brand> brandRepo, IRepository<Product> productRepo)
        {
            _categoryRepo = categoryRepo;
            _brandRepo = brandRepo;
            _productRepo = productRepo;
        }
        public async Task<HomeViewModel> GetHomeViewModelAsync(int? categoryId, int? brandId, int pageId = 1)
        {
            var products = await _categoryRepo.GetAllAsync();
            var vm = new HomeViewModel()
            {
                Products = products.Select(x => new ProductViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    PictureUri = x.PictureUri,
                    Price = x.Price
                }).ToList(),
            };
        }
    }
}
