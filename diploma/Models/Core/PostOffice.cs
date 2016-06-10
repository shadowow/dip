using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace diploma.Models.Core
{
    public class PostOffice
    {
        public virtual int Postcode { get; set; }
        public virtual District District { get; set; }
        public virtual Street Street { get; set; }
        public virtual string Building { get; set; }

        public virtual ISet<Address> Addresses { get; set; }

        public PostOffice()
        {
            Addresses = new HashSet<Address>();
        }
    }
}
    public class PostOfficeMap : ClassMap<diploma.Models.Core.PostOffice>
    {
        public PostOfficeMap()
        {
            Id(x => x.Postcode);
            References(x => x.District).Cascade.All();
            References(x => x.Street).Cascade.All();
            Map(x => x.Building);
            HasMany(x => x.Addresses).Inverse();
        }
    }
