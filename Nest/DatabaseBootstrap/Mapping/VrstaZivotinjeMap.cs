using System;
using System.Text;
using FluentNHibernate.Mapping;
using Nest.Model.Domain;


namespace Nest.DatabaseBootstrap.Mapping
{


    public class VrstaZivotinjeMap : ClassMap<VrstaZivotinje> {
        
        public VrstaZivotinjeMap() {
			Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Vrsta).Not.Nullable();
            Map(x => x.Aktivno);

            References(x => x.Veterinar).Cascade.None();

            HasManyToMany(x => x.Zivotinjas).Cascade.All().Table("VrstaZivotinjas");
        }
    }
}
