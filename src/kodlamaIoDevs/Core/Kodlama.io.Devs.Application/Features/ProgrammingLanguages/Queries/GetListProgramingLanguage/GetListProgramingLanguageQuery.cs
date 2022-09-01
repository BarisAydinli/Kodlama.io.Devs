using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.ViewModels.Queries;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;

public class GetListProgrammingLanguageQuery : IRequest<GetListProgrammingLanguageViewModel>
{
    public PageRequest PageRequest { get; set; }
}