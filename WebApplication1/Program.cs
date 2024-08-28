

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Log.Logger = new LoggerConfiguration()  //using serilog for Log
//    .MinimumLevel.Debug()
//    .WriteTo.File("log/villaLogs.txt", rollingInterval: RollingInterval.Day).CreateLogger();      //use serilog to custom default logger

//builder.Host.UseSerilog();//to say to the app to use serilog,
//now i will not need it later so i will uninstall iSerilog.AspNetCore and Serilog.Sinks.File from app manager

builder.Services
    .AddControllers(option => {
        option.ReturnHttpNotAcceptable = true;
    })//inside of addcontrollers you can add this parameter option => { option.ReturnHttpNotAcceptable = true;}
    .AddNewtonsoftJson()
    .AddXmlDataContractSerializerFormatters();//add the dependency to package that we added to project//options zo specify return type//serializer o add xml serializer to api
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
