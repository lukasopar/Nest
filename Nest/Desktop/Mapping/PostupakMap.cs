using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Nest.Desktop.Domain;


namespace Nest.Desktop.Mapping {
    
    
    public class PostupakMap : ClassMapping<Postupak> {
        
        public PostupakMap() {
			Schema("dbo");
			Lazy(true);
			Id(x => x.Id, map => map.Generator(Generators.Assigned));
			Property(x => x.Opaska);
			Property(x => x.Datum);
			ManyToOne(x => x.Veterinar, map => { map.Column("idVeterinar"); map.Cascade(Cascade.None); });

			ManyToOne(x => x.Zivotinja, map => 
			{
				map.Column("idZivotinja");
				map.PropertyRef("Id");
				map.Cascade(Cascade.None);
			});

			ManyToOne(x => x.VrstaPostupka, map => 
			{
				map.Column("idVrstaPostupka");
				map.PropertyRef("Id");
				map.Cascade(Cascade.None);
			});

			Bag(x => x.BolestNaPostupkus, colmap =>  { colmap.Key(x => x.Column("idPostupak")); colmap.Inverse(true); }, map => { map.OneToMany(); });
			Bag(x => x.LijekNaPostupkus, colmap =>  { colmap.Key(x => x.Column("idPostupak")); colmap.Inverse(true); }, map => { map.OneToMany(); });
			Bag(x => x.PostupakNaRacunus, colmap =>  { colmap.Key(x => x.Column("idPostupak")); colmap.Inverse(true); }, map => { map.OneToMany(); });
        }
    }
}
