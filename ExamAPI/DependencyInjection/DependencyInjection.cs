using ExamAPI.AutoMapper;
using ExamAPI.FluentValidation;
using ExamAPI.Models;
using ExamAPI.Repisotory;
using ExamAPI.Repisotory.Services;
using FluentValidation;

namespace ExamAPI.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Subject>, SubjectService>();
        services.AddScoped<IQuastionRepository, QuastionService>();
        services.AddScoped<IAnswerRepository, AnswerService>();
        services.AddScoped<IValidator<Subject>, SubjectValidator>();
        services.AddScoped<IValidator<Quastion>, QuastionValidator>();
        services.AddScoped<IValidator<Answer>, AnswerValidator>();
        services.AddScoped<PdfService>();
        services.AddAutoMapper(typeof(AutoMapperProfile));

        return services;
    }
}
