using Marten;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static SoftwareCatalog.Api.Techs.Models;

namespace SoftwareCatalog.Api.Techs.Endpoints;

public static class AddingATech
{
    public static async Task<Results<Created<TechDetailsResponseModel>, BadRequest>> CanAddTechAsync(
        [FromBody] TechCreateModel request,
        [FromServices] IDocumentSession session,
        [FromServices] IHttpContextAccessor _httpContextAccessor
        )
    {
        var sub = _httpContextAccessor.HttpContext.User.Identity.Name;

        var entity = new TechEntity
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Email = request.Email,
            Phone = request.Phone,
        };
        session.Store(entity);
        await session.SaveChangesAsync();
        var response = entity.MapToModel();
        return TypedResults.Created($"/techs/{entity.Id}", response);
    }
}
