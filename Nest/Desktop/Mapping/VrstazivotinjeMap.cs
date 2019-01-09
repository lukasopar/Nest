using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Nest.Desktop.Domain;


namespace Nest.Desktop.Mapping {
    
    
    public class VrstaZivotinjeMap : ClassMapping<VrstaZivotinje> {
        
        public VrstaZivotinjeMap() {
			Schema("dbo");
			Lazy(true);
			Id(x => x.Id, map => map.Generator(Generators.Assigned));
			Property(x => x.Vrsta, map => map.NotNullable(true));
			ManyToOne(x => x.Veterinar, map => { map.Column("idVeterinar"); map.Cascade(Cascade.None); });

			Bag(x => x.VrstaZivotinjeKodVeterinaras, colmap =>  { colmap.Key(x => x.Column("idVrstaZivotinje")); colmap.Inverse(true); }, map => { map.OneToMany(); });
        }
    }
}
