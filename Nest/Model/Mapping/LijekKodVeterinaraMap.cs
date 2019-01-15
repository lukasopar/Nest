
using FluentNHibernate.Mapping;
using Nest.Model.Domain;


namespace Nest.Desktop.Mapping {
    
    
    public class LijekKodVeterinaraMap : ClassMap<LijekKodVeterinara> {
        
        public LijekKodVeterinaraMap() {
			
			Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Cijena).Not.Nullable();
			Map(x => x.Napomena);
			References(x => x.Lijek).Cascade.SaveUpdate();
            References(x => x.Veterinar).Cascade.SaveUpdate();
            HasManyToMany(x => x.Racuns).Cascade.All().Table("LijekVetsRacuns");
        }
    }
}
