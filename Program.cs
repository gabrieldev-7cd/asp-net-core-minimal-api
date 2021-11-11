using MinAPITest.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppdbContext>();
var app = builder.Build();

app.MapGet("v1/todos", (AppdbContext context) => {
    var todos = context.Todos.ToList();
    return Results.Ok(todos);
});

app.Run();
