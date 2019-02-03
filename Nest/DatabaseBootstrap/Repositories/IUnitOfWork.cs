using DatabaseBootstrap.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBootstrap.Repositories
{
    public interface IUnitOfWork
    {
        
        ILijekoviRepository LijekoviRepository {get; }

        ILijekKodVeterinaraRepository VeterinarLijekRepository    {  get; }

         IBolestiRepository BolestiRepository { get; }
       

        IPostupakRepository PostupakRepository { get; }


        IRacunRepository RacunRepository { get; }

        IVeterinarRepository VeterinarRepository { get; }


        IVlasnikRepository VlasnikRepository { get; }


        IVrstaPostupkaRepository VrstaPostupkaRepository { get; }


        IVrstaRepository VrstaRepository { get; }
      

        IZivotinjaRepository ZivotinjaRepository { get; }

        void Dispose();
       
    }
}
