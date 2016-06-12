using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace diploma.Models.Core
{
    public class Payment
    {
        public virtual int ID { get; set; }
        public virtual string Method { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual double Amount { get; set; }
        public virtual Client Client { get; set; }

        public Payment()
        {
            
        }
    }
}
public class PaymentMap : ClassMap<diploma.Models.Core.Payment>
{
    public PaymentMap()
    {
        Id(x => x.ID).GeneratedBy.Increment();
        Map(x => x.Method);
        Map(x => x.Date);
        Map(x => x.Amount);
        References(x => x.Client).Cascade.All();
    }
}
