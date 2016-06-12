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
        public virtual DateTime Date { get; set; }
        public virtual bool IsPaid { get; set; }

        public virtual ISet<Bill> Bills { get; set; }

        public Debt()
        {
            Bills = new HashSet<Bill>();
        }
    }
}

public class Debtmap : ClassMap<diploma.Models.Core.Debt>
{
    public Debtmap()
    {
        Id(x => x.ID).GeneratedBy.Increment(); 
        References(x => x.Client).Cascade.All();
        Map(x => x.Amount);
        Map(x => x.Date);
        Map(x => x.IsPaid);
        HasManyToMany(x => x.Bills).Cascade.All().Table("Debt_Bill");
    }
}
