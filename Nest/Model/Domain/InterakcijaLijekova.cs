
using Model;

namespace Nest.Model.Domain {

    public class InterakcijaLijekova : EntityClass {
        //public virtual System.Guid Id { get; set; }

        public InterakcijaLijekova() { }
        public InterakcijaLijekova(Lijek lijek1, Lijek lijek2, string opis)
        {
            Lijek1 = lijek1;
            Lijek2 = lijek2;
            Opis = opis;
        }
        public virtual Lijek Lijek1 { get; set; }
        public virtual Lijek Lijek2 { get; set; }
        public virtual string Opis { get; set; }
    }
}
