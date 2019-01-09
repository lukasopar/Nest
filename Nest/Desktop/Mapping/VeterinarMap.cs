using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Nest.Desktop.Domain;


namespace Nest.Desktop.Mapping {
    
    
    public class VeterinarMap : ClassMapping<Veterinar> {
        
        public VeterinarMap() {
			Schema("dbo");
			Lazy(true);
			Id(x => x.Id, map => map.Generator(Generators.Assigned));
			Property(x => x.Ime, map => map.NotNullable(true));
			Property(x => x.Prezime, map => map.NotNullable(true));
			Property(x => x.Datumrod);
			Property(x => x.Datumlicence);
			Property(x => x.Idprijava, map => map.NotNullable(true));
			Bag(x => x.LijekKodVeterinaras, colmap =>  { colmap.Key(x => x.Column("idVeterinar")); colmap.Inverse(true); }, map => { map.OneToMany(); });
			Bag(x => x.Postupaks, colmap =>  { colmap.Key(x => x.Column("idVeterinar")); colmap.Inverse(true); }, map => { map.OneToMany(); });
			Bag(x => x.VrstaPostupkas, colmap =>  { colmap.Key(x => x.Column("idVeterinar")); colmap.Inverse(true); }, map => { map.OneToMany(); });
			Bag(x => x.VrstaZivotinjes, colmap =>  { colmap.Key(x => x.Column("idVeterinar")); colmap.Inverse(true); }, map => { map.OneToMany(); });
			Bag(x => x.VrstaZivotinjeKodVeterinaras, colmap =>  { colmap.Key(x => x.Column("idVeterinar")); colmap.Inverse(true); }, map => { map.OneToMany(); });
        }
    }
}
