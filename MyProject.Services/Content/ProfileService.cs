using MyProject.Core.Entities.Common;
using MyProject.Core.Entities.Content;
using MyProject.Core.Repositories;
using MyProject.Data.Identity;
using System;
using System.Threading.Tasks;

namespace MyProject.Services.Content
{
    public class ProfileService : IProfileService
    {
        private readonly INodeRepository _nodeRepository;

        public ProfileService(INodeRepository nodeRepository)
        {
            _nodeRepository = nodeRepository;
        }

        public async Task Add(ApplicationUser user)
        {
            var profile = new Node()
            {
                Id = Guid.NewGuid().ToString(),
                Slug = user.UserName,
                CreatedBy = user.Id,
                CreatedDate = DateTimeOffset.UtcNow.ToString("s"),
                Module = "MyProject.Profiles",
                Type = "Profile"
            };
            profile.CustomFields = new NodeCustomFields();
            profile.CustomFields.Id = Guid.NewGuid().ToString();
            profile.CustomFields.NodeId = profile.Id;
            await AddAsync(profile);
        }

        public async Task AddAsync(Node profile)
        {
            await _nodeRepository.AddAsync(profile);
            await _nodeRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Node profile)
        {
            await _nodeRepository.UpdateAsync(profile);
            await _nodeRepository.SaveChangesAsync();
        }

        //public Task GetProfileDataAsync(ProfileDataRequestContext context)
        //{
        //    var nameClaim = context.Subject.FindAll(JwtClaimTypes.Name);
        //    context.IssuedClaims.AddRange(nameClaim);

        //    var roleClaims = context.Subject.FindAll(JwtClaimTypes.Role);
        //    context.IssuedClaims.AddRange(roleClaims);

        //    return Task.CompletedTask;
        //}

        //public Task IsActiveAsync(IsActiveContext context)
        //{
        //    return Task.CompletedTask;
        //}
    }
}
