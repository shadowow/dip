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
        public virtual double Amount { get; set; }
        public virtual int Period { get; set; } // в днях

        public virtual ISet<FinishedTariff> FinishedTariffs { get; set; }

        public Tariff()
        {
            FinishedTariffs = new HashSet<FinishedTariff>();
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
        Map(x => x.Amount);
        Map(x => x.Period);
            
        HasMany(x => x.FinishedTariffs).Inverse();
    }
}
