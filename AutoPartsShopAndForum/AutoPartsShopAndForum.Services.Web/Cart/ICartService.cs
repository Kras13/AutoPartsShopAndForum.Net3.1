namespace AutoPartsShopAndForum.Services.Web.Cart
{
    using AutoPartsShopAndForum.Services.Data.Product;
    using System.Collections.Generic;

    public interface ICartService
    {
        int OrderProducts(ICollection<ProductCartModel> products, string userId, int townId, string street);
    }
}
