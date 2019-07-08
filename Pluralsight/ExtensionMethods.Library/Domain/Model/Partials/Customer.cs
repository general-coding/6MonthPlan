using System;

namespace ExtensionMethods.Library.Domain.Model
{
    public partial class Customer : IAudited
    {
        public Audit GetAudit()
        {
            throw new NotImplementedException();
        }

        public void SetAudit(Audit value)
        {
            throw new NotImplementedException();
        }
    }
}
