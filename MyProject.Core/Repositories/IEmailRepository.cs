using MyProject.Core.Entities.Organization;

namespace MyProject.Core.Repositories
{
    public interface IEmailRepository : IRepository
    {
        void Add(Email email);
    }
}
