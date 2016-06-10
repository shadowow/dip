using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace diploma.Models.Core
{
    public class Address
    {
        public virtual int ID { get; set; }
        public virtual PostOffice PostOffice { get; set; }
        public virtual District District { get; set; }
        public virtual Street Street { get; set; }
        public virtual string Building { get; set; }
        public virtual string Extra { get; set; }

        public virtual ISet<Passport> Passports { get; set; }
        public virtual ISet<Person> Persons { get; set; }
        public virtual ISet<Client> Clients { get; set; }

        public Address()
        {
            Passports = new HashSet<Passport>();
            Persons = new HashSet<Person>();
            Clients = new HashSet<Client>();
        }
    }

}
    public class AddressMap : ClassMap<diploma.Models.Core.Address>
    {
        public AddressMap()
        {
            Id(x => x.ID).GeneratedBy.Increment(); ;
            References(x => x.PostOffice).Cascade.All();
            References(x => x.District).Cascade.All();
            References(x => x.Street).Cascade.All();
            Map(x => x.Building);
            Map(x => x.Extra);

            HasMany(x => x.Passports).Inverse();
            HasMany(x => x.Persons).Inverse();
            HasMany(x => x.Clients).Inverse();
        }
    }
