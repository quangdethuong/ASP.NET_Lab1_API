using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductsDAO
    {

        public static List<Products> GetProducts()
        {
            var listProducts = new List<Products>();
            try
            {
                using (var context = new MyDbContext())
                {
                    listProducts = context.Products.Include(p => p.Category).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listProducts;
        }

        public static Products FindProductById(int proId)
        {
            Products p = new Products();
            try
            {
                using (var context = new MyDbContext())
                {
                    p = context.Products.SingleOrDefault(x => x.ProductId == proId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return p;
        }


        public static void SaveProduct(Products p)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Products.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateProduct(Products p)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry<Products>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteProduct(Products p)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var p1 = context.Products.SingleOrDefault(c => c.ProductId == p.ProductId);
                    context.Products.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
