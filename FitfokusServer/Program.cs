using FitfokusServer.Interfaces;
using FitfokusServer.Repositories;
using FitfokusServer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddDbContext<DataContext>(options =>
//{

//    options.UseSqlServer((Environment.GetEnvironmentVariable("ESTORE_ESTOREDB_CONNECTIONSTRING").Trim('"')));
//    //options.UseSqlServer( "Server=localhost,1433;Database=eStoreDb;User Id=sa;Password=Password_2_Change_4_Real_Cases_&;TrustServerCertificate=true;");
//});


var app = builder.Build();


app.UseMiddleware<LogService>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x
.AllowAnyHeader()
.AllowAnyMethod()
.WithOrigins("http://localhost:5173", "http://localhost:3000", "https://fitfokus.azurewebsites.net/"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
