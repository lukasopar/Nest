
using FluentNHibernate.Mapping;
using Nest.Model.Domain;


namespace Nest.Desktop.Mapping {
    
    
    public class RacunMap : ClassMap<Racun> {
        
        public RacunMap() {
			
			Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Datum).Not.Nullable();
            HasManyToMany(x => x.LijekKodVeterinaras).Cascade.All().Table("LijekVetsRacuns");
            HasMany(x => x.Postupaks).Cascade.SaveUpdate();
        }
    }
}
