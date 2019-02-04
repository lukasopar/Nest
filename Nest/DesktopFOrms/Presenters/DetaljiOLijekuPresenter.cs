using DatabaseBootstrap.IRepositories;
using DatabaseBootstrap.Repositories;
using DesktopForms.ViewInterfaces;
using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopForms.Presenters
{
    public class DetaljiOLijekuPresenter
    {
        private readonly IDetaljiOLijekuView _view;
        private readonly IUnitOfWork _unit;

        public DetaljiOLijekuPresenter(IDetaljiOLijekuView view, IUnitOfWork unit)
        {
            _view = view;
            _view.Presenter = this;
            _unit = unit;
            UpdateLijek(_view.Lijek);
        }
        
        public void UpdateLijek(Lijek lijek)
        {
            var novi = _unit.LijekoviRepository.DohvatiLijekPoId(lijek.Id);
            _view.Bolesti = novi.Bolests.ToList();

            HashSet<InterakcijaLijekova> interakcije = new HashSet<InterakcijaLijekova>();

            foreach(InterakcijaLijekova interakcija in novi.InterakcijaLijekovas1.ToList())
            {
                interakcije.Add(interakcija);
            }

            foreach (InterakcijaLijekova interakcija in novi.InterakcijaLijekovas2.ToList())
            {
                interakcije.Add(interakcija);
            }

            _view.Lijek = lijek;
            _view.Interakcije = interakcije.ToList();
        }

        public void CloseUnitOfWork()
        {
            this._unit.Dispose();
        }

    }
}
