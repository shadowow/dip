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
        public virtual Debt Debt { get; set; }
        public virtual PaymentMethod Method { get; set; }
    }
}
    public class PaymentMap : ClassMap<diploma.Models.Core.Payment>
    {
        public PaymentMap()
        {
            Id(x => x.ID).GeneratedBy.Increment(); ;
            References(x => x.Debt).Cascade.All();
            References(x => x.Method).Cascade.All();
        }
    }
