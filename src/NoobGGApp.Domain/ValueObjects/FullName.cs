namespace NoobGGApp.Domain.ValueObjects;

public record FullName
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
}
