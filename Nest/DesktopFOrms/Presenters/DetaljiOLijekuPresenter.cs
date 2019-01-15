using DatabaseBootstrap.IRepositories;
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
        private readonly ILijekoviRepository _repository;

        public DetaljiOLijekuPresenter(IDetaljiOLijekuView view, ILijekoviRepository repository)
        {
            _view = view;
            _view.Presenter = this;
            _repository = repository;
            UpdateLijek(_view.Lijek);
        }
        
        public void UpdateLijek(Lijek lijek)
        {
            var novi = _repository.DohvatiPrekoID(lijek.Id);
            _view.Bolesti = novi.Bolests.ToList();
            _view.Interakcije = novi.InterakcijaLijekovas1.ToList();
        }

    }
}
