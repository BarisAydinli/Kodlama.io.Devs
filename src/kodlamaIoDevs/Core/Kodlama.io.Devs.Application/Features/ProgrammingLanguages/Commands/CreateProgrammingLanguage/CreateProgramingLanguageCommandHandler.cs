using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;

public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand,CreatedProgrammingLanguageDto>
{
    private readonly IMapper _mapper;
    private readonly IProgrammingLanguageRepository _ProgrammingLanguageRepository;
    private readonly ProgrammingLanguageBusinessRules _ProgrammingLanguageBusinessRules;

    public CreateProgrammingLanguageCommandHandler(
        IMapper mapper,
        IProgrammingLanguageRepository ProgrammingLanguageRepository,
        ProgrammingLanguageBusinessRules ProgrammingLanguageBusinessRules)
    {
        _mapper = mapper;
        _ProgrammingLanguageRepository = ProgrammingLanguageRepository;
        _ProgrammingLanguageBusinessRules = ProgrammingLanguageBusinessRules;
    }

    public async Task<CreatedProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
    {
        await _ProgrammingLanguageBusinessRules.CheckIfProgrammingLanguageNameExists(request.Name);

        ProgrammingLanguage mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
        ProgrammingLanguage createdProgrammingLanguage = await _ProgrammingLanguageRepository.AddAsync(mappedProgrammingLanguage);

        CreatedProgrammingLanguageDto result = _mapper.Map<CreatedProgrammingLanguageDto>(createdProgrammingLanguage);

        return result;
    }
}