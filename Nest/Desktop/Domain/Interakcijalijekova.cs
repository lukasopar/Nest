
namespace Nest.Desktop.Domain {
    
    public class InterakcijaLijekova {
        public virtual System.Guid Id { get; set; }
        public virtual Lijek Lijek1 { get; set; }
        public virtual Lijek Lijek2 { get; set; }
        public virtual string Opis { get; set; }
    }
}
