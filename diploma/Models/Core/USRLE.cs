using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace diploma.Models.Core
{
    public class USRLE
    {
        public virtual int BIN { get; set; }
        public virtual string Name { get; set; }
        public virtual string PSRN { get; set; } //инн
        public virtual string CRR { get; set; } //кпп
        public virtual DateTime RegistrationDate { get; set; }

        private Client client = null;
        public virtual Client Client
        {
            get { return client; }
            set { client = value; }
        }
    }
}
    public class USRLEMap : ClassMap<diploma.Models.Core.USRLE>
    {
        public USRLEMap()
        {
            Id(x => x.BIN).GeneratedBy.Increment(); ;
            Map(x => x.Name);
            Map(x => x.PSRN);
            Map(x => x.CRR);
            Map(x => x.RegistrationDate);

            HasOne(x => x.Client);
        }
    }
