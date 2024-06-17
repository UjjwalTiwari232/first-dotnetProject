using first_project.Data;
using first_project.Mapping;
using Microsoft.EntityFrameworkCore;

namespace first_project.EndPoints;

public static class GenreEndPoints
{
    public static RouteGroupBuilder MapGenreEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("genres");
        group.MapGet("/", async (RecordStoreContext dbContext)=>
            await dbContext.Genres
                            .Select(genre => genre.ToDto())
                            .AsTracking()
                            .ToListAsync()
        );
        return group;
    }
}
