
using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        public void DeleteProduct(Products p) => ProductsDAO.DeleteProduct(p);


        public List<Category> GetCategories() => CategoryDAO.GetCategories();



        public Products GetProductById(int id) => ProductsDAO.FindProductById(id);


        public List<Products> GetProducts() => ProductsDAO.GetProducts();


        public void SaveProduct(Products p) => ProductsDAO.SaveProduct(p);


        public void UpdateProduct(Products p) => ProductsDAO.UpdateProduct(p);
    }
}
