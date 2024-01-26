
namespace Exceptions
{
    public class ExceptionCustom : Exception
    {
        public ExceptionCustom(string message) : base(message) {}
        public ExceptionCustom(string message, Exception innerException) : base(message, innerException) {}

    }
}
