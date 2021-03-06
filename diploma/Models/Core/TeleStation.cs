﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace diploma.Models.Core
{
    public class TeleStation
    {
        public virtual int ID { get; set; }
        public virtual Address Address { get; set; }

        public virtual ISet<Client> Clients { get; set; }

        public TeleStation()
        {
            Clients = new HashSet<Client>();
        }

        public override string ToString()
        {
            return ID + ";  Адрес: " + Address.ToString();
        }
    }
}

public class TeleStationMap : ClassMap<diploma.Models.Core.TeleStation>
{
    public TeleStationMap()
    {
        Id(x => x.ID).GeneratedBy.Increment();
        References(x => x.Address).Cascade.All().LazyLoad(Laziness.False);

        HasMany(x => x.Clients).Inverse();
    }
}
