using FluentValidation.Results;

namespace Trading.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public IDictionary<string, string[]> Errors { get; }
        public ValidationException() : base("One or more validation failures have occured.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures.GroupBy(x => x.PropertyName, x => x.ErrorMessage)
               .ToDictionary(fg => fg.Key, fg => fg.ToArray());
        }
    }
}
