
namespace NoobGGApp.Domain.Common.Entities;

public abstract class EntityBase<TKey> : IEntity<TKey>, ICreatedByEntity, IModifiedByEntity where TKey : struct
{
    public virtual TKey Id { get; set; }
    public virtual string CreatedByUserId { get; set; }
    public virtual DateTimeOffset CreatedOn { get; set; }

    public virtual string? ModifiedByUserId { get; set; }
    public virtual DateTimeOffset? ModifiedOn { get; set; }
}
