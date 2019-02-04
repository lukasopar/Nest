
using FluentNHibernate.Mapping;
using Nest.Model.Domain;


namespace Nest.DatabaseBootstrap.Mapping
{


    public class LijekStavkaRacunaMap : ClassMap<LijekStavkaRacuna> {
        
        public LijekStavkaRacunaMap() {
			
			Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Kolicina).Not.Nullable();
			References(x => x.LijekKodVeterinara).Cascade.SaveUpdate();
            References(x => x.Racun).Cascade.SaveUpdate();
        }
    }
}
