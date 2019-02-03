
using FluentNHibernate.Mapping;
using Nest.Model.Domain;


namespace Nest.DatabaseBootstrap.Mapping
{


    public class PostupakMap : ClassMap<Postupak> {
        
        public PostupakMap() {
			
			Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Opaska);
            Map(x => x.Datum);
            References(x => x.Zivotinja).Cascade.SaveUpdate();
            References(x => x.VrstaPostupka).Cascade.SaveUpdate();
            References(x => x.Racun).Cascade.SaveUpdate();
            HasManyToMany(x => x.Bolests).Cascade.SaveUpdate().Table("BolestsPostupaks");
            HasManyToMany(x => x.Lijeks).Cascade.SaveUpdate().Table("LijeksPostupaks");

        }
    }
}
