using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace diploma.Models.Core
{
    public class Person  //legal entity
    {
        public virtual int ID { get; set; }
        public virtual USRLE USRLE { get; set; }
        public virtual Address LegalAddress { get; set; }
        public virtual Client Client { get; set; }

    }
}
    public class PersonMap : ClassMap<diploma.Models.Core.Person>
    {
        public PersonMap()
        {
            Id(x => x.ID).GeneratedBy.Increment();
            References(x => x.Client).Cascade.All();
            HasOne(x => x.USRLE).Cascade.All().Constrained();
            References(x => x.LegalAddress).Cascade.All();
        }
    }
