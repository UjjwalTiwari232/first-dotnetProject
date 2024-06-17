using System.ComponentModel.DataAnnotations;

namespace first_project.DtosContracts;

public record class UpdateRecordDto(
    [Required][StringLength(50)] string Name,
    int GenreId,
    [Range(1,100)]decimal Price,
    DateOnly ReleaseDate
);
