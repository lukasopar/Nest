using DatabaseBootstrap.IRepositories;
using DatabaseBootstrap.Repositories;
using DesktopForms.Presenters;
using DesktopForms.Views;
using DesktopForms.ViewInterfaces;
using DesktopForms.Views;
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
            var presenter = new ZivotinjaPresenter(view, new ZivotinjaRepository(), new VlasnikRepository());
            view.Show();
        }
        public void OtvoriNoviRacun()
        {
            RacunForm view = new RacunForm();
            var presenter = new RacunPresenter(view, new RacunRepository(),new VeterinarRepository(), new PostupakRepository());
            view.Show();
        }
    }
}
