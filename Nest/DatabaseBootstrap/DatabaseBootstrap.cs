﻿using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Nest.Model.Domain;
using NHibernate;
using System;

namespace DatabaseBootstrap
{
    public class DatabaseBootstrap
    {
        public static ISession OpenSession()
        {
            var nhConfig = Fluently.Configure()
            .Database(SQLiteConfiguration.Standard
            .ConnectionString("Data Source=e:\\Fakultet\\Objektno oblikovanje\\Veterinari.db;Version=3")
            .AdoNetBatchSize(100))
            .Mappings(mappings => mappings.FluentMappings
                .AddFromAssemblyOf<Bolest>()
                .AddFromAssemblyOf<InterakcijaLijekova>()
                .AddFromAssemblyOf<Lijek>()
                .AddFromAssemblyOf<LijekKodVeterinara>()
                .AddFromAssemblyOf<Postupak>()
                .AddFromAssemblyOf<Racun>()
                .AddFromAssemblyOf<Veterinar>()
                .AddFromAssemblyOf<Vlasnik>()
                .AddFromAssemblyOf<VrstaPostupka>()
                .AddFromAssemblyOf<VrstaZivotinje>()
                .AddFromAssemblyOf<Zivotinja>())
            .BuildConfiguration();
            var sessionFactory = nhConfig.BuildSessionFactory();
            ISession sess = sessionFactory.OpenSession();
            // var schemaExport = new SchemaExport(nhConfig);
            //schemaExport.Create(false, true);
            return sess;
        }
    }
}
