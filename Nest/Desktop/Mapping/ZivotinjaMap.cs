using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Nest.Desktop.Domain;


namespace Nest.Desktop.Mapping {
    
    
    public class ZivotinjaMap : ClassMapping<Zivotinja> {
        
        public ZivotinjaMap() {
			Schema("dbo");
			Lazy(true);
			Id(x => x.Id, map => map.Generator(Generators.Assigned));
			Property(x => x.Ime, map => map.NotNullable(true));
			Property(x => x.Datumrod);
			Property(x => x.Napomena);
			ManyToOne(x => x.Vlasnik, map => { map.Column("idVlasnik"); map.Cascade(Cascade.None); });

			Bag(x => x.Postupaks, colmap =>  { colmap.Key(x => x.Column("idZivotinja")); colmap.Inverse(true); }, map => { map.OneToMany(); });
			Bag(x => x.VrstaZivotinjeKodVeterinaras, colmap =>  { colmap.Key(x => x.Column("idZivotinja")); colmap.Inverse(true); }, map => { map.OneToMany(); });
        }
    }
}
