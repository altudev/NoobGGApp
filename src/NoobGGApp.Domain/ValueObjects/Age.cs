namespace NoobGGApp.Domain.ValueObjects;

// Age value object for domain-driven design, encapsulates age-related validation and representation
public sealed record Age
{
    private const int MinimumAge = 0;
    private const int MaximumAge = 150;

    public int Value { get; }

    // Constructor that ensures only valid ages are accepted
    public Age(int value)
    {
        ValidateAge(value);

        Value = value;
    }

    // TryCreate method for safe age object creation without throwing exceptions
    public static bool TryCreate(int value, out Age? age) // int.TryParse(value, out Age? age)
    {
        if (IsValid(value))
        {
            age = new Age(value);
            return true;
        }

        age = null;
        return false;
    }

    // Checks if the given age is within the acceptable range
    public static bool IsValid(int value) =>
        value is >= MinimumAge and <= MaximumAge;

    // Validates age and throws a domain-specific exception if invalid
    private static void ValidateAge(int value)
    {
        if (!IsValid(value))
        {
            throw new InvalidAgeException(
                nameof(value),
                value,
                value < MinimumAge ? $"Age cannot be negative. Provided value: {value}" : $"Age cannot be greater than {MaximumAge}. Provided value: {value}");
        }
    }

    // Implicit conversion to int for ease of use
    public static implicit operator int(Age age) => age.Value; // = (int)age.Value;

    // Explicit conversion from int to Age with validation
    public static explicit operator Age(int value) =>
        TryCreate(value, out var age) ? age! : throw new InvalidAgeException(nameof(value), value, $"Invalid age value: {value}");

    // String representation of the Age value object
    public override string ToString() => Value.ToString();
}

// Custom exception for invalid age values to provide better domain context
public class InvalidAgeException : ArgumentOutOfRangeException
{
    public InvalidAgeException(string paramName, int actualValue, string message)
        : base(paramName, actualValue, message)
    {
    }
}
