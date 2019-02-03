using DatabaseBootstrap;
using DatabaseBootstrap.IRepositories;
using Nest.Model.Domain;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseBootstrap.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly ISession _session = NHibernateService.OpenSession();
        private ILijekoviRepository _lijekoviRepository;
        private ILijekKodVeterinaraRepository _veterinarLijekRepository;
        private IBolestiRepository _bolestiRepository;
        private IPostupakRepository _postupakRepository;
        private IRacunRepository _racunRepository;
        private IVeterinarRepository _veterinarRepository;
        private IVlasnikRepository _vlasnikRepository;
        private IVrstaPostupkaRepository _vrstaPostupkaRepository;
        private IVrstaRepository _vrstaRepository;
        private IZivotinjaRepository _zivotinjaRepository;
        

        public ILijekoviRepository LijekoviRepository
        {
            get
            {
                if (this._lijekoviRepository == null)
                {
                    this._lijekoviRepository = new LijekoviRepository(_session);
                }
                return _lijekoviRepository;
            }
        }

        public ILijekKodVeterinaraRepository VeterinarLijekRepository
        {
            get
            {

                if (this._veterinarLijekRepository == null)
                {
                    this._veterinarLijekRepository = new LijekKodVeterinaraRepository(_session);
                }
                return _veterinarLijekRepository;
            }
        }

        public IBolestiRepository BolestiRepository
        {
            get
            {

                if (this._bolestiRepository == null)
                {
                    this._bolestiRepository = new BolestiRepository(_session);
                }
                return _bolestiRepository;
            }
        }

        public IPostupakRepository PostupakRepository
        {
            get
            {

                if (this._postupakRepository == null)
                {
                    this._postupakRepository = new PostupakRepository(_session);
                }
                return _postupakRepository;
            }
        }

        public IRacunRepository RacunRepository
        {
            get
            {

                if (this._racunRepository == null)
                {
                    this._racunRepository = new RacunRepository(_session);
                }
                return _racunRepository;
            }
        }

        public IVeterinarRepository VeterinarRepository
        {
            get
            {

                if (this._veterinarRepository == null)
                {
                    this._veterinarRepository = new VeterinarRepository(_session);
                }
                return _veterinarRepository;
            }
        }

        public IVlasnikRepository VlasnikRepository
        {
            get
            {

                if (this._vlasnikRepository == null)
                {
                    this._vlasnikRepository = new VlasnikRepository(_session);
                }
                return _vlasnikRepository;
            }
        }

        public IVrstaPostupkaRepository VrstaPostupkaRepository
        {
            get
            {

                if (this._vrstaPostupkaRepository == null)
                {
                    this._vrstaPostupkaRepository = new VrstaPostupkaRepository(_session);
                }
                return _vrstaPostupkaRepository;
            }
        }

        public IVrstaRepository VrstaRepository
        {
            get
            {

                if (this._vrstaRepository == null)
                {
                    this._vrstaRepository = new VrstaRepository(_session);
                }
                return _vrstaRepository;
            }
        }

        public IZivotinjaRepository ZivotinjaRepository
        {
            get
            {

                if (this._zivotinjaRepository == null)
                {
                    this._zivotinjaRepository = new ZivotinjaRepository(_session);
                }
                return _zivotinjaRepository;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _session.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
