using MongoDB.Driver;
using TMS_2_with_middleware.Models;

namespace TMS_2_with_middleware.Context
{
    public class AppDbContext(IMongoDatabase database)
    {
        public IMongoCollection<User> Users = database.GetCollection<User>("Users");
        public IMongoCollection<TaskItem> Tasks = database.GetCollection<TaskItem>("Tasks");
    }
}