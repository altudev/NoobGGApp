namespace NoobGGApp.Domain.ValueObjects;

public record struct CustomerId
{
    public long Value { get; init; }

    public CustomerId(long value)
    {
        if (value <= 0)
            throw new ArgumentException("Customer ID cannot be less than or equal to 0");

        Value = value;
    }
}
