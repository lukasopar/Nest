using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Nest.Desktop.Domain;


namespace Nest.Desktop.Mapping {
    
    
    public class LijekMap : ClassMapping<Lijek> {
        
        public LijekMap() {
			Schema("dbo");
			Lazy(true);
			Id(x => x.Id, map => map.Generator(Generators.Assigned));
			Property(x => x.Naziv, map => map.NotNullable(true));
			Property(x => x.Opis);
			Bag(x => x.InterakcijaLijekovas1, colmap =>  { colmap.Key(x => x.Column("idLijek1")); colmap.Inverse(true); }, map => { map.OneToMany(); });
			Bag(x => x.InterakcijaLijekovas2, colmap =>  { colmap.Key(x => x.Column("idLijek2")); colmap.Inverse(true); }, map => { map.OneToMany(); });
			Bag(x => x.LijekKodVeterinaras, colmap =>  { colmap.Key(x => x.Column("idLijek")); colmap.Inverse(true); }, map => { map.OneToMany(); });
			Bag(x => x.LijekZaBolests, colmap =>  { colmap.Key(x => x.Column("idLijek")); colmap.Inverse(true); }, map => { map.OneToMany(); });
        }
    }
}
