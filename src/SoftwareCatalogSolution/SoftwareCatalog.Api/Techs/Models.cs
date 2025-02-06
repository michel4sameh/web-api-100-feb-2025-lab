namespace SoftwareCatalog.Api.Techs;

public class Models
{
    public record TechCreateModel
    {
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
    }

    public record TechDetailsResponseModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }

    }

}
