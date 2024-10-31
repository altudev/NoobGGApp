namespace NoobGGApp.Domain.Common.Entities;

public interface IModifiedByEntity
{
    string? ModifiedByUserId { get; set; }
    DateTimeOffset? ModifiedOn { get; set; }
}
