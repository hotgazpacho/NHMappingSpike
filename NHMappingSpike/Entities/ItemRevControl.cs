using System;

namespace NHMappingSpike.Entities
{
    public class ItemRevControl : IEquatable<ItemRevControl>
    {
        protected ItemRevControl()
        {
        }

        public ItemRevControl(int revNo)
        {
            RevNo = revNo;
        }

        public virtual int ItemId { get; protected set; }
        public virtual int RevNo { get; set; }

        public virtual bool Equals(ItemRevControl other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.ItemId == ItemId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj as ItemRevControl != null && Equals((ItemRevControl) obj);
        }

        public override int GetHashCode()
        {
            return ItemId;
        }

        public override string ToString()
        {
            return String.Format("{0} Id:{1} Rev:{2}", GetType(), ItemId, RevNo);
        }
    }
}