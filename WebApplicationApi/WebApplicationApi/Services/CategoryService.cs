using WebApplicationApi.Models;
using System.Threading.Tasks;


namespace WebApplicationApi.Services
{
    public class CategoryService : ICategoryService
    {

        TaskContext context;

        public CategoryService(TaskContext context) 
        {
            this.context = context;
        }

        public IEnumerable<Category> Get() 
        {
            return context.Categories;
        }

        public async System.Threading.Tasks.Task Save(Category category)
        {
            context.Add(category);
            await context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Update(Guid id, Category category)
        {

            Category currentCategory = context.Categories.Find(id);

            if(currentCategory != null) 
            {
                currentCategory.CategoryName = category.CategoryName;
                currentCategory.CategoryDescription = category.CategoryDescription;
                currentCategory.CategorySize = category.CategorySize;
                await context.SaveChangesAsync();
            }
        }

        public async System.Threading.Tasks.Task Delete(Guid id)
        {

            Category currentCategory = context.Categories.Find(id);

            if (currentCategory != null)
            {
                context.Categories.Remove(currentCategory);
                await context.SaveChangesAsync();
            }
        }

    }

    public interface ICategoryService 
    {
        IEnumerable<Category> Get();
        System.Threading.Tasks.Task Save(Category category);
        System.Threading.Tasks.Task Update(Guid id, Category category);
        System.Threading.Tasks.Task Delete(Guid id);


    }
}
