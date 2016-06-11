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
        public virtual string PostOffice { get; set; }
        public virtual string District { get; set; }
        public virtual string Street { get; set; }
        public virtual string Building { get; set; }
        public virtual string Extra { get; set; }

        public virtual ISet<PhysPerson> PhysPersons { get; set; }
        public virtual ISet<Person> Persons { get; set; }
        public virtual ISet<Client> Clients { get; set; }
        public virtual ISet<TeleStation> Stations { get; set; }

        public Address()
        {
            PhysPersons = new HashSet<PhysPerson>();
            Persons = new HashSet<Person>();
            Clients = new HashSet<Client>();
            Stations = new HashSet<TeleStation>();
        }
    }

}
public class AddressMap : ClassMap<diploma.Models.Core.Address>
{
    public AddressMap()
    {
        Id(x => x.ID).GeneratedBy.Increment();
        Map(x => x.PostOffice);
        Map(x => x.District);
        Map(x => x.Street);
        Map(x => x.Building);
        Map(x => x.Extra);

        HasMany(x => x.PhysPersons).Inverse();
        HasMany(x => x.Persons).Inverse();
        HasMany(x => x.Clients).Inverse();
        HasMany(x => x.Stations).Inverse();
    }
}
