using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using diploma.Models.Core;

namespace diploma.Models.Accounts
{
    public class User
    {
        public virtual int ID { get; set; }
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }
        public virtual UserRole Role { get; set; }
       // public virtual Client Client { get; set; }
    }
}

public class UserMap : ClassMap<diploma.Models.Accounts.User>
{
    public UserMap()
    {
        Id(x => x.ID);
        Map(x => x.Login);
        Map(x => x.Password);
        References(x => x.Role).Cascade.All();
       // HasOne(x => x.Client).Cascade.All().Constrained();
    }
}