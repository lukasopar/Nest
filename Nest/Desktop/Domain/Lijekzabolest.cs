
namespace Nest.Desktop.Domain {
    
    public class LijekZaBolest {
        public virtual System.Guid Id { get; set; }
        public virtual Lijek Lijek { get; set; }
        public virtual Bolest Bolest { get; set; }
        public virtual string Napomena { get; set; }
    }
}
