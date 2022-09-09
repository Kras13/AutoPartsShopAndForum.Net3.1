namespace AutoPartsShopAndForum.Services.Web.Product
{
    using AutoPartsShopAndForum.Services.Data.Product;
    using System.Collections.Generic;

    public interface IProductService
    {
        int AddProduct(ProductInputModel product);

        ICollection<ProductModel> GetQueriedProducts(string searchCriteria, int? categoryId, ProductSorting Sorting);

        ICollection<ProductModel> GetAllProducts();

        ProductModel GetProduct(int id);
    }
}
