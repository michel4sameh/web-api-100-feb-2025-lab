using Marten;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static SoftwareCatalog.Api.Techs.Models;

namespace SoftwareCatalog.Api.Techs.Endpoints;

public class GettingATech(IDocumentSession session) : ControllerBase
{
    [HttpGet("/techs/{id:guid}")]
    public async Task<ActionResult> GetTechAsync([FromRoute] Guid id)
    {
        var response = await session.Query<TechEntity>().Where(v => v.Id == id).
            ProjectToModel().SingleOrDefaultAsync();

        return response switch
        {
            null => NotFound(),
            _ => Ok(response)
        };
    }

    public static async Task<Ok<IReadOnlyList<TechDetailsResponseModel>>> GetTechsAsync(IDocumentSession session)
    {
        var response = await session.Query<TechEntity>()
                                    .ProjectToModel()
                                    .ToListAsync();
        return TypedResults.Ok(response);
    }
}

