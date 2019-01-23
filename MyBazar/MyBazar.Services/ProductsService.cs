using MyBazar.Database;
using MyBazar.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBazar.Services
{
   public class ProductsService:DbContext,IDisposable
    {

        public List<Product> GetProducts()
        {
            using(var context = new MyBazarContext())
            {
                return context.Products.ToList();
            }
        }

        public void SaveProduct(Product product)
        {
            using(var context = new MyBazarContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }
        public Product GetProduct(int ID)
        {
            using (var context = new MyBazarContext())
            {
                return context.Products.Find(ID);
            }
        }
        public void UpdateProduct(Product product)
        {
            using (var context = new MyBazarContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void DeleteProduct(int ID)
        {

            using (var context = new MyBazarContext())
            {
                var product = context.Products.Find(ID);
                //context.Entry(product).State = System.Data.Entity.EntityState.Deleted;
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }


    }
}
