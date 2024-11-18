using NoobGGApp.Domain.Common.Entities;
using NoobGGApp.Domain.ValueObjects;

namespace NoobGGApp.Domain.Entities;

public sealed class Customer : EntityBase<CustomerId>
{
    public FullName FullName { get; set; } // first_name, last_name
    public Address Address { get; set; } // street, city, country, zip_code, state, apartment
    public Email Email { get; set; }

}
