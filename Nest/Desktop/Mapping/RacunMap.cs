using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Nest.Desktop.Domain;


namespace Nest.Desktop.Mapping {
    
    
    public class RacunMap : ClassMapping<Racun> {
        
        public RacunMap() {
			Schema("dbo");
			Lazy(true);
			Id(x => x.Id, map => map.Generator(Generators.Assigned));
			Property(x => x.Datum, map => map.NotNullable(true));
			Bag(x => x.LijekNaRacunus, colmap =>  { colmap.Key(x => x.Column("idRacun")); colmap.Inverse(true); }, map => { map.OneToMany(); });
			Bag(x => x.PostupakNaRacunus, colmap =>  { colmap.Key(x => x.Column("idRacun")); colmap.Inverse(true); }, map => { map.OneToMany(); });
        }
    }
}
