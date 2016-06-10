using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace diploma.Models.Core
{
    public class PhysPerson
    {
        public virtual int ID { get; set; }
        public virtual string Surname { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual Passport Passport { get; set; }
        public virtual Client Client { get; set; }

    }
}
    public class PhysPersonMap : ClassMap<diploma.Models.Core.PhysPerson>
    {
        public PhysPersonMap()
        {
            Id(x => x.ID).GeneratedBy.Increment();
            References(x => x.Client).Cascade.All();
            Map(x => x.Surname);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            HasOne(x => x.Passport).Cascade.All().Constrained();
        }
    }
