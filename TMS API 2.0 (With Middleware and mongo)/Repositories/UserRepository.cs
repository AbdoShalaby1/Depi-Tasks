using MongoDB.Bson;
using MongoDB.Driver;
using TMS_2_with_middleware.Context;
using TMS_2_with_middleware.Models;

namespace TMS_2_with_middleware.Repositories
{
    public class UserRepository(AppDbContext context) : IRepository<User>
    {
        public async Task AddAsync(User item)
        {
            await context.Users.InsertOneAsync(item);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var res = await context.Users.DeleteOneAsync(x => x.Id == id);
            return (res is not null);
        }

        public async Task<ICollection<User>> GetAllAsync()
        {
            return await context.Users.Find(_ => true).ToListAsync();
        }

        public async Task<User?> GetByIdAsync(string id)
        {
            return await context.Users.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateItemAsync(string id, User item)
        {
            var filter = Builders<User>.Filter.Eq(a => a.Id, id);

            var result = await context.Users.ReplaceOneAsync(filter, item);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}
