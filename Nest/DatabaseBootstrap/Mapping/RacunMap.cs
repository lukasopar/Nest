
using FluentNHibernate.Mapping;
using Nest.Model.Domain;


namespace Nest.DatabaseBootstrap.Mapping
{


    public class RacunMap : ClassMap<Racun> {
        
        public RacunMap() {
			
			Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Datum).Not.Nullable();
            HasMany(x => x.LijekStavkaRacunas).Cascade.All();
            HasMany(x => x.Postupaks).Cascade.SaveUpdate();
        }
    }
}
