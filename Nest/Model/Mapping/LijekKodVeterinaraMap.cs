
using FluentNHibernate.Mapping;
using Nest.Model.Domain;


namespace Nest.Desktop.Mapping {
    
    
    public class LijekKodVeterinaraMap : ClassMap<LijekKodVeterinara> {
        
        public LijekKodVeterinaraMap() {
			
			Id(x => x.Id);
            Map(x => x.Cijena).Not.Nullable();
			Map(x => x.Napomena);
			References(x => x.Lijek).Cascade.None();
            References(x => x.Veterinar).Cascade.None();
            HasManyToMany(x => x.Racuns).Cascade.All().Table("LijekVetsRacuns");
        }
    }
}
