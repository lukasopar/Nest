
using FluentNHibernate.Mapping;
using Nest.Model.Domain;


namespace Nest.Desktop.Mapping {
    
    
    public class LijekMap : ClassMap<Lijek> {
        
        public LijekMap() {
			Id(x => x.Id).GeneratedBy.GuidNative();
			Map(x => x.Naziv).Not.Nullable();
			Map(x => x.Opis);
			HasMany(x => x.InterakcijaLijekovas1).Cascade.All();
            HasMany(x => x.InterakcijaLijekovas2).Cascade.All();
            HasMany(x => x.LijekKodVeterinaras).Cascade.All();
            HasManyToMany(x => x.Bolests).Cascade.All().Table("BolestsLijeks");
            HasManyToMany(x => x.Postupaks).Cascade.All().Table("LijeksPostupaks");

        }
    }
}
