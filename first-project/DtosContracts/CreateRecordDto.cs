using System.ComponentModel.DataAnnotations;

namespace first_project.DtosContracts;

public record class CreateRecordDto(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(20)]string Genre,
    [Range(1,100)]decimal Price,
    DateOnly ReleaseDate
);