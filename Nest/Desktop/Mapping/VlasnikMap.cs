using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Nest.Desktop.Domain;


namespace Nest.Desktop.Mapping {
    
    
    public class VlasnikMap : ClassMapping<Vlasnik> {
        
        public VlasnikMap() {
			Schema("dbo");
			Lazy(true);
			Id(x => x.Id, map => map.Generator(Generators.Assigned));
			Property(x => x.Ime, map => map.NotNullable(true));
			Property(x => x.Prezime, map => map.NotNullable(true));
			Property(x => x.Idprijava, map => map.NotNullable(true));
			Property(x => x.Datumrod);
			Bag(x => x.Zivotinjas, colmap =>  { colmap.Key(x => x.Column("idVlasnik")); colmap.Inverse(true); }, map => { map.OneToMany(); });
        }
    }
}
