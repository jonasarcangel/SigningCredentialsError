using MyProject.Core.Entities.Content;
using MyProject.Data.Identity;
using System.Threading.Tasks;

namespace MyProject.Services.Content
{
    public interface IProfileService
    {
        Task Add(ApplicationUser user);
        Task AddAsync(Node profile);
        Task UpdateAsync(Node profile);
    }
}
