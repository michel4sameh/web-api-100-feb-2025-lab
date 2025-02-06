using Riok.Mapperly.Abstractions;
using static SoftwareCatalog.Api.Techs.Models;

namespace SoftwareCatalog.Api.Techs;


[Mapper]
public static partial class TechMappers
{
    public static partial IQueryable<TechDetailsResponseModel> ProjectToModel(this IQueryable<TechEntity> entity);

    [MapProperty(nameof(TechEntity.Id), nameof(TechDetailsResponseModel.Id))]
    [MapperIgnoreSource(nameof(TechEntity.Id))]
    public static partial TechDetailsResponseModel MapToModel(this TechEntity entity);
}
