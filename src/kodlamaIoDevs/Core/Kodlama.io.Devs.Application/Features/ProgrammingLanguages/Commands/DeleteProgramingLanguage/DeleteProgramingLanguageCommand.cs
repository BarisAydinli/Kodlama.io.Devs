using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos.Commands;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;

public class DeleteProgrammingLanguageCommand : IRequest<DeletedProgrammingLanguageDto>
{
    public int Id { get; set; }
}