using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;

public class ProgrammingLanguageBusinessRules
{
    private readonly IProgrammingLanguageRepository _ProgrammingLanguageRepository;

    public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository ProgrammingLanguageRepository)
    {
        _ProgrammingLanguageRepository = ProgrammingLanguageRepository;
    }

    public async Task CheckIfProgrammingLanguageNameExists(string name)
    {
        IPaginate<ProgrammingLanguage> result = await _ProgrammingLanguageRepository.GetListAsync(pl => pl.Name == name);
        if (result.Items.Any()) throw new BusinessException("Programing Language name exists.");
    }
}