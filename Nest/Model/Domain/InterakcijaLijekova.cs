
using Model;

namespace Nest.Model.Domain {
    
    public class InterakcijaLijekova : EntityClass {
        //public virtual System.Guid Id { get; set; }
        public virtual Lijek Lijek1 { get; set; }
        public virtual Lijek Lijek2 { get; set; }
        public virtual string Opis { get; set; }
    }
}
