using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos.Queries;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

#nullable disable

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;

public class GetByIdProgrammingLanguageQueryHandler : IRequestHandler<GetByIdProgrammingLanguageQuery,GetByIdProgrammingLanguageDto>
{
    private readonly IMapper _mapper;
    private readonly IProgrammingLanguageRepository _ProgrammingLanguageRepository;

    public GetByIdProgrammingLanguageQueryHandler(
        IMapper mapper,
        IProgrammingLanguageRepository ProgrammingLanguageRepository)
    {
        _mapper = mapper;
        _ProgrammingLanguageRepository = ProgrammingLanguageRepository;
    }

    public async Task<GetByIdProgrammingLanguageDto> Handle(GetByIdProgrammingLanguageQuery request, CancellationToken cancellationToken)
    {
        ProgrammingLanguage ProgrammingLanguage = await _ProgrammingLanguageRepository.GetAsync(pl => pl.Id == request.Id);

        GetByIdProgrammingLanguageDto result = _mapper.Map<GetByIdProgrammingLanguageDto>(ProgrammingLanguage);

        return result;
    }
}