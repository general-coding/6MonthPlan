namespace ExtensionMethods.Library.Domain.Model
{
    public interface IAudited
    {
        Audit GetAudit();
        void SetAudit(Audit value);
    }
}
