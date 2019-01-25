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
            var presenter = new LijekoviPresenter(view, new LijekoviRepository());
            view.Show();
        }
        public void OtvoriBolesti()
        {
            BolestForm view = new BolestForm();
            var presenter = new BolestiPresenter(view, new BolestiRepository(), null);
            view.Show();
        }
        public void OtvoriNoviPostupak()
        {
            PostupakForm form = new PostupakForm();
            var presenter = new PostupakPresenter(form, new PostupakRepository(), new VeterinarRepository(), new LijekoviRepository());
            form.Show();
        }
        public void OtvoriRegistracijuVlasnika()
        {
            VlasnikForm view = new VlasnikForm();
            var presenter = new VlasnikPresenter(view, new VlasnikRepository());
            view.Show();
        }
        public void OtvoriRegistracijuZivotinje()
        {
            ZivotinjaForm view = new ZivotinjaForm();
            var presenter = new ZivotinjaPresenter(view, new ZivotinjaRepository(), new VrstaRepository() , new VlasnikRepository());
            view.Show();
        }
        public void OtvoriNoviRacun()
        {
            RacunForm view = new RacunForm();
            var presenter = new RacunPresenter(view, new RacunRepository(),new VeterinarRepository(), new PostupakRepository());
            view.Show();
        }

        internal void OtvoriAdministraciju()
        {
            AdministracijaForm view = new AdministracijaForm();
            var presenter = new AdministracijaPresenter(view, new VrstaPostupkaRepository(), new VrstaRepository());
            view.Show();
        }

        public void OtvoriPreuzimanjeRacuna()
        {
            PreuzimanjeRacunaForm view = new PreuzimanjeRacunaForm();
            var presenter = new PreuzimanjeRacunaPresenter(view, new RacunRepository());
            view.Show();
        }
        public void OtvoriIzvjestaje()
        {
            PovijestPregledaForm view = new PovijestPregledaForm();
            var presenter = new IzvjestajiPresenter(view, new PostupakRepository(), new VeterinarRepository());
            view.Show();
        }
    }
}
