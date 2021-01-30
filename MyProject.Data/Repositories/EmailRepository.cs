using MyProject.Core.Entities.Content;
using MyProject.Core.Entities.Organization;
using MyProject.Core.Repositories;
using MyProject.Data.DbContexts;

namespace MyProject.Data.Repositories
{
    public class EmailRepository : Repository, IEmailRepository
    {
        public EmailRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public void Add(Email email)
        {
            _dbContext.Emails.Add(email);
        }
    }
}
