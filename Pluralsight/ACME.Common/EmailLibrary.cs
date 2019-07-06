using System;

namespace ACME.Common
{
    public class EmailLibrary
    {
        public void SendEmail(string emailAddress, string emailMessage)
        {
            // If a valid email address is provided,
            try
            {
                // Send an email.
            }
            catch (InvalidOperationException ex)
            {
                // log
                throw ex;
            }
        }
    }
}
