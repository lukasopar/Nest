using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Nest.Desktop.Domain;


namespace Nest.Desktop.Mapping {
    
    
    public class LijekZaBolestMap : ClassMapping<LijekZaBolest> {
        
        public LijekZaBolestMap() {
			Schema("dbo");
			Lazy(true);
			Id(x => x.Id, map => map.Generator(Generators.Assigned));
			Property(x => x.Napomena);
			ManyToOne(x => x.Lijek, map => { map.Column("idLijek"); map.Cascade(Cascade.None); });

			ManyToOne(x => x.Bolest, map => { map.Column("idBolest"); map.Cascade(Cascade.None); });

        }
    }
}
