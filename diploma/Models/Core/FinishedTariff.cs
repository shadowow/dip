using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace diploma.Models.Core
{
    public class FinishedTariff
    {
        public virtual int ID { get; set; }
        public virtual Client Client { get; set; }
        public virtual Tariff Tariff { get; set; }
        public virtual DateTime Begin { get; set; }
        public virtual DateTime End { get; set; }
    }
}
    public class FinishedTariffMap : ClassMap<diploma.Models.Core.FinishedTariff>
    {
        public FinishedTariffMap()
        {
            Id(x => x.ID).GeneratedBy.Increment(); ;
            References(x => x.Client).Cascade.All();
            References(x => x.Tariff).Cascade.All();
            Map(x => x.Begin);
            Map(x => x.End);
        }
    }
