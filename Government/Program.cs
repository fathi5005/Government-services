
using Government.Errors;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDependancy(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler();

app.UseStaticFiles();

app.Run();
