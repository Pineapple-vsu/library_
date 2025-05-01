using Microsoft.EntityFrameworkCore;
using library.Entity;
using library.Infrastructure.Data;
using library.Interfaces.Repositories;
using library.Interfaces.Services;
using library.Repositories;
using library.Services;

var builder = WebApplication.CreateBuilder(args);


// Регистрация репозиториев и сервисов
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddScoped<IBookStatusRepository, BookStatusRepository>();
builder.Services.AddScoped<IBookStatusService, BookStatusService>();

builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();
builder.Services.AddScoped<IPeopleService, PeopleService>();

// Регистрация контекста БД
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Library"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()
    )
);


// Добавление сервисов
builder.Services.AddControllers();



var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();