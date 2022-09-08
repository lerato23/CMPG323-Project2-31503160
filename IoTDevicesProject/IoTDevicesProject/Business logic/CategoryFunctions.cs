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
            if (!categoryChecker(cat.CategoryId))
            {
                throw new KeyNotFoundException();
            }
            Category category = iotdeviceDBContext.Categories.Where(e => e.CategoryId == cat.CategoryId).FirstOrDefault();
            category.CategoryId = cat.CategoryId;
            category.DateCreated = cat.DateCreated;
            category.CategoryName = cat.CategoryName;
            category.CategoryDescription = cat.CategoryDescription;
            iotdeviceDBContext.Categories.Update(category);
            iotdeviceDBContext.SaveChanges();
        }

        public void deleteCategory(Category cat)
        {
            if (categoryChecker(cat.CategoryId))
            {
                Category category = iotdeviceDBContext.Categories.Where(e => e.CategoryId == cat.CategoryId).FirstOrDefault();
                iotdeviceDBContext.Categories.Remove(category);
                iotdeviceDBContext.SaveChanges();
            }
        }
        public List<Device> devicesInCategory(Guid id)
        {
            if(id == null)
            {
                throw new NullReferenceException();
            }

            if (!categoryChecker(id))
            {
                throw new KeyNotFoundException();
            }

            return iotdeviceDBContext.Devices.Where(i => i.CategoryId == id).ToList();
        }

        public int zoneVsCategory(Guid id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }

            if (!categoryChecker(id))
            {
                throw new KeyNotFoundException();
            }
            int count = (from d in iotdeviceDBContext.Devices join z in iotdeviceDBContext.Zones on d.ZoneId equals z.ZoneId where d.CategoryId == id select new { 
                DeviceId = d.DeviceId,
                ZoneId = d.ZoneId,
                CategoryId = d.CategoryId,
                DeviceName = d.DeviceName
            }).Count();
            return count;
        }
    }
}
