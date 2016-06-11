using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace diploma.Models.Core
{
    public class Tariff
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int Limitation { get; set; }
        public virtual int LimitPrice { get; set; }
        public virtual double OverPrice { get; set; }

        public virtual ISet<Client> Clients { get; set; }

        public Tariff()
        {
            Clients = new HashSet<Client>();
        }
    }
}
public class TariffMap : ClassMap<diploma.Models.Core.Tariff>
{
    public TariffMap()
    {
        Id(x => x.ID).GeneratedBy.Increment(); ;
        Map(x => x.Name);
        Map(x => x.Description);
        Map(x => x.Limitation);
        Map(x => x.LimitPrice);
        Map(x => x.OverPrice);

        HasMany(x => x.Clients).Inverse();
    }
}
