using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Nest.Desktop.Domain;


namespace Nest.Desktop.Mapping {
    
    
    public class BolestMap : ClassMapping<Bolest> {
        
        public BolestMap() {
			Schema("dbo");
			Lazy(true);
			Id(x => x.Id, map => map.Generator(Generators.Assigned));
			Property(x => x.Naziv, map => map.NotNullable(true));
			Property(x => x.Opis);
			Bag(x => x.BolestNaPostupkus, colmap =>  { colmap.Key(x => x.Column("idBolest")); colmap.Inverse(true); }, map => { map.OneToMany(); });
			Bag(x => x.LijekZaBolests, colmap =>  { colmap.Key(x => x.Column("idBolest")); colmap.Inverse(true); }, map => { map.OneToMany(); });
        }
    }
}
