using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace diploma.Models.Core
{
    public class Person  //legal entity
    {
        public virtual int BIN { get; set; }
        public virtual Address LegalAddress { get; set; }
        public virtual string Name { get; set; }
        public virtual string PSRN { get; set; } //инн
        public virtual string CRR { get; set; } //кпп
        public virtual DateTime RegistrationDate { get; set; }

        public virtual ISet<Client> Clients { get; set; }
        public Person()
        {
            Clients = new HashSet<Client>();
        }
    }
}
public class PersonMap : ClassMap<diploma.Models.Core.Person>
{
    public PersonMap()
    {
        Id(x => x.BIN);
        References(x => x.LegalAddress).Cascade.All();
        Map(x => x.Name);
        Map(x => x.PSRN);
        Map(x => x.CRR);
        Map(x => x.RegistrationDate);
        HasMany(x => x.Clients).Inverse();
    }
}
