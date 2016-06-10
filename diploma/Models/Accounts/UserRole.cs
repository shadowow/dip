using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace diploma.Models.Accounts
{
    public class UserRole
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        //public virtual bool IsClient { get; set; }
        public virtual bool CanEditReference { get; set; }
        public virtual bool CanEditPersonal { get; set; }

        public virtual ISet<User> Users { get; set; }

        public UserRole()
        {
            Users = new HashSet<User>();
        }
    }
}
public class UserRoleMap : ClassMap<diploma.Models.Accounts.UserRole>
{
    public UserRoleMap()
    {
        Id(x => x.ID);
        Map(x => x.Name);
       // Map(x => x.IsClient);
        Map(x => x.CanEditPersonal);
        Map(x => x.CanEditReference);

        HasMany(x => x.Users).Inverse();
    }
}