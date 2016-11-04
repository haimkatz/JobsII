using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace JobsII.Models
{
    public static class AuditExtension
    {
        public static void Save(this System.Data.Entity.DbContext context)
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
                    audited.Audit.User = WindowsPrincipal.Current.Identity.Name;
                }
            }
            context.SaveChanges();
        }
    }
}
