
namespace Nest.Desktop.Domain {
    
    public class LijekNaPostupku {
        public virtual System.Guid Id { get; set; }
        public virtual LijekKodVeterinara LijekKodVeterinara { get; set; }
        public virtual Postupak Postupak { get; set; }
        public virtual string Uputa { get; set; }
    }
}
