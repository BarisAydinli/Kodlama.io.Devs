using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities;

public class ProgrammingLanguage : BaseEntity
{
    public string Name { get; set; }
}