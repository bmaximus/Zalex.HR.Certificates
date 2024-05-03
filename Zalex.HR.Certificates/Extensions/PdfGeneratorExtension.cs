using QuestPDF.Fluent;

namespace Zalex.HR.Certificates.Api.Extensions
{
    public static class PdfGeneratorExtension
    {
        public static byte[] GenerateSimplePdf(Dal.Entities.CertificateRequest certificateRequest)
        {
            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(QuestPDF.Helpers.PageSizes.A4);

                    page.Content()
                    .PaddingVertical(1, QuestPDF.Infrastructure.Unit.Centimetre)
                    .Column(x =>
                    {
                        x.Item().Text($"Employee Id: {certificateRequest.EmployeeId}");
                        x.Item().Text($"Address To: {certificateRequest.AddressTo}");
                        x.Item().Text($"Purpose: {certificateRequest.Purpose}");
                        x.Item().Text($"Issued On: {certificateRequest.IssuedOn.ToString(Constants.Constants.DateTimeFormat)}");
                    });

                });
            }).GeneratePdf();
        }
    }
}
