﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace diploma.Models.Core
{
    public class PhysPerson
    {
        public virtual int ID { get; set; }
        public virtual string Surname { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string Patronimyc { get; set; }
        public virtual string PassportNumber { get; set; }
        public virtual int SerialNumber { get; set; }
        public virtual string PlaceOfIssue { get; set; }
        public virtual DateTime DateOfIssue { get; set; }
        public virtual Address CurrentAddress { get; set; }
        public PhysPerson()
        {
           // Client = new Client();
        }
    }
}
public class PhysPersonMap : ClassMap<diploma.Models.Core.PhysPerson>
{
    public PhysPersonMap()
    {
        Id(x => x.ID).GeneratedBy.Increment();
        Map(x => x.Surname);
        Map(x => x.FirstName);
        Map(x => x.Patronimyc);
        Map(x => x.PassportNumber);
        Map(x => x.SerialNumber);
        Map(x => x.PlaceOfIssue);
        Map(x => x.DateOfIssue);
        References(x => x.CurrentAddress).Cascade.All();
    }
}
