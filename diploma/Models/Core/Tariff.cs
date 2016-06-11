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
        public virtual int Limit { get; set; }
        public virtual int LimitPrice { get; set; }
        public virtual double OverPrice { get; set; }
    }
}
public class TariffMap : ClassMap<diploma.Models.Core.Tariff>
{
    public TariffMap()
    {
        Id(x => x.ID).GeneratedBy.Increment(); ;
        Map(x => x.Name);
        Map(x => x.Description);
        Map(x => x.Limit);
        Map(x => x.LimitPrice);
        Map(x => x.OverPrice);
    }
}
