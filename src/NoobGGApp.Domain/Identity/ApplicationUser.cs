using Microsoft.AspNetCore.Identity;
using NoobGGApp.Domain.Common.Entities;
using NoobGGApp.Domain.DomainEvents;
using TSID.Creator.NET;

namespace NoobGGApp.Domain.Identity
{
    public sealed class ApplicationUser : IdentityUserBase<long>, ICreatedByEntity, IModifiedByEntity
    {
        public string FullName { get; set; }
        // public string? LastName { get; set; }
        // public string? ProfilePictureUrl { get; set; }
        // public string? BannerUrl { get; set; }
        // public string? Bio { get; set; }
        // public DateTimeOffset LastOnline { get; set; }

        public static ApplicationUser Create(string fullName, string email)
        {

            var id = TsidCreator
            .GetTsid()
            .ToLong();

            var user = new ApplicationUser
            {
                Id = id,
                FullName = fullName,
                Email = email,
                UserName = email,
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var userRegistered = new UserRegisteredDomainEvent(id, email, fullName);

            user.RaiseDomainEvent(userRegistered);

            return user;
        }
    }
}
