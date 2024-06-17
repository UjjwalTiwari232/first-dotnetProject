using System.Diagnostics;
using first_project.DtosContracts;
using first_project.Entities;

namespace first_project.Mapping;

public static class GenreMapping
{
    public static GenreDto ToDto(this Genre genre){
        return new GenreDto(genre.Id,genre.Name);
    }
}
