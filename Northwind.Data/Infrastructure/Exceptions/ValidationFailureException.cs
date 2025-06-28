using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Northwind.Data.Infrastructure.Exceptions
{
    [Serializable]
    public class ValidationFailureException : Exception
    {
        #region Data Members

        #endregion

        #region Properties

        private IEnumerable<ValidationResult> ValidationFailures { get; set; }

        public override string Message
        {
            get
            {
                return _message;
            }
        }

        private readonly string _message;

        #endregion

        #region Public Methods

        public ValidationFailureException(string message, params string[] memberNames)
        {
            ValidationFailures = new List<ValidationResult> { new ValidationResult(message, memberNames) };
            _message = SetMessage(ValidationFailures);
        }

        public ValidationFailureException(params ValidationResult[] failures)
        {
            ValidationFailures = failures;
            _message = SetMessage(failures);
        }

        public ValidationFailureException(Exception inner, params ValidationResult[] failures) : base("", inner)
        {
            ValidationFailures = failures;
            _message = SetMessage(failures);
        }

        protected ValidationFailureException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        #endregion

        #region Private Methods

        private static string SetMessage(IEnumerable<ValidationResult> failures)
        {
            return "One or more validation errors occurred: " + string.Join("; ", failures.Select(x => x.ErrorMessage));
        }

        #endregion

    }
}
