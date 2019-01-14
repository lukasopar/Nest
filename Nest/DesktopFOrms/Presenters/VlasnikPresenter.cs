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
    public class VlasnikPresenter
    {
        private readonly IVlasnikView _view;
        private readonly IVlasnikRepository _repository;


        public VlasnikPresenter(IVlasnikView view, IVlasnikRepository repository)
        {
            _view = view;
            view.Presenter = this;
            _repository = repository;
        }

        public void registrirajVlasnika(Vlasnik vlasnik)
        {
            _repository.Stvori(vlasnik);
        }

    }
}
