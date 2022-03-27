
using FluentValidation.Results;

namespace Internal.Audit.Application.Exceptions;

public class ValidationException: ApplicationException
{
    public IDictionary<string, string[]> Errors { get; }
    public ValidationException()
            : base("One or more validation failures have occurred.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public ValidationException(IEnumerable<ValidationFailure> failures)
        : base(FormatExceptions(failures))
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }

    private static string FormatExceptions(IEnumerable<ValidationFailure> failures)
    {
        var exceptios = failures.Select(e => $"{e.PropertyName}: {e.ErrorMessage}");

        return string.Join(Environment.NewLine, exceptios);
    }
    
}
