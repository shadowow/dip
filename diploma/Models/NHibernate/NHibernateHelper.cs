using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

public class NHibernateHelper
{
    public static ISession OpenSession()
    {
       // var connectionStr = "Server=127.0.0.1;Port=5432;Database=tele;User Id=postgres;Password=me123;";
        ISessionFactory sessionFactory = Fluently.Configure()
                        .Database(PostgreSQLConfiguration.Standard
                        .ConnectionString(c => c
                        .Host("localhost")
                        .Port(5432)
                        .Database("tele")
                        .Username("postgres")
                        .Password("me123"))
                        .Raw("hbm2ddl.keywords", "none"))
                        .Mappings(x => x.FluentMappings.AddFromAssemblyOf<AddressMap>())
                        .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
                        .BuildSessionFactory();
        return sessionFactory.OpenSession();
    }
    
}