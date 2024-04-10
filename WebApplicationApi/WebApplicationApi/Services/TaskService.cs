using WebApplicationApi.Models;
using System.Threading.Tasks;

namespace WebApplicationApi.Services

{
    public class TaskService : ITaskService
    {
        TaskContext context;

        public TaskService(TaskContext context)
        {
            this.context = context;
        } 
        
        public IEnumerable<Models.Task> Get() 
        {
            return context.Tasks;
        }

        public async System.Threading.Tasks.Task Save(Models.Task task)
        {
            context.Add(task);
            await context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Update(Guid id, Models.Task task)
        {

            Models.Task currentTask = context.Tasks.Find(id);

            if (currentTask != null)
            {
                currentTask.Title = task.Title;
                currentTask.Description = task.Description;
                currentTask.Created = task.Created;
                currentTask.CategoryId = task.CategoryId;   
                await context.SaveChangesAsync();
            }
        }

        public async System.Threading.Tasks.Task Delete(Guid id)
        {

            Models.Task currentTask = context.Tasks.Find(id);

            if (currentTask != null)
            {
                context.Tasks.Remove(currentTask);
                await context.SaveChangesAsync();
            }
        }
    }

    public interface ITaskService 
    {
        IEnumerable<Models.Task> Get();
        System.Threading.Tasks.Task Save(Models.Task task);
        System.Threading.Tasks.Task Update(Guid id, Models.Task task);
        System.Threading.Tasks.Task Delete(Guid id);
    }
}
