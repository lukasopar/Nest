
using FluentNHibernate.Mapping;
using Nest.Model.Domain;


namespace Nest.Desktop.Mapping {
    
    public class VrstaPostupkaMap : ClassMap<VrstaPostupka> {
        
        public VrstaPostupkaMap() {
		
			Id(x => x.Id).GeneratedBy.GuidNative();
			Map(x => x.Naziv).Not.Nullable();
			Map(x => x.Opis);
			Map(x => x.Cijena).Not.Nullable();
			References(x => x.Veterinar).Cascade.SaveUpdate();

			HasMany(x => x.Postupaks);
        }
    }
}
