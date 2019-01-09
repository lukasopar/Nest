using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Nest.Desktop.Domain;


namespace Nest.Desktop.Mapping {
    
    
    public class LijekKodVeterinaraMap : ClassMapping<LijekKodVeterinara> {
        
        public LijekKodVeterinaraMap() {
			Schema("dbo");
			Lazy(true);
			Id(x => x.Id, map => map.Generator(Generators.Assigned));
			Property(x => x.Cijena, map => map.NotNullable(true));
			Property(x => x.Napomena);
			ManyToOne(x => x.Lijek, map => { map.Column("idLijek"); map.Cascade(Cascade.None); });

			ManyToOne(x => x.Veterinar, map => { map.Column("idVeterinar"); map.Cascade(Cascade.None); });

			Bag(x => x.LijekNaPostupkus, colmap =>  { colmap.Key(x => x.Column("idLijekKodVeterinara")); colmap.Inverse(true); }, map => { map.OneToMany(); });
			Bag(x => x.LijekNaRacunus, colmap =>  { colmap.Key(x => x.Column("idLijekKodVeterinara")); colmap.Inverse(true); }, map => { map.OneToMany(); });
        }
    }
}
