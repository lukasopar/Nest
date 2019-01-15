using System;
using System.Text;
using FluentNHibernate.Mapping;
using Nest.Model.Domain;


namespace Nest.Desktop.Mapping {
    
    
    public class ZivotinjaMap : ClassMap<Zivotinja> {
        
        public ZivotinjaMap() {
			
			Id(x => x.Id).GeneratedBy.Native();
			Map(x => x.Ime).Not.Nullable();
			Map(x => x.DatumRod);
			Map(x => x.Napomena);
			References(x => x.Vlasnik).Cascade.None();

            HasMany(x => x.Postupaks).Cascade.All();
            HasManyToMany(x => x.VrstaZivotinjes).Cascade.All().Table("VrstaZivotinjas");
        }
    }
}
