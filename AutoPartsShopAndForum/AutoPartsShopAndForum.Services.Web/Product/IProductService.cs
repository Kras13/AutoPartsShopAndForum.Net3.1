﻿namespace AutoPartsShopAndForum.Services.Web.Product
{
    using AutoPartsShopAndForum.Services.Data.Product;
    using AutoPartsShopAndForum.Services.Data.Product.InputModel;
    using System.Collections.Generic;

    public interface IProductService
    {
        int AddProduct(ProductAddInputModel product);

        ICollection<ProductModel> GetProductsByCategoryId(int id);

        ICollection<ProductModel> GetAllProducts();
    }
}
