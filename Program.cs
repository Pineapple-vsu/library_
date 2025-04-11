using Microsoft.EntityFrameworkCore;
using library.Entity;
using library.Infrastructure.Data;
using library.Interfaces.Repositories;
using library.Interfaces.Services;
using library.Repositories;
using library.Services;

var builder = WebApplication.CreateBuilder(args);


// ����������� ������������ � ��������
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddScoped<IBookStatusRepository, BookStatusRepository>();
builder.Services.AddScoped<IBookStatusService, BookStatusService>();

// ����������� ��������� ��
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Library"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()
    )
);


// ���������� ��������
builder.Services.AddControllers();



var app = builder.Build();

try
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.OpenConnection();
    Console.WriteLine("����������� � �� �������!");
}
catch (Exception ex)
{
    Console.WriteLine($"������: {ex.Message}");
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();