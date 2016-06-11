using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using diploma.Models.Accounts;

namespace diploma.Models.Core
{
    public class Client
    {
        public virtual int ID { get; set; }
        public virtual string Phone { get; set; }
        public virtual TeleStation Station { get; set; }
        public virtual Tariff CurrentTariff { get; set; }
        public virtual Address Address { get; set; }
        public virtual bool IsLegalEntity { get; set; }
        public virtual PhysPerson PhysPerson { get; set; }
        public virtual Person LegalEntity { get; set; }

        public virtual ISet<Debt> Debts { get; set; }
        public virtual ISet<Call> CallsStory { get; set; }
        public virtual ISet<Bill> Bills { get; set; }

     
       

        public Client()
        {
            Debts = new HashSet<Debt>();
            CallsStory = new HashSet<Call>();
            Bills = new HashSet<Bill>();
        }
    }
}

public class ClientMap : ClassMap<diploma.Models.Core.Client>
{
    public ClientMap()
    {
        Id(x => x.ID).GeneratedBy.Increment();
        Map(x => x.Phone);
        Map(x => x.IsLegalEntity);
        References(x => x.Address).Cascade.All();
        References(x => x.Station).Cascade.All();
        References(x => x.CurrentTariff).Cascade.All();
        References(x => x.PhysPerson).Cascade.All().LazyLoad(Laziness.False);
        References(x => x.LegalEntity).Cascade.All().LazyLoad(Laziness.False);

        HasMany(x => x.Bills).Inverse();
        HasMany(x => x.Debts).Inverse();
        HasMany(x => x.CallsStory).Inverse();
    }
}
