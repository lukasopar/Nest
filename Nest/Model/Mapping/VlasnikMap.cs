using System;
using System.Text;
using FluentNHibernate.Mapping;
using Nest.Model.Domain;


namespace Nest.Desktop.Mapping {
    
    
    public class VlasnikMap : ClassMap<Vlasnik> {
        
        public VlasnikMap() {

			Id(x => x.Id);
			Map(x => x.Ime).Not.Nullable();
            Map(x => x.Prezime).Not.Nullable();
            Map(x => x.Idprijava).Not.Nullable();
            Map(x => x.DatumRod).Not.Nullable();
            HasMany(x => x.Zivotinjas);
        }
    }
}
