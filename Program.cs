using MiniToDo.Data;
using MiniToDo.ViewModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");
app.MapGet("/v1/tarefas", (AppDbContext context) =>
{
    var tarefas = context.Tarefas;
    return tarefas is not null ? Results.Ok(tarefas) : Results.NotFound();
});

app.MapGet("/v1/tarefas/{id}", (Guid id, AppDbContext context) =>
{
    var tarefa = context.Tarefas.FirstOrDefault(t => t.Id == id);
    return tarefa is not null ? Results.Ok(tarefa) : Results.NotFound();
});

app.MapPost("/v1/tarefas", (CreateUpdateTarefaViewModel model, AppDbContext context) =>
{
    if (model is null)
    {
        return Results.BadRequest();
    }

    var tarefa = model.MapTo();
    context.Tarefas.Add(tarefa);
    context.SaveChanges();

    return Results.Created($"/v1/tarefas/{tarefa.Id}", tarefa);
});

app.MapPut("/v1/tarefas/{id}", (Guid id, CreateUpdateTarefaViewModel model, AppDbContext context) =>
{
    if (model is null)
    {
        return Results.BadRequest();
    }

    var tarefa = context.Tarefas.FirstOrDefault(t => t.Id == id);
    if (tarefa is null)
    {
        return Results.NotFound();
    }

    tarefa = model.MapTo();
    context.Tarefas.Update(tarefa);
    context.SaveChanges();

    return Results.Ok(tarefa);
});

app.MapDelete("/v1/tarefas/{id}", (Guid id, AppDbContext context) =>
{
    var tarefa = context.Tarefas.FirstOrDefault(t => t.Id == id);
    if (tarefa is null)
    {
        return Results.NotFound();
    }

    context.Tarefas.Remove(tarefa);
    context.SaveChanges();

    return Results.Ok();
});

app.Run();
