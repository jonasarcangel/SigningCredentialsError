using MyProject.Core.Entities.Content;
using MyProject.Core.Repositories;
using MyProject.Data.DbContexts;

namespace MyProject.Data.Repositories
{
    public class ActivityRepository : Repository, IActivityRepository
    {
        public ActivityRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public void Add(Activity activity)
        {
            _dbContext.Activities.Add(activity);
        }
    }
}
