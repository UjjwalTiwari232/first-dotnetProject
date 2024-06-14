using first_project.Data;
using first_project.DtosContracts;
using first_project.EndPoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("RecordStore");

builder.Services.AddSqlite<RecordStoreContext>(connString);

var app = builder.Build();

app.MapRecordEndPoints();

app.Run();
