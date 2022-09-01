using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos.Queries;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.ViewModels.Queries;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        //Create Command
        CreateMap<CreateProgrammingLanguageCommand, ProgrammingLanguage>().ReverseMap();
        CreateMap<ProgrammingLanguage, CreatedProgrammingLanguageDto>().ReverseMap();
        
        //Delete Command
        CreateMap<DeleteProgrammingLanguageCommand, ProgrammingLanguage>().ReverseMap();
        CreateMap<ProgrammingLanguage, DeletedProgrammingLanguageDto>().ReverseMap();
        
        //Update Command
        CreateMap<UpdateProgrammingLanguageCommand, ProgrammingLanguage>().ReverseMap();
        CreateMap<ProgrammingLanguage, UpdatedProgrammingLanguageDto>().ReverseMap();
        
        //GetById Query
        CreateMap<ProgrammingLanguage, GetByIdProgrammingLanguageDto>().ReverseMap();
        
        //GetList Query
        CreateMap<IPaginate<ProgrammingLanguage>, GetListProgrammingLanguageViewModel>();
        CreateMap<ProgrammingLanguage, GetListProgrammingLanguageDto>().ReverseMap();
        CreateMap<ProgrammingLanguage, GetListProgrammingLanguageViewModel>().ReverseMap();

    }
}