using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace diploma.Models.Core
{
    public class Street
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }

        public virtual ISet<PostOffice> PostOffices { get; set; }
        public virtual ISet<Address> Addresses { get; set; }

        public Street()
        {
            PostOffices = new HashSet<PostOffice>();
            Addresses = new HashSet<Address>();
        }
    }
}
    public class StreetMap : ClassMap<diploma.Models.Core.Street>
    {
        public StreetMap()
        {
            Id(x => x.ID).GeneratedBy.Increment(); ;
            Map(x => x.Name);
            HasMany(x => x.PostOffices).Inverse();
            HasMany(x => x.Addresses).Inverse();
        }
    }
