using System.Text.RegularExpressions;

namespace NoobGGApp.Domain.ValueObjects;

public sealed record Address
{
    public Address(string street, string city, string country, string zipCode, string state, string apartment)
    {
        if (string.IsNullOrEmpty(street))
            throw new ArgumentException("Street cannot be null or empty");

        if (string.IsNullOrEmpty(city))
            throw new ArgumentException("City cannot be null or empty");

        if (string.IsNullOrEmpty(country))
            throw new ArgumentException("Country cannot be null or empty");

        // Basic zip code validation.  Consider enhancing for specific country rules
        if (!Regex.IsMatch(zipCode, @"^\d{5}(?:[-\s]\d{4})?$"))
            throw new ArgumentException("Invalid zip code format");


        if (string.IsNullOrEmpty(state))
            throw new ArgumentException("State cannot be null or empty");

        Street = street;
        City = city;
        Country = country;
        ZipCode = zipCode;
        State = state;
        Apartment = apartment;
    }

    public string Street { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
    public string State { get; set; }
    public string Apartment { get; set; }
}
