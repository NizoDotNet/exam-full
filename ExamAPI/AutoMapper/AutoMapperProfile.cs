using AutoMapper;
using ExamAPI.Models;
using ExamAPI.Models.DTOs.Answer;
using ExamAPI.Models.DTOs.Quastion;
using ExamAPI.Models.DTOs.Subject;

namespace ExamAPI.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<AddSubject, Subject>().ReverseMap();
        CreateMap<UpdateSubject, Subject>().ReverseMap();
        CreateMap<AddQuastion, Quastion>().ReverseMap(); 
        CreateMap<UpdateQuastion, Quastion>().ReverseMap();
        CreateMap<AddAnswer, Answer>().ReverseMap();
        CreateMap<UpdateAnswer, Answer>().ReverseMap();
        CreateMap<Answer, AddAnswerFull>().ReverseMap();
        CreateMap<Quastion, AddQuastionFull>().ReverseMap();
        CreateMap<Subject, AddSubjectFull>().ReverseMap();
        
        CreateMap<Quastion, QuastionDto>().ReverseMap();
        CreateMap<Subject, SubjectDto>().ReverseMap();
        CreateMap<Answer, AnswerDto>().ReverseMap();

    }
}
