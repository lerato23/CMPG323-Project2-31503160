using IoTDevicesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTDevicesProject.Business_logic
{
    public class CategoryFunctions
    {
        private iotdevicesdatabaseContext iotdeviceDBContext;
        public CategoryFunctions(iotdevicesdatabaseContext DBContext)
        {
            iotdeviceDBContext = DBContext;
        }

        public List<Category> getAllCategory()
        {
            List<Category> category = new List<Category>();
            category = iotdeviceDBContext.Categories.ToList();
            return category;
        }

        public Category getCategoryWithId(Guid categoryId)
        {
            Category cate = new Category();
            cate = iotdeviceDBContext.Categories.Where(x => x.CategoryId == categoryId).Single();
            return cate;
        }

        private bool categoryChecker(Guid categoryId)
        {
            Category cat = iotdeviceDBContext.Categories.Where(x => x.CategoryId == categoryId).Single();
            bool result = true;
            if (cat == null)
            {
                result = false;
            }
            return result;
        }

        public void createCategory(Category category)
        {
            category.CategoryId = Guid.NewGuid();
            category.DateCreated = new DateTime();
            iotdeviceDBContext.Categories.Add(category);
            iotdeviceDBContext.SaveChanges();
        }

        public void updateCategory(Category cat)
        {
            if (categoryChecker(cat.CategoryId))
            {
                Category category = new Category();
                category.CategoryId = cat.CategoryId;
                category.DateCreated = cat.DateCreated;
                category.CategoryName = cat.CategoryName;
                category.CategoryDescription = cat.CategoryDescription;
                iotdeviceDBContext.Categories.Update(category);
                iotdeviceDBContext.SaveChanges();
            }
        }

        public void deleteCategory(Category cat)
        {
            if (categoryChecker(cat.CategoryId))
            {
                iotdeviceDBContext.Categories.Remove(cat);
                iotdeviceDBContext.SaveChanges();
            }
        }
    }
}
