namespace Web.Interfaces
{
    public interface IBasketViewModelService
    {
        Task<BasketViewModel> GetBasketViewModel();

        Task<BasketViewModel> AddItemToBasketAsync(int productId, int quantity);
    }
}
