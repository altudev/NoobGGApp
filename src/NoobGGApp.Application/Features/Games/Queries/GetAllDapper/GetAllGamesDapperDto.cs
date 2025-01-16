namespace NoobGGApp.Application.Features.Games.Queries.GetAllDapper;

public sealed record GetAllGamesDapperDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string ImageUrl { get; set; }

    public GetAllGamesDapperDto(long id, string name, string? description, string imageUrl)
    {
        Id = id;
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
    }

    public GetAllGamesDapperDto()
    {

    }
}
