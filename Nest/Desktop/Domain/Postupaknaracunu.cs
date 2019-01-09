

namespace Nest.Desktop.Domain {
    
    public class PostupakNaRacunu {
        public virtual System.Guid Id { get; set; }
        public virtual Racun Racun { get; set; }
        public virtual Postupak Postupak { get; set; }
    }
}
