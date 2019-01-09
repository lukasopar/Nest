

namespace Nest.Desktop.Domain {
    
    public class VrstaZivotinjeKodVeterinara {
        public virtual System.Guid Id { get; set; }
        public virtual Zivotinja Zivotinja { get; set; }
        public virtual Veterinar Veterinar { get; set; }
        public virtual VrstaZivotinje VrstaZivotinje { get; set; }

    }
}
