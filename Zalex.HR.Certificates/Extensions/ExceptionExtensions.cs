using System.Text;

namespace Zalex.HR.Certificates.Api.Extensions
{
    public static class ExceptionExtensions
    {
        public static string GetInnerMessage(this Exception exception)
        {
            if (exception == null) return string.Empty;
            var sb = new StringBuilder(exception.Message);
            if (exception.InnerException != null)
                sb.AppendLine(exception.InnerException.GetInnerMessage());

            return sb.ToString();
        }
    }
}
