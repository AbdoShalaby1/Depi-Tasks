using Microsoft.Identity.Client;
using MongoDB.Bson;
using MongoDB.Driver;
using TMS_2_with_middleware.Context;
using TMS_2_with_middleware.Models;

namespace TMS_2_with_middleware.Repositories
{
    public class TaskRepository(AppDbContext context) : IRepository<TaskItem>
    {
        public async Task AddAsync(TaskItem item)
        {
            await context.Tasks.InsertOneAsync(item);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var res = await context.Tasks.DeleteOneAsync(x => x.Id == id);
            return (res is not null);
        }

        public async Task<ICollection<TaskItem>> GetAllAsync()
        {
            return await context.Tasks.Find(_ => true).ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(string id)
        {
            return await context.Tasks.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateItemAsync(string id, TaskItem item)
        {
            var filter = Builders<TaskItem>.Filter.Eq(a => a.Id, id);

            var result = await context.Tasks.ReplaceOneAsync(filter, item);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}
