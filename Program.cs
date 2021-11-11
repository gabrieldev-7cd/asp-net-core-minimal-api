using MinAPITest.Data;
using MinAPITest.ViewModels;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppdbContext>();
var app = builder.Build();

app.MapGet("v1/todos", (AppdbContext context) => {
    var todos = context.Todos.ToList();
    return Results.Ok(todos);
});

app.MapPost("v1/todos", (AppdbContext context, CreateTodoViewModel model) => {
    var todo = model.MapTo();
    if( !model.IsValid )
    {
        return Results.BadRequest(model.Notifications);
    }

    context.Todos.Add(todo);
    context.SaveChanges();

    return Results.Created($"/v1/todos/{todo.Id}", todo);
});

app.Run();
