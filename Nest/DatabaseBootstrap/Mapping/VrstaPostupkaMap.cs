
using FluentNHibernate.Mapping;
using Nest.Model.Domain;


namespace Nest.DatabaseBootstrap.Mapping
{

    public class VrstaPostupkaMap : ClassMap<VrstaPostupka> {
        
        public VrstaPostupkaMap() {
		
			Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Naziv).Not.Nullable();
			Map(x => x.Opis);
			Map(x => x.Cijena).Not.Nullable();
            Map(x => x.Aktivno);

            References(x => x.Veterinar).Cascade.SaveUpdate();

			HasMany(x => x.Postupaks);
        }
    }
}
