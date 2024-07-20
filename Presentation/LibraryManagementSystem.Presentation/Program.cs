using LibraryManagementSystem.Application;
using LibraryManagementSystem.Application.Books.Commands.CreateBook;
using LibraryManagementSystem.Application.IBaseRepository;
using LibraryManagementSystem.Infrastructure;
using LibraryManagementSystem.Infrastructure.Repositories;
using LibraryManagementSystem.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IApplicationUnitOfWork, ApplicationUnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateBookCommand).Assembly));





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
