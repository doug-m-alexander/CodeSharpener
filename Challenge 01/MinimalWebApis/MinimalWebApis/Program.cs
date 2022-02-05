var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add ToDoRepository 
builder.Services.AddSingleton<IToDoRepository, ToDoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/toDo/", (ToDoItem item, IToDoRepository toDoRepository) =>
{
    toDoRepository.Add(item);
});

app.MapDelete("/toDo/{id}/", (Guid itemId, IToDoRepository toDoRepository) =>
{
    var item = toDoRepository.Get(itemId);
    toDoRepository.Delete(item);
});

app.MapGet("/toDo/{id}/", (Guid itemId, IToDoRepository toDoRepository) =>
{
    return toDoRepository.Get(itemId);
});

app.MapPut("/toDo/{id}/complete/", (Guid itemId, IToDoRepository toDoRepository) =>
{
    toDoRepository.Complete(itemId);
});

app.MapPut("/toDo/{id}/reset/", (Guid itemId, IToDoRepository toDoRepository) =>
{
    toDoRepository.Reset(itemId);
});

app.MapGet("/toDo/", (IToDoRepository toDoRepository) =>
{
    return toDoRepository.GetAllToDoItems();
});

app.MapGet("/toDo/true/", (IToDoRepository toDoRepository) =>
{
    return toDoRepository.GetCompletedToDoItems();
});

app.MapGet("/toDo/false/", (IToDoRepository toDoRepository) =>
{
    return toDoRepository.GetIncompleteToDoItems();
});


app.Run();

public class ToDoItem
{
    public ToDoItem(string description)
    {
        Id = Guid.NewGuid();
        Description = description;
        IsCompleted = false;
    }
    public Guid Id { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}

public interface IToDoRepository
{
    void Add(ToDoItem item);
    void Delete(ToDoItem item);
    ToDoItem Get(Guid id);
    void Complete(Guid id);
    void Reset(Guid id);
    IEnumerable<ToDoItem> GetAllToDoItems();
    IEnumerable<ToDoItem> GetCompletedToDoItems();
    IEnumerable<ToDoItem> GetIncompleteToDoItems();
}

public class ToDoRepository : IToDoRepository
{
    private List<ToDoItem> toDoItems { get; set; }
    public ToDoRepository()
    {
        toDoItems = new List<ToDoItem>();
    }

    /// <summary>
    /// This function will take a new ToDoItem and add it to the todoItems collection
    /// </summary>
    /// <param name="item"></param>
    public void Add(ToDoItem item)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// This function will lookup an existing ToDoItem and mark it as completed
    /// </summary>
    /// <param name="id"></param>
    public void Complete(Guid id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// This function will lookup an existing ToDoItem and revert it to the default incomplete state
    /// </summary>
    /// <param name="id"></param>
    public void Reset(Guid id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// This function will lookup an existing ToDoItem and remove it from the todoItems collection
    /// </summary>
    /// <param name="item"></param>
    public void Delete(ToDoItem item)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// This function will return all ToDoItems in the todoItems collection
    /// </summary>
    /// <param name="id"></param>
    public ToDoItem Get(Guid id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// This function will return all ToDoItems in the todoItems collection
    /// </summary>
    public IEnumerable<ToDoItem> GetAllToDoItems()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// This function will return all Completed ToDoItems in the todoItems collection
    /// </summary>
    public IEnumerable<ToDoItem> GetCompletedToDoItems()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// This function will return all Incomplete ToDoItems in the todoItems collection
    /// </summary>
    public IEnumerable<ToDoItem> GetIncompleteToDoItems()
    {
        throw new NotImplementedException();
    }
}