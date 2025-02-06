using SoftwareCatalog.Api.Techs.Endpoints;

namespace SoftwareCatalog.Api.Techs;

public static class Extentions
{
    public static IServiceCollection AddTechs(this IServiceCollection services)
    {
        services.AddAuthorizationBuilder()
            .AddPolicy("canAddTechs", p =>
            {
                p.RequireRole("manager");
                p.RequireRole("software-center");
            });

        return services;
    }

    public static IEndpointRouteBuilder MapTechs(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("techs").WithTags("Approved Techs").WithDescription("The Approved Techs for the Company");

        group.MapPost("/", AddingATech.CanAddTechAsync).RequireAuthorization("canAddTechs");
        group.MapGet("/{id}", GettingATech.GetTechsAsync).WithTags("Approved Techs", "Catalog");
        group.MapGet("/", GettingATech.GetTechsAsync);
        return group;

    }
}
