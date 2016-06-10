using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;


namespace diploma.Models.Core
{
    public class Call
    {
        public virtual int ID { get; set; }
        public virtual Client Client { get; set; }
        public virtual DateTime Begin { get; set; }
        public virtual DateTime End { get; set; }
        public virtual string TalkedWith { get; set; }
    }

}
    public class CallMap : ClassMap<diploma.Models.Core.Call>
    {
        public CallMap()
        {
            Id(x => x.ID).GeneratedBy.Increment(); ;
            References(x => x.Client).Cascade.All();
            Map(x => x.Begin);
            Map(x => x.End);
            Map(x => x.TalkedWith);
        }
    }
