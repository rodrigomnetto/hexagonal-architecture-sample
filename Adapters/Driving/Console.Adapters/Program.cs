using App.Logic.Ports.Driven;
using App.Logic.Ports.Driving.Commands;
using Database.Adapters.Querys;
using Database.Adapters.Repositories;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();

serviceCollection.AddScoped<ICourseRepository, CourseRepository>();
serviceCollection.AddScoped<IStudentRepository, StudentRepository>();
serviceCollection.AddScoped<ICancelEnrollmentCommandHandler, CancelEnrollmentCommandHandler>();
serviceCollection.AddScoped<IRegisterStudentCommandHandler, RegisterStudentCommandHandler>();
serviceCollection.AddScoped<IRegisterStudentCommandHandler, RegisterStudentCommandHandler>();
serviceCollection.AddScoped<IGetAllStudentsQueryHandler, GetAllStudentQueryHandler>();

PrintInstructions();

while (true)
{

}

void PrintInstructions()
{
    Console.WriteLine("Commands: \n" +
        "register - Register student \n" +
        "enroll - Enroll Student \n" +
        "cancel - Cancel Enrollment \n");
}