using AutoMapper;
using ExamAPI.Models;
using ExamAPI.Models.DTOs.Quastion;
using ExamAPI.Repisotory;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ExamAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuastionController : ControllerBase
{
    private readonly IQuastionRepository _quastionRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<Quastion> _quastionValidator;

    public QuastionController(IQuastionRepository quastionRepository,
        IMapper mapper,
        IValidator<Quastion> quastionValidator)
    {
        _quastionRepository = quastionRepository;
        _mapper = mapper;
        _quastionValidator = quastionValidator;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var quastions = (await _quastionRepository.GetAllAsync()).ToList();
        var quastionDto = _mapper.Map<List<QuastionDto>>(quastions);
        return Ok(quastionDto);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var quastion = await _quastionRepository.GetAsync(id);

        if (quastion is null) return NotFound();

        var quastionDto = _mapper.Map<QuastionDto>(quastion);

        return Ok(quastionDto);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var quastion = await _quastionRepository.GetAsync(id);

        if (quastion is null) return NotFound();

        await _quastionRepository.Delete(quastion);

        return Accepted("Quastion was deleted");
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddQuastion quastionDto)
    {
        var quastion = _mapper.Map<Quastion>(quastionDto);

        var validationResult = _quastionValidator.Validate(quastion);

        if (!validationResult.IsValid) return ValidationProblem(validationResult.ToString());

        await _quastionRepository.AddAsync(quastion);
        return Created();
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateQuastion quastionDto)
    {
        var upQuastion = _mapper.Map<Quastion>(quastionDto);

        var validationResult = _quastionValidator.Validate(upQuastion);
        if (!validationResult.IsValid) return ValidationProblem(validationResult.ToString());

        var quastion = await _quastionRepository.UpdateAsync(id, upQuastion);
        return Ok(quastion);
    }

}
