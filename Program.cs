using Microsoft.EntityFrameworkCore;
using library.Entity;
using Microsoft.OpenApi.Models;
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

builder.Services.AddScoped<IBookAuthorRepository, BookAuthorRepository>();
builder.Services.AddScoped<IBookAuthorService, BookAuthorService>();

builder.Services.AddScoped<IBookCopyRepository, BookCopyRepository>();
builder.Services.AddScoped<IBookCopyService, BookCopyService>();

builder.Services.AddScoped<IHistoryRepository, HistoryRepository>();
builder.Services.AddScoped<IHistoryService, HistoryService>();

// Регистрация контекста БД
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Library"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()
    )
);


// Добавление сервисов
builder.Services.AddControllers();

// Регистрация swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Library API",
        Version = "v1",
        Description = "API для управления библиотекой"
    });
});

var app = builder.Build();

// Включение Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Library API V1");
    });
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();


//EntityFrameworkCore\Add-Migration MigrationName