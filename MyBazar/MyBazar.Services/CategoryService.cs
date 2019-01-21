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
   public class CategoryService:DbContext,IDisposable
    {

        public List<Category> GetCategories()
        {
            using(var context = new MyBazarContext())
            {
                return context.Categories.ToList();
            }
        }

        public void SaveCategory(Category category)
        {
            using(var context = new MyBazarContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }
        public Category GetCategory(int ID)
        {
            using (var context = new MyBazarContext())
            {
                return context.Categories.Find(ID);
            }
        }
        public void UpdateCategory(Category category)
        {
            using (var context = new MyBazarContext())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void DeleteCategory(int ID)
        {

            using (var context = new MyBazarContext())
            {
                var category = context.Categories.Find(ID);
                //context.Entry(category).State = System.Data.Entity.EntityState.Deleted;
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }


    }
}
