using NoobGGApp.Domain.Common.Entities;
using NoobGGApp.Domain.ValueObjects;

namespace NoobGGApp.Domain.Entities;

public sealed class Customer : EntityBase<long>
{

    public Customer(Email email)
    {
        Email = email;
    }


    public FullName FullName { get; set; } // first_name, last_name
    public Email Email { get; set; }
    public Address Address { get; set; } // street, city, country, zip_code, state, apartment


}
