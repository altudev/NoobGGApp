using NoobGGApp.Domain.Common.Entities;
using NoobGGApp.Domain.ValueObjects;

namespace NoobGGApp.Domain.Entities;

public sealed class Game : EntityBase<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }


    public Game()
    {
        Email userEmail = new Email("alper.tunga@yazilim.academy");

        string email = userEmail;

        Customer customer1 = new Customer("alper.tunga@yazilim.academy");

        customer1.Address.City = "Ankara";

        Customer customer2 = new Customer("alper.tunga@yazilim.academy");

        if (customer1.Address == customer2.Address)
        {

        }
    }

}
