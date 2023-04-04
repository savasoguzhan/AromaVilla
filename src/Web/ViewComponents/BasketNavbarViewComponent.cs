using Microsoft.AspNetCore.Mvc;
using Web.Interfaces;

namespace Web.ViewComponents
{
    public class BasketNavbarViewComponent : ViewComponent
    {
        private readonly IBasketViewModelService _basketViewModelService;

        public BasketNavbarViewComponent(IBasketViewModelService basketViewModelService)
        {
            _basketViewModelService = basketViewModelService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _basketViewModelService.GetBasketViewModel());
        }
    }
}
