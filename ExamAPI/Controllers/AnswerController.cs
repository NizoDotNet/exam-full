using AutoMapper;
using ExamAPI.Models;
using ExamAPI.Models.DTOs.Answer;
using ExamAPI.Repisotory;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ExamAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnswerController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IAnswerRepository _answerRepository;
    private readonly IValidator<Answer> _answerValidator;

    public AnswerController(IMapper mapper,
        IAnswerRepository answerRepository,
        IValidator<Answer> answerValidator
        )
    {
        _mapper = mapper;
        _answerRepository = answerRepository;
        _answerValidator = answerValidator;
    }

    [HttpPost("check")]
    public async Task<IActionResult> Check([FromBody] CheckAnswers strIds)
    {
        var ids = strIds.PickedAnswers.Select(Guid.Parse).ToList();
        var answer = (await _answerRepository.Check(ids)).ToList();
        if (answer.Count == 0) return NotFound();
        return Ok(answer);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var answers = await _answerRepository.GetAllAsync();
        var answersDto = _mapper.Map<List<AnswerDto>>(answers);
        return Ok(answersDto);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var answer = await _answerRepository.GetAsync(id);
        if (answer == null)
        {
            return NotFound();
        }
        var answerDto = _mapper.Map<AnswerDto>(answer);
        return Ok(answerDto);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var answer = await _answerRepository.GetAsync(id);
        if (answer == null) return NotFound();

        await _answerRepository.Delete(answer);

        return Accepted();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddAnswer answerDto)
    {
        var answer = _mapper.Map<Answer>(answerDto);

        var valiadtionResult = _answerValidator.Validate(answer);
        if(!valiadtionResult.IsValid)
        {
            return ValidationProblem(valiadtionResult.ToString());
        }
        await _answerRepository.AddAsync(answer);
        return Created();
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateAnswer answerDto)
    {
        var answer = _mapper.Map<Answer>(answerDto);

        var validationResult = _answerValidator.Validate(answer);
        if (!validationResult.IsValid)
        {
            return ValidationProblem(validationResult.ToString());
        }
        await _answerRepository.UpdateAsync(id, answer);

        return Ok();
    }
}
