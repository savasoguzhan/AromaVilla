
using System.Security.Claims;
using Web.Interfaces;

namespace Web.Services
{
    public class BasketViewModelService : IBasketViewModelService
    {
        private readonly IBasketService _basketSerice;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private HttpContext? HttpContext => _httpContextAccessor.HttpContext;
        private string? UserId => HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        private string? AnonId => HttpContext?.Request.Cookies[Constans.BASKET_COOKIENAME];

        private string BuyerId => UserId ?? AnonId ?? CreateAnonymousId();

        private string _createAnonId = null!;

        private string? CreateAnonymousId()
        {
            if(_createAnonId == null)
            {
                _createAnonId = Guid.NewGuid().ToString();

                HttpContext?.Response.Cookies.Append(Constans.BASKET_COOKIENAME, _createAnonId, new CookieOptions()
                {
                    Expires = DateTime.Now.AddDays(14),
                    IsEssential = true
                });
            }
            return _createAnonId;
        }

        public BasketViewModelService(IBasketService basketSerice, IHttpContextAccessor httpContextAccessor)
        {
            _basketSerice = basketSerice;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<BasketViewModel> AddItemToBasketAsync(int productId, int quantity)
        {
            await _basketSerice.AddItemToBasketAsync(BuyerId, productId, quantity);

            var basket = await _basketSerice.GetOrCreateBasketAsync(BuyerId);
            return basket.ToBasketViewModel();
            

        }

        public async Task<BasketViewModel> GetBasketViewModel()
        {
            var basket = await _basketSerice.GetOrCreateBasketAsync(BuyerId);
            return basket.ToBasketViewModel();
        }
    }
}
