using System;
using System.Text;
using FluentNHibernate.Mapping;
using Nest.Model.Domain;


namespace Nest.Desktop.Mapping {
    
    
    public class VrstaZivotinjeMap : ClassMap<VrstaZivotinje> {
        
        public VrstaZivotinjeMap() {
			Id(x => x.Id);
			Map(x => x.Vrsta).Not.Nullable();
			References(x => x.Veterinar).Cascade.None();

            HasManyToMany(x => x.Zivotinjas).Cascade.All().Table("VrstaZivotinjas");
        }
    }
}
