using first_project.DtosContracts;
using first_project.Entities;

namespace first_project.Mapping;

public static class RecordMapping
{
    public static Record ToEntity(this CreateRecordDto record){

       return new Record(){
            Name = record.Name,
            GenreId = record.GenreId,
            Price = record.Price,
            ReleaseDate = record.ReleaseDate
        };
    }

    public static Record ToEntity(this UpdateRecordDto record, int id){

       return new Record(){
            Id = id,
            Name = record.Name,
            GenreId = record.GenreId,
            Price = record.Price,
            ReleaseDate = record.ReleaseDate
        };
    }

    public static RecordSummaryDto ToRecordSummaryDto(this Record record){
        return new(
            record.Id,
            record.Name,
            record.Genre!.Name,
            record.Price,
            record.ReleaseDate
        );
    }

        public static RecordDetailDto ToRecordDetailDto(this Record record){
        return new(
            record.Id,
            record.Name,
            record.GenreId
            ,
            record.Price,
            record.ReleaseDate
        );
    }
}
