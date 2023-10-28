using FluentValidation.Results;

namespace Agency.Utilities;
public class AgencyUtil
{
    public static IEnumerable<object> GetErrorObject(ValidationResult validationResult)
    {
        return validationResult.Errors.Select(e => new
        {
            PropertyName = e.PropertyName,
            ErrorMessage = e.ErrorMessage
        });
    }
}
