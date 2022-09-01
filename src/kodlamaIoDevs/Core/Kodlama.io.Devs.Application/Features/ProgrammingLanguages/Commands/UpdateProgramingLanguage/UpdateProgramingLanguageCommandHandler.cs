using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;

public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand,UpdatedProgrammingLanguageDto>
{
    private readonly IMapper _mapper;
    private readonly IProgrammingLanguageRepository _ProgrammingLanguageRepository;
    private readonly ProgrammingLanguageBusinessRules _ProgrammingLanguageBusinessRules;

    public UpdateProgrammingLanguageCommandHandler(
        IMapper mapper,
        IProgrammingLanguageRepository ProgrammingLanguageRepository,
        ProgrammingLanguageBusinessRules ProgrammingLanguageBusinessRules)
    {
        _mapper = mapper;
        _ProgrammingLanguageRepository = ProgrammingLanguageRepository;
        _ProgrammingLanguageBusinessRules = ProgrammingLanguageBusinessRules;
    }

    public async Task<UpdatedProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
    {
        await _ProgrammingLanguageBusinessRules.CheckIfProgrammingLanguageNameExists(request.Name);

        ProgrammingLanguage mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
        ProgrammingLanguage updatedProgrammingLanguage = await _ProgrammingLanguageRepository.UpdateAsync(mappedProgrammingLanguage);

        UpdatedProgrammingLanguageDto result = _mapper.Map<UpdatedProgrammingLanguageDto>(updatedProgrammingLanguage);

        return result;
    }
}