using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public abstract class EntityClass
    {
        public virtual int Id { get; set; }
        public override bool Equals(object obj)
        {
            var ob = obj as EntityClass;
            if (ob == null)
                return false;
            return ob.Id == Id;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
