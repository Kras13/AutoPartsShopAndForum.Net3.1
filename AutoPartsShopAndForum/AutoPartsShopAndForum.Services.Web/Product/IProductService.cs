namespace AutoPartsShopAndForum.Services.Web.Product
{
    using AutoPartsShopAndForum.Services.Data.Product;
    using System.Collections.Generic;

    public interface IProductService
    {
        int AddProduct(ProductInputModel product);

        ProductQueryModel GetQueriedProducts(
             int currentPageIndex,
             int productsPerPage,
             string searchCriteria,
             ProductSorting sorting,
             int? categoryId,
             IEnumerable<int> selectedSubcategories = null);

        ICollection<ProductModel> GetAllProducts();

        ProductModel GetProduct(int id);
    }
}
