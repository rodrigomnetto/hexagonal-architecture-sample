using App.Logic.Ports.Driven;
using App.Logic.Ports.Driving.Commands;
using Database.Adapters.Querys;
using Database.Adapters.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICancelEnrollmentCommandHandler, CancelEnrollmentCommandHandler>();
builder.Services.AddScoped<IRegisterStudentCommandHandler, RegisterStudentCommandHandler>();
builder.Services.AddScoped<IRegisterStudentCommandHandler, RegisterStudentCommandHandler>();
builder.Services.AddScoped<IGetAllStudentsQueryHandler, GetAllStudentQueryHandler>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
