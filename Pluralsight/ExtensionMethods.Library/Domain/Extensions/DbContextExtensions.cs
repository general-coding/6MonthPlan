using ExtensionMethods.Library.Domain.Spec;
using System;
using System.Data.Entity;
using System.Linq;

namespace ExtensionMethods.Library.Domain.Extensions
{
    public static class DbContextExtensions
    {
        public static void Save(this DbContext context)
        {
            foreach (var change in context.ChangeTracker.Entries().Where(
                x => x.State == EntityState.Added || x.State == EntityState.Modified))
            {
                var readOnly = change.Entity as IReadOnly;
                if (readOnly != null)
                {
                    throw new InvalidOperationException("Attempt to change read-only data");
                }
                var audited = change.Entity as IAudited;
                if (audited != null)
                {
                    if (change.State == EntityState.Added)
                    {
                        audited.Audit.Created = DateTime.Now;
                    }
                    audited.Audit.Updated = DateTime.Now;
                    audited.Audit.User = System.Security.Claims.ClaimsPrincipal.Current.Identity.Name;
                }
            }
            context.SaveChanges();
        }
    }
}
