namespace NoobGGApp.Domain.Common.Entities;

public interface ICreatedByEntity
{
    string CreatedByUserId { get; set; }
    DateTimeOffset CreatedOn { get; set; }
}
