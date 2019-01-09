using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Nest.Desktop.Domain;


namespace Nest.Desktop.Mapping {
    
    
    public class VrstaZivotinjeKodVeterinaraMap : ClassMapping<VrstaZivotinjeKodVeterinara> {
        
        public VrstaZivotinjeKodVeterinaraMap() {
			Schema("dbo");
			Lazy(true);
			Id(x => x.Id, map => map.Generator(Generators.Assigned));
			ManyToOne(x => x.Zivotinja, map => 
			{
				map.Column("idZivotinja");
				map.PropertyRef("Id");
				map.Cascade(Cascade.None);
			});

			ManyToOne(x => x.Veterinar, map => { map.Column("idVeterinar"); map.Cascade(Cascade.None); });

			ManyToOne(x => x.VrstaZivotinje, map => 
			{
				map.Column("idVrstaZivotinje");
				map.PropertyRef("Id");
				map.Cascade(Cascade.None);
			});

        }
    }
}
