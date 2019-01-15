
using FluentNHibernate.Mapping;
using Nest.Model.Domain;


namespace Nest.Model.Mapping {
    
    
    public class BolestMap : ClassMap<Bolest> {

        public BolestMap()
        {
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Naziv).Length(30).Not.Nullable();
            Map(x => x.Opis);
            HasManyToMany(x => x.Postupaks).Cascade.All().Table("BolestsPostupaks");
            HasManyToMany(x => x.Lijeks).Cascade.All().Table("BolestsLijeks");
        }
    }
}
