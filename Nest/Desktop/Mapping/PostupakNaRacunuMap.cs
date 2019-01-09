using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using Nest.Desktop.Domain;


namespace Nest.Desktop.Mapping {
    
    
    public class PostupakNaRacunuMap : ClassMapping<PostupakNaRacunu> {
        
        public PostupakNaRacunuMap() {
			Schema("dbo");
			Lazy(true);
			Id(x => x.Id, map => map.Generator(Generators.Assigned));
			ManyToOne(x => x.Racun, map => { map.Column("idRacun"); map.Cascade(Cascade.None); });

			ManyToOne(x => x.Postupak, map => 
			{
				map.Column("idPostupak");
				map.PropertyRef("Id");
				map.Cascade(Cascade.None);
			});

        }
    }
}
