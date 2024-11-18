using Microsoft.AspNetCore.Identity;
using NoobGGApp.Domain.Common.Entities;

namespace NoobGGApp.Domain.Identity
{
    public sealed class ApplicationUser : IdentityUser<long>, ICreatedByEntity, IModifiedByEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? BannerUrl { get; set; }
        public string? Bio { get; set; }
        public DateTimeOffset LastOnline { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string? CreatedByUserId { get; set; }

        public string? ModifiedByUserId { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
    }
}
