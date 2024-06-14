using first_project.DtosContracts;

namespace first_project.EndPoints;

public static class RecordsEndPoints
{
    const string GetGameEndPointName = "GetRecord";

    private static readonly List<RecordDto> records = [
        new(
            1,
            "First",
            "first-desc",
            19.99M,
            new DateOnly(2000,2,2)
        ),
        new(
            2,
            "Second",
            "second-desc",
            18.99M,
            new DateOnly(2001,2,2)
        ),
        new(
            3,
            "Third",
            "third-desc",
            17.99M,
            new DateOnly(2002,2,2)
        ),
    ];

    public static RouteGroupBuilder MapRecordEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("records")
        .WithParameterValidation();

        //Get /records
        group.MapGet("/",()=> records);


        //Get /records/1
        group.MapGet("/{id}",(int id)=> {

                RecordDto? record = records.Find(record => record.Id==id);
                return record is null? Results.NotFound() : Results.Ok(record);
            })
        .WithName(GetGameEndPointName);


        //Post /record
        group.MapPost("/", (CreateRecordDto newRecord)=>{


            RecordDto record = new(
                records.Count+1,
                newRecord.Name,
                newRecord.Genre,
                newRecord.Price,
                newRecord.ReleaseDate
            );

            records.Add(record);
            return Results.CreatedAtRoute(GetGameEndPointName,new {id = record.Id},record);
        });

        //Put /records
        group.MapPut("/{id}",(int id , UpdateRecordDto updatedRecord)=>{
            var index = records.FindIndex(record => record.Id==id);

            if(index == -1){
                return Results.NotFound();
            }
            records[index] = new RecordDto(
                id,
                updatedRecord.Name,
                updatedRecord.Genre,
                updatedRecord.Price,
                updatedRecord.ReleaseDate
            );

            return Results.NoContent();
        });

        //Delete /records/1
        group.MapDelete("/{id}",(int id)=>{
            records.RemoveAll(record => record.Id==id);
            return Results.NoContent();
        });


        return group;
    }

}
