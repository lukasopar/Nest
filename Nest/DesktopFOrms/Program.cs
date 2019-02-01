using DatabaseBootstrap;
using DatabaseBootstrap.IRepositories;
using DatabaseBootstrap.Repositories;
using DesktopForms.Presenters;
using DesktopForms.Views;
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

namespace DesktopForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            NHibernateService.OpenSessionFactory();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            PrijavaForm form = new PrijavaForm();
            PrijavaPresenter presenter = new PrijavaPresenter(form, new VeterinarRepository(NHibernateService.OpenSession()));
            form.Show();

            Application.Run();
        }

        

    }
}
