using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Nest.Desktop.Domain;


namespace Nest.Desktop.Mapping {
    
    
    public class LijekNaPostupkuMap : ClassMapping<LijekNaPostupku> {
        
        public LijekNaPostupkuMap() {
			Schema("dbo");
			Lazy(true);
			Id(x => x.Id, map => map.Generator(Generators.Assigned));
			Property(x => x.Uputa);
			ManyToOne(x => x.LijekKodVeterinara, map => 
			{
				map.Column("idLijekKodVeterinara");
				map.PropertyRef("Id");
				map.Cascade(Cascade.None);
			});

			ManyToOne(x => x.Postupak, map => 
			{
				map.Column("idPostupak");
				map.PropertyRef("Id");
				map.Cascade(Cascade.None);
			});

        }
    }
}
