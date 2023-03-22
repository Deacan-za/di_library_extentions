using Shared.ServiceCollection.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSharedServices(configuration =>
{
    configuration.InputValue = "This is a configuration string";
    configuration.ProductId = 1234;
});

builder.Services.AddControllers();
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
