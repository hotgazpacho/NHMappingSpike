using System;
using NHMappingSpike.Entities;

namespace NHMappingSpike.ValueTypes
{
    [Serializable]
    public class ItemKey : IEquatable<ItemKey>
    {
        protected ItemKey()
        {
        }

        public ItemKey(ItemRevControl itemRevControl, int revNo)
        {
            if (itemRevControl == null)
                throw new ArgumentNullException("itemRevControl");
            Item = itemRevControl;
            ItemId = itemRevControl.ItemId;
            RevNo = revNo;
        }

        public virtual ItemRevControl Item { get; protected set; }
        public virtual int ItemId { get; protected set; }
        public virtual int RevNo { get; protected set; }

        public bool Equals(ItemKey other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.ItemId == ItemId && other.RevNo == RevNo;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj as ItemKey != null && Equals((ItemKey) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (ItemId*397) ^ RevNo;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} ItemId: {1}, RevNo: {2} ({3})", new object[] { GetType(), ItemId, RevNo, Item });
        }
    }
}