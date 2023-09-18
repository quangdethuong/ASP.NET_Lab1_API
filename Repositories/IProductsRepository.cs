using BusinessObjects;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public interface IProductsRepository
    {
        void SaveProduct(Products p);
        Products GetProductById(int id);
        void DeleteProduct(Products p);
        void UpdateProduct(Products p);
        List<Category> GetCategories();
        List<Products> GetProducts();
    }
}
