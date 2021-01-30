using MyProject.Core.Repositories;
using MyProject.Data.DbContexts;
using System.Threading.Tasks;

namespace MyProject.Data.Repositories
{
    public class Repository : IRepository
    {
        protected readonly AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
