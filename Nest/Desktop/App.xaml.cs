using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected static NHibernate.Cfg.Configuration NHibernateConfiguration;
        protected static ISessionFactory SessionFactory;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

        }

        private static NHibernate.Cfg.Configuration ConfigureNHibernate()
        {
            var configuration = new NHibernate.Cfg.Configuration();
            //configuration.SessionFactoryName("BuildIt");

            configuration.DataBaseIntegration(db =>
            {
                db.Dialect<MsSql2008Dialect>();
                db.Driver<SqlClientDriver>();
                db.Timeout = 10;

                db.ConnectionString = ConfigurationManager.AppSettings.Get("ConnectionString");
                db.LogFormattedSql = true;
                db.LogSqlInConsole = true;
                db.AutoCommentSql = true;
            });
            return configuration;
        }
    }
}
