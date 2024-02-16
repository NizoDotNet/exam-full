using ExamAPI.Models.DTOs.Subject;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

namespace ExamAPI.Repisotory.Services;

public class PdfService
{
    private readonly string wwwroot;

    public PdfService(IWebHostEnvironment hostEnvironment)
    {
        wwwroot = hostEnvironment.WebRootPath;
    }

    public byte[] GetPdf(UpdateSubject subject)
    {
        var subjectPdf = Path.Combine(wwwroot, "pdf", $"{subject.Id}.pdf");
        byte[] pdf;
        if(!File.Exists(subjectPdf))
        {
            PdfGenerator pdfGenerator = new(subject);
            pdfGenerator.GeneratePdf(subjectPdf);
        }
        pdf = File.ReadAllBytes(subjectPdf);
        return pdf;
    }
}

public class PdfGenerator : IDocument
{
    private readonly UpdateSubject subject;

    public PdfGenerator(UpdateSubject subject)
    {
        this.subject = subject;
    }
    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Size(PageSizes.A4);
            page.Margin(1, Unit.Centimetre);
            page.PageColor(Colors.White);
            page.DefaultTextStyle(x => x.FontSize(14));

            page.Content()
                .PaddingVertical(1, Unit.Centimetre)
                .Column(x =>
                {
                    x.Item().AlignCenter().Text(subject.Name);


                    for (int i = 0; i < subject.Quastions.Count; i++)
                    {
                        x.Item().PaddingTop(8).Text($"{i + 1}. {subject.Quastions[i].Text}");
                        char a = 'A';
                        for (int j = 0; j < subject.Quastions[i].Answers.Count; j++)
                        {
                            x.Item().PaddingTop(2).Text($"{a}) {subject.Quastions[i].Answers[j].Text}");
                            a++;
                        }

                    }

                });


        });
    }

}
