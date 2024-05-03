using System.ComponentModel.DataAnnotations;

namespace Zalex.HR.Certificates.Api.Models
{

    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dt = (DateTime)value;
            return dt.Date > DateTime.Now.Date;
        }
    }
}