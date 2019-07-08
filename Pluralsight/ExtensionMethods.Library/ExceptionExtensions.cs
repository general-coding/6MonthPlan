using System.Text;

namespace System
{
    public static class ExceptionExtensions
    {
        public static string FullMessage(this Exception exception)
        {
            StringBuilder stringBuilder = new StringBuilder();
            while (exception != null)
            {
                stringBuilder.AppendFormat("{0}{1}", exception.Message, Environment.NewLine);
                exception = exception.InnerException;
            }

            return stringBuilder.ToString();
        }
    }
}
