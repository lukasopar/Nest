using DatabaseBootstrap;
using DesktopFOrms.Presenters;
using DesktopFOrms.Views;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Nest.Model.Domain;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopFOrms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //NHibernateService.OpenSessionFactory();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var view = new LijekoviForm();

            var presenter = new LijekoviPresenter(view, null);
            Application.Run(view);
        }

        
    }
}
