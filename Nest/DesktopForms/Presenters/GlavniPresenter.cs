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
            var presenter = new LijekoviPresenter(view, new LijekoviRepository(NHibernateService.OpenSession()));
            view.Show();
        }
        public void OtvoriBolesti()
        {
            BolestForm view = new BolestForm();
            var presenter = new BolestiPresenter(view, new BolestiRepository(NHibernateService.OpenSession()), null);
            view.Show();
        }
        public void OtvoriNoviPostupak()
        {
            PostupakForm form = new PostupakForm();
            var presenter = new PostupakPresenter(form, new PostupakRepository(NHibernateService.OpenSession()), new VeterinarRepository(NHibernateService.OpenSession()), new LijekoviRepository(NHibernateService.OpenSession()));
            form.Show();
        }
        public void OtvoriRegistracijuVlasnika()
        {
            VlasnikForm view = new VlasnikForm();
            var presenter = new VlasnikPresenter(view, new VlasnikRepository(NHibernateService.OpenSession()));
            view.Show();
        }
        public void OtvoriRegistracijuZivotinje()
        {
            ZivotinjaForm view = new ZivotinjaForm();
            var presenter = new ZivotinjaPresenter(view, new ZivotinjaRepository(NHibernateService.OpenSession()), new VrstaRepository(NHibernateService.OpenSession()) , new VlasnikRepository(NHibernateService.OpenSession()));
            view.Show();
        }
        public void OtvoriNoviRacun()
        {
            RacunForm view = new RacunForm();
            var presenter = new RacunPresenter(view, new RacunRepository(NHibernateService.OpenSession()),new VeterinarRepository(NHibernateService.OpenSession()), new PostupakRepository(NHibernateService.OpenSession()));
            view.Show();
        }

        internal void OtvoriAdministraciju()
        {
            AdministracijaForm view = new AdministracijaForm();
            var presenter = new AdministracijaPresenter(view, new VrstaPostupkaRepository(NHibernateService.OpenSession()), new VrstaRepository(NHibernateService.OpenSession()));
            view.Show();
        }

        public void OtvoriPreuzimanjeRacuna()
        {
            PreuzimanjeRacunaForm view = new PreuzimanjeRacunaForm();
            var presenter = new PreuzimanjeRacunaPresenter(view, new RacunRepository(NHibernateService.OpenSession()));
            view.Show();
        }
        public void OtvoriIzvjestaje()
        {
            PovijestPregledaForm view = new PovijestPregledaForm();
            var presenter = new IzvjestajiPresenter(view, new PostupakRepository(NHibernateService.OpenSession()), new VeterinarRepository(NHibernateService.OpenSession()));
            view.Show();
        }
    }
}
