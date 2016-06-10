using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace diploma.Models.Core
{
    public class Passport
    {
        public virtual int ID { get; set; }
        public virtual string Number { get; set; }
        public virtual string SerialNumber { get; set; }
        public virtual Address ResidenceAddress { get; set; }
        public virtual Address PlaceOfIssue { get; set; }
        public virtual DateTime DateOfIssue { get; set; }

        private Client client = null;
        public virtual Client Client
        {
            get { return client; }
            set { client = value; }
        }

    }
}
    public class PassportMap : ClassMap<diploma.Models.Core.Passport>
    {
        public PassportMap()
        {
            Id(x => x.ID).GeneratedBy.Increment(); ;
            Map(x => x.Number);
            Map(x => x.SerialNumber);
            References(x => x.ResidenceAddress).Cascade.All();
            References(x => x.PlaceOfIssue).Cascade.All();
            Map(x => x.DateOfIssue);

            HasOne(x => x.Client);
        }
    }
