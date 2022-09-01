using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos.Queries;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.ViewModels.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProgrammingLanguagesController : BaseController
{

    [HttpPost("post")]
    public async Task<IActionResult> Post ( [FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand)
    {
        CreatedProgrammingLanguageDto result = await Mediator.Send(createProgrammingLanguageCommand);

        return Created("", result);
    }

    [HttpDelete("delete/{Id}")]
    public async Task<IActionResult> DeleteById ([FromRoute] DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand)
    {
        DeletedProgrammingLanguageDto result = await Mediator.Send(deleteProgrammingLanguageCommand);

        return Ok(result);
    }
    
    [HttpPut("put")]
    public async Task<IActionResult> Put ([FromBody] UpdateProgrammingLanguageCommand updateProgrammingLanguageCommand)
    {
        UpdatedProgrammingLanguageDto result = await Mediator.Send(updateProgrammingLanguageCommand);

        return Ok(result);
    }
    
    [HttpGet("getlist")]
    public async Task<IActionResult> GetList ( [FromQuery] GetListProgrammingLanguageQuery getListProgrammingLanguageQuery)
    {
        GetListProgrammingLanguageViewModel result = await Mediator.Send(getListProgrammingLanguageQuery);
        
        return Ok(result);
    }

    [HttpGet("getbyid/{Id}")]
    public async Task<IActionResult> GetById ( [FromRoute] GetByIdProgrammingLanguageQuery getByIdProgrammingLanguageQuery)
    {
        GetByIdProgrammingLanguageDto result = await Mediator.Send(getByIdProgrammingLanguageQuery);
        
        return Ok(result);
    }
}