using DatabaseBootstrap.IRepositories;
using DatabaseBootstrap.Repositories;
using DesktopForms.Presenters;
using DesktopForms.Views;
using DesktopForms.ViewInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseBootstrap;
using Nest.Model.Domain;

namespace DesktopForms.Presenters
{
    public class GlavniPresenter
    {
        IGlavniView _view;
        public GlavniPresenter(IGlavniView view)
        {
            _view = view;
            _view.Presenter = this;
        }
        public void OtvoriLijekovi()
        {
            LijekoviForm view = new LijekoviForm();
            var presenter = new LijekoviPresenter(view, new UnitOfWork(), null);
            view.Show();
        }
        public void OtvoriBolesti()
        {
            BolestForm view = new BolestForm();
            var presenter = new BolestiPresenter(view, new UnitOfWork(), null);
            view.Show();
        }
        public void OtvoriNoviPostupak()
        {
            PostupakForm form = new PostupakForm();
            var presenter = new PostupakPresenter(form, new UnitOfWork());
            form.Show();
        }
        public void OtvoriRegistracijuVlasnika()
        {
            VlasnikForm view = new VlasnikForm();
            var presenter = new VlasnikPresenter(view, new UnitOfWork());
            view.Show();
        }
        public void OtvoriRegistracijuZivotinje()
        {
            ZivotinjaForm view = new ZivotinjaForm();
            var presenter = new ZivotinjaPresenter(view, new UnitOfWork());
            view.Show();
        }
        public void OtvoriNoviRacun()
        {
            RacunForm view = new RacunForm();
            var presenter = new RacunPresenter(view, new UnitOfWork());
            view.Show();
        }

        internal void OtvoriAdministraciju()
        {
            AdministracijaForm view = new AdministracijaForm();
            var presenter = new AdministracijaPresenter(view, new UnitOfWork());
            view.Show();
        }

        public void OtvoriPreuzimanjeRacuna()
        {
            PreuzimanjeRacunaForm view = new PreuzimanjeRacunaForm();
            var presenter = new PreuzimanjeRacunaPresenter(view, new UnitOfWork());
            view.Show();
        }
        public void OtvoriIzvjestaje()
        {
            PovijestPregledaForm view = new PovijestPregledaForm();
            var presenter = new IzvjestajiPresenter(view, new UnitOfWork());
            view.Show();
        }

        internal void OtvoriDostupneLijekove()
        {
            DostupniLijekoviForm view = new DostupniLijekoviForm();
            var presenter = new DostupniLijekoviPresenter(view, new UnitOfWork());
            view.Show();
        }
    }
}
