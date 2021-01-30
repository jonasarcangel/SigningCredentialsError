using MyProject.Core.Entities.Content;
using MyProject.Core.Repositories;
using MyProject.Data.DbContexts;
using System.Linq;

namespace MyProject.Data.Repositories
{
    public class MessageRepository : Repository, IMessageRepository
    {
        public MessageRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public IQueryable<Message> Get(string groupId)
        {
            return from m in _dbContext.Messages
                   where m.GroupId == groupId
                   select m;
        }

        public void Add(Message message)
        {
            _dbContext.Messages.Add(message);
        }
    }
}
