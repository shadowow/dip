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
        public virtual Client Client { get; set; }
    }
}

public class BillMap : ClassMap<diploma.Models.Core.Bill>
{
    public BillMap()
    {
        Id(x => x.Number).GeneratedBy.Increment();
        References(x => x.Client).Cascade.All();
    }
}