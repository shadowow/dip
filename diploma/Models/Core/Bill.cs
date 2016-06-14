using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace diploma.Models.Core
{
    public class Bill
    {
        public virtual int Number { get; set; }
        public virtual DateTime Date { get; set; }

        public virtual ISet<Debt> Debts { get; set; }

        public Bill()
        {
            Debts = new HashSet<Debt>();
        }
    }
}

public class BillMap : ClassMap<diploma.Models.Core.Bill>
{
    public BillMap()
    {
        Id(x => x.Number).GeneratedBy.Increment();
        Map(x => x.Date);
        HasManyToMany(x => x.Debts).Inverse().Table("Debt_Bill");
    }
}