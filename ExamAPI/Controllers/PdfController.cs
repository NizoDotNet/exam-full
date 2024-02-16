using ExamAPI.Models.DTOs.Subject;
using ExamAPI.Repisotory.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        private readonly PdfService _pdfService;

        public PdfController(PdfService pdfService)
        {
            _pdfService = pdfService;
        }
        [HttpPost("getpdf")]
        public IActionResult GetPdf([FromBody] UpdateSubject subject)
        {
            var bytes = _pdfService.GetPdf(subject);
            if (bytes == null)
            {
                return BadRequest("Something went wrong");
            }
            return File(bytes, "application/pdf", subject.Name);
        }
    }
}
