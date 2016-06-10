using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace diploma.Models.Core
{
    public class Debt
    {
        public virtual int ID { get; set; }
        public virtual Client Client { get; set; }
        public virtual float Amount { get; set; }

        public virtual ISet<Payment> PaymentsStory { get; set; }

        public Debt()
        {
            PaymentsStory = new HashSet<Payment>();
        }
    }
}

    public class Debtmap : ClassMap<diploma.Models.Core.Debt>
    {
        public Debtmap()
        {
            Id(x => x.ID).GeneratedBy.Increment(); ;
            References(x => x.Client).Cascade.All();
            Map(x => x.Amount);
            
            HasMany(x => x.PaymentsStory).Inverse();
        }
    }
