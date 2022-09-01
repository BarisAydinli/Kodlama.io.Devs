using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;

public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand,DeletedProgrammingLanguageDto>
{
    private readonly IMapper _mapper;
    private readonly IProgrammingLanguageRepository _ProgrammingLanguageRepository;

    public DeleteProgrammingLanguageCommandHandler(
        IMapper mapper,
        IProgrammingLanguageRepository ProgrammingLanguageRepository)
    {
        _mapper = mapper;
        _ProgrammingLanguageRepository = ProgrammingLanguageRepository;
    }

    public async Task<DeletedProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
    {
        ProgrammingLanguage mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
        ProgrammingLanguage deletedProgrammingLanguage = await _ProgrammingLanguageRepository.DeleteAsync(mappedProgrammingLanguage);

        DeletedProgrammingLanguageDto result = _mapper.Map<DeletedProgrammingLanguageDto>(deletedProgrammingLanguage);

        return result;
    }
}