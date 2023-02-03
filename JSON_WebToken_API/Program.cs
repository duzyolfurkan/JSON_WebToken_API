using JSON_WebToken_API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Statik tanýmladýðýmýz dependency injection sýnýfý burada tanýmladýk.
builder.Services.AddApiServices(builder.Configuration);

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
