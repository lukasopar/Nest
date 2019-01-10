using System;
using FluentNHibernate.Mapping;
using Nest.Model.Domain;


namespace Nest.Desktop.Mapping {
    
    
    public class VeterinarMap : ClassMap<Veterinar> {
        
        public VeterinarMap() {
			Id(x => x.Id);
            Map(x => x.Ime).Not.Nullable();
            Map(x => x.Prezime).Not.Nullable();
            Map(x => x.DatumRod).Not.Nullable();
            Map(x => x.DatumLicence).Not.Nullable();
            Map(x => x.KorisnickoIme).Not.Nullable();
            Map(x => x.Lozinka).Not.Nullable();
            HasMany(x => x.LijekKodVeterinaras);
            HasMany(x => x.VrstaPostupkas);
            HasMany(x => x.VrstaZivotinjes);
        }
    }
}
