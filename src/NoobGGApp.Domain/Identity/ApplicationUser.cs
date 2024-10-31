using Microsoft.AspNetCore.Identity;
using NoobGGApp.Domain.Common.Entities;

namespace NoobGGApp.Domain.Identity;

public sealed class ApplicationUser : IdentityUser<Guid>, IEntity<Guid>, ICreatedByEntity, IModifiedByEntity
{

    public string CreatedByUserId { get; set; }
    public DateTimeOffset CreatedOn { get; set; }

    public string? ModifiedByUserId { get; set; }
    public DateTimeOffset? ModifiedOn { get; set; }
}
