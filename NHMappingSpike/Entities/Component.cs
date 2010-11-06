using System;
using NHMappingSpike.ValueTypes;

namespace NHMappingSpike.Entities
{
    public class Component : IEquatable<Component>
    {
        protected Component()
        {
        }

        public Component(ItemKey itemKey, string name)
        {
            Item = itemKey.Item;
            ItemKey = itemKey;
            Name = name;
        }

        public virtual int ComponentKey { get; protected set; }
        public virtual ItemRevControl Item { get; protected set; }
        public virtual ItemKey ItemKey { get; protected set; }
        public virtual string Name { get; set; }

        public virtual bool Equals(Component other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.ItemKey, ItemKey);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Component)) return false;
            return Equals((Component) obj);
        }

        public override int GetHashCode()
        {
            return ItemKey.GetHashCode();
        }
    }
}