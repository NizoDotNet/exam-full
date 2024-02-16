using AutoMapper;
using ExamAPI.Models;
using ExamAPI.Models.DTOs.Quastion;
using ExamAPI.Models.DTOs.Subject;
using ExamAPI.Repisotory;
using ExamAPI.Repisotory.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ExamAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubjectController : ControllerBase
{
    private IRepository<Subject> _subjectRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<Subject> _subjectValidator;

    public SubjectController(IRepository<Subject> subjectRepository,
        IMapper mapper,
        IValidator<Subject> subjectValidator)
    {
        _subjectRepository = subjectRepository;
        _mapper = mapper;
        _subjectValidator = subjectValidator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _subjectRepository.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var subject = await _subjectRepository.GetAsync(id);

        if (subject is null) return NotFound();

        var subjectDto = _mapper.Map<SubjectDto>(subject);

        return Ok(subjectDto);
    }

    [HttpGet("getwithcorrectanswers/{id:guid}")]
    public async Task<IActionResult> GetWithCorrectAnswers([FromRoute] Guid id)
    {
        var subject = await _subjectRepository.GetAsync(id);

        if (subject is null) return NotFound();

        var subjectDto = _mapper.Map<UpdateSubject>(subject);

        return Ok(subjectDto);
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddSubject subjectDto)
    {
        Subject subject = _mapper.Map<Subject>(subjectDto);
        var validationResult = _subjectValidator.Validate(subject);

        if (!validationResult.IsValid) return ValidationProblem(validationResult.ToString());
        
        await _subjectRepository.AddAsync(subject);
        return Created();
    }

    [HttpPost("fullsubject")]
    public async Task<IActionResult> CreateFull([FromBody] AddSubjectFull subjectDto)
    {

        var subject = _mapper.Map<Subject>(subjectDto);
        var validationResult = _subjectValidator.Validate(subject);
        if (validationResult.IsValid)
        {

            await _subjectRepository.AddAsync(subject);
            return Created();
        }
        return ValidationProblem(validationResult.ToString());
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var subject = await _subjectRepository.GetAsync(id);

        if (subject is null) return NotFound();

        await _subjectRepository.Delete(subject);

        return Accepted("Subject was deleted");
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateSubject subjectDto)
    {
        var upSubject = _mapper.Map<Subject>(subjectDto);
        var validationResult = _subjectValidator.Validate(upSubject);

        if (!validationResult.IsValid) return ValidationProblem(validationResult.ToString());

        var subject = await _subjectRepository.UpdateAsync(id, upSubject);

        return Ok(subject);
    }

    [HttpGet("Mix/{id:guid}")]
    public async Task<IActionResult> MixQuastions([FromRoute] Guid id, [FromQuery] int? quastionsCount)
    {
        var subject = await _subjectRepository.GetAsync(id);
        if (!subject.Quastions.Any()) return NotFound();

        var quastionsDto = _mapper.Map<List<QuastionDto>>(subject.Quastions);

        MixQuastion mixer = new();
        var mixedQuastions = mixer.MixQuastions(quastionsDto);
        if (quastionsCount != null && quastionsCount < mixedQuastions.Count)
        {
            mixedQuastions = mixedQuastions.GetRange(0, (int)quastionsCount);

        }
        var subjectDto = new SubjectDto { Id = id, Name = subject.Name, Quastions = mixedQuastions };
        return Ok(subjectDto);
    }
}
