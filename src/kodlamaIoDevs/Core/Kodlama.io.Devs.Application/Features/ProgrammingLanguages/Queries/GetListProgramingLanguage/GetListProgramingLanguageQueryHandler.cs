using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.ViewModels.Queries;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;

public class GetListProgrammingLanguageQueryHandler : IRequestHandler<GetListProgrammingLanguageQuery,GetListProgrammingLanguageViewModel>
{
    private readonly IMapper _mapper;
    private readonly IProgrammingLanguageRepository _ProgrammingLanguageRepository;

    public GetListProgrammingLanguageQueryHandler(
        IMapper mapper,
        IProgrammingLanguageRepository ProgrammingLanguageRepository)
    {
        _mapper = mapper;
        _ProgrammingLanguageRepository = ProgrammingLanguageRepository;
    }

    public async Task<GetListProgrammingLanguageViewModel> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken)
    {
        IPaginate<ProgrammingLanguage> ProgrammingLanguages = await _ProgrammingLanguageRepository.GetListAsync(
            index: request.PageRequest.Page,
            size: request.PageRequest.PageSize
        );

        GetListProgrammingLanguageViewModel result = _mapper.Map<GetListProgrammingLanguageViewModel>(ProgrammingLanguages);

        return result;
    }
}