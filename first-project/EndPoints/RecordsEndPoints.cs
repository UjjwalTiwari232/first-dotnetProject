using first_project.Data;
using first_project.DtosContracts;
using first_project.Entities;
using first_project.Mapping;
using Microsoft.EntityFrameworkCore;

namespace first_project.EndPoints;

public static class RecordsEndPoints
{
    const string GetGameEndPointName = "GetRecord";

    public static RouteGroupBuilder MapRecordEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("records")
        .WithParameterValidation();

        //Get /records
        group.MapGet("/",async (RecordStoreContext dbContext)=> 
          await dbContext.Records
                .Include(record => record.Genre)
                .Select(record => record.ToRecordSummaryDto())
                .AsNoTracking()
                .ToListAsync());


        //Get /records/1
        group.MapGet("/{id}", async (int id, RecordStoreContext dbcontext)=> {

                Record? record = await dbcontext.Records.FindAsync(id);
                return record is null? 
                Results.NotFound() : Results.Ok(record.ToRecordDetailDto());
            })
        .WithName(GetGameEndPointName);


        //Post /record
        group.MapPost("/", async (CreateRecordDto newRecord,RecordStoreContext dbContext)=>{
            
            Record record = newRecord.ToEntity();
            // record.Genre =  dbContext.Genres.Find(newRecord.GenreId);


            // RecordDto record = new(
            //     records.Count+1,
            //     newRecord.Name,
            //     newRecord.Genre,
            //     newRecord.Price,
            //     newRecord.ReleaseDate
            // );

            // records.Add(record);
            dbContext.Records.Add(record);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetGameEndPointName,
                new {id = record.Id},
                record.ToRecordDetailDto());
        });

        //Put /records
        group.MapPut("/{id}", async (int id , UpdateRecordDto updatedRecord,RecordStoreContext dbContext)=>{

            // var index = records.FindIndex(record => record.Id==id);
            var existingRecord = await dbContext.Records.FindAsync(id);

            if(existingRecord==null){
                return Results.NotFound();
            }
            // records[index] = new RecordSummaryDto(
            //     id,
            //     updatedRecord.Name,
            //     updatedRecord.Genre,
            //     updatedRecord.Price,
            //     updatedRecord.ReleaseDate
            // );
            dbContext.Entry(existingRecord)
                .CurrentValues
                .SetValues(updatedRecord.ToEntity(id));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        //Delete /records/1
        group.MapDelete("/{id}",async (int id,RecordStoreContext dbContext)=>{
            // records.RemoveAll(record => record.Id==id);
            await dbContext.Records
                .Where(record => record.Id == id)
                .ExecuteDeleteAsync();
                
            return Results.NoContent();
        });


        return group;
    }

}
