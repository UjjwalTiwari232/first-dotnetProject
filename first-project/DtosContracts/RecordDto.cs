namespace first_project.DtosContracts;

public record class RecordDto(
    int Id, 
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate 
);