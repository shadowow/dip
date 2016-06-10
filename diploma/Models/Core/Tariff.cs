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
        public virtual string Names { get; set; }
        public virtual string Description { get; set; }
        public virtual int Discount { get; set; }

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
            Map(x => x.Names);
            Map(x => x.Description);
            Map(x => x.Discount);
            
            HasMany(x => x.FinishedTariffs).Inverse();
        }
    }
