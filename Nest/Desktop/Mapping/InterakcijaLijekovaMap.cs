using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Nest.Desktop.Domain;


namespace Nest.Desktop.Mapping {
    
    
    public class InterakcijaLijekovaMap : ClassMapping<InterakcijaLijekova> {
        
        public InterakcijaLijekovaMap() {
			Schema("dbo");
			Lazy(true);
			Id(x => x.Id, map => map.Generator(Generators.Assigned));
			Property(x => x.Opis);
			ManyToOne(x => x.Lijek1, map => { map.Column("idLijek1"); map.Cascade(Cascade.None); });

			ManyToOne(x => x.Lijek2, map => { map.Column("idLijek2"); map.Cascade(Cascade.None); });

        }
    }
}
