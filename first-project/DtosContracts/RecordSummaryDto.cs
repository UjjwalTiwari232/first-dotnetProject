namespace first_project.DtosContracts;

public record class RecordSummaryDto(
    int Id, 
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate 
);