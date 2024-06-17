namespace first_project.DtosContracts;

public record class RecordDetailDto(
    int Id, 
    string Name,
    int GenreId,
    decimal Price,
    DateOnly ReleaseDate 
);