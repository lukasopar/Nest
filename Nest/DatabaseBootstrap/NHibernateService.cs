using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Nest.DatabaseBootstrap.Mapping;
using Nest.Model.Domain;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.IO;

namespace DatabaseBootstrap
{
    public class NHibernateService
    {
        private static ISessionFactory _sessionFactory;
        public static Veterinar PrijavljeniVeterinar;

        public static ISession OpenSession()
        {
            try
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = OpenSessionFactory();
                }
                ISession session = _sessionFactory.OpenSession();
                return session;

            }
            catch (Exception e)
            {
                throw e.InnerException ?? e;
            }
        }
        public static ISessionFactory OpenSessionFactory()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

            var nhConfig = Fluently.Configure()
            .Database(SQLiteConfiguration.Standard
            .ConnectionString("Data Source=" + projectDirectory + "\\Veterinari.db;Version=3;BinaryGUID=False")
            .AdoNetBatchSize(100))
            .Mappings(mappings => mappings.FluentMappings
                .AddFromAssemblyOf<BolestMap>()
                .AddFromAssemblyOf<InterakcijaLijekovaMap>()
                .AddFromAssemblyOf<LijekMap>()
                .AddFromAssemblyOf<LijekKodVeterinaraMap>()
                .AddFromAssemblyOf<PostupakMap>()
                .AddFromAssemblyOf<RacunMap>()
                .AddFromAssemblyOf<VeterinarMap>()
                .AddFromAssemblyOf<VlasnikMap>()
                .AddFromAssemblyOf<VrstaPostupkaMap>()
                .AddFromAssemblyOf<VrstaZivotinjeMap>()
                .AddFromAssemblyOf<ZivotinjaMap>())
            .BuildConfiguration();
            var sessionFactory = nhConfig.BuildSessionFactory();
            ISession sess = sessionFactory.OpenSession();
            //var schemaExport = new SchemaExport(nhConfig);
            //schemaExport.Create(false, true);
            return sessionFactory;
        }
    }
}
