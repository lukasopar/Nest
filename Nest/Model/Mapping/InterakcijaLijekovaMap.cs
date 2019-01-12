
using FluentNHibernate.Mapping;
using Nest.Model.Domain;


namespace Nest.Desktop.Mapping {
    
    
    public class InterakcijaLijekovaMap : ClassMap<InterakcijaLijekova> {
        
        public InterakcijaLijekovaMap() {
            Id(x => x.Id).GeneratedBy.GuidNative();
			Map(x => x.Opis);
            References(x => x.Lijek1).Cascade.SaveUpdate();
            References(x => x.Lijek2).Cascade.SaveUpdate();

        }
    }
}
