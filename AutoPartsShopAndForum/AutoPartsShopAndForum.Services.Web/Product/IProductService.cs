namespace AutoPartsShopAndForum.Services.Web.Product
{
    using AutoPartsShopAndForum.Services.Data.Product;
    using System.Collections.Generic;

    public interface IProductService
    {
        int AddProduct(ProductInputModel product);

        ICollection<ProductModel> GetQueriedProducts(
            string searchCriteria, ProductSorting Sorting, int? categoryId);

        ICollection<ProductModel> GetAllProducts();

        ProductModel GetProduct(int id);
    }
}
