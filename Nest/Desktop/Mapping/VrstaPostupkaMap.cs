using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Nest.Desktop.Domain;


namespace Nest.Desktop.Mapping {
    
    
    public class VrstaPostupkaMap : ClassMapping<VrstaPostupka> {
        
        public VrstaPostupkaMap() {
			Schema("dbo");
			Lazy(true);
			Id(x => x.Id, map => map.Generator(Generators.Assigned));
			Property(x => x.Naziv, map => map.NotNullable(true));
			Property(x => x.Opis);
			Property(x => x.Cijena, map => map.NotNullable(true));
			ManyToOne(x => x.Veterinar, map => { map.Column("idVeterinar"); map.Cascade(Cascade.None); });

			Bag(x => x.Postupaks, colmap =>  { colmap.Key(x => x.Column("idVrstaPostupka")); colmap.Inverse(true); }, map => { map.OneToMany(); });
        }
    }
}
