using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace diploma.Models.Core
{
    public class PaymentMethod
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        public virtual ISet<Payment> Payments { get; set; }

        public PaymentMethod()
        {
            Payments = new HashSet<Payment>();
        }
    }
}
    public class PaymentMethodMap : ClassMap<diploma.Models.Core.PaymentMethod>
    {
        public PaymentMethodMap()
        {
            Id(x => x.ID).GeneratedBy.Increment(); ;
            Map(x => x.Name);
            Map(x => x.Description);
            
            HasMany(x => x.Payments).Inverse();
        }
    }
