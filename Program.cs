var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => {
    var todo =  new Todo(Guid.NewGuid(), "Criar uma Api", false);
    return Results.Ok(todo);
});

app.Run();
