
using FluentNHibernate.Mapping;
using Nest.Model.Domain;


namespace Nest.Desktop.Mapping {
    
    
    public class PostupakMap : ClassMap<Postupak> {
        
        public PostupakMap() {
			
			Id(x => x.Id);
			Map(x => x.Opaska);
            Map(x => x.Datum);
            References(x => x.Zivotinja).Cascade.None();
            References(x => x.VrstaPostupka).Cascade.None();
            References(x => x.Racun).Cascade.None();
            HasManyToMany(x => x.Bolests).Cascade.All().Table("BolestsPostupaks");
            HasManyToMany(x => x.Lijeks).Cascade.All().Table("LijeksPostupaks");

        }
    }
}
