﻿using ApplicationCore.Services;
using System.Runtime.CompilerServices;

namespace Web.Extensions
{
    public static class MapingExtensions
    {
        public static BasketViewModel ToBasketViewModel(this Basket basket)
        {
            
            return new BasketViewModel()
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                Items = basket.Items.Select(x => new BasketItemViewModel()
                {
                    Id = x.Id,
                    PictureUri = x.Product.PictureUri,
                    ProductId = x.ProductId,
                    ProductName = x.Product.Name,
                    Quantity = x.Quantity,
                    UnitPrice = x.Product.Price

                }).ToList()
            };
        }
    }
}
