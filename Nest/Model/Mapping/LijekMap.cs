
using FluentNHibernate.Mapping;
using Nest.Model.Domain;


namespace Nest.Desktop.Mapping {
    
    
    public class LijekMap : ClassMap<Lijek> {
        
        public LijekMap() {
			Id(x => x.Id);
			Map(x => x.Naziv).Not.Nullable();
			Map(x => x.Opis);
			HasMany(x => x.InterakcijaLijekovas1);
            HasMany(x => x.InterakcijaLijekovas2);
            HasMany(x => x.LijekKodVeterinaras);
            HasManyToMany(x => x.Bolests).Cascade.All().Table("BolestsLijeks");
            HasManyToMany(x => x.Postupaks).Cascade.All().Table("LijeksPostupaks");

        }
    }
}
