namespace NoobGGApp.Application.Features.Games.Queries.GetById;

public sealed record GetGameByIdDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }

    public GetGameByIdDto(long id, string name, string description, string imageUrl)
    {
        Id = id;
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
    }

    public GetGameByIdDto()
    {

    }
}
