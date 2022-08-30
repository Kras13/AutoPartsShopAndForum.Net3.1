namespace AutoPartsShopAndForum.Services.Web.Product
{
    using AutoPartsShopAndForum.Services.Data.Product.InputModel;

    public interface IProductService
    {
        int AddProduct(ProductAddInputModel product);
    }
}
