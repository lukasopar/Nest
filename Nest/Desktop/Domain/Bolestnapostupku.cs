

namespace Nest.Desktop.Domain {
    
    public class BolestNaPostupku {
        public virtual System.Guid Id { get; set; }
        public virtual Bolest Bolest { get; set; }
        public virtual Postupak Postupak { get; set; }
    }
}
