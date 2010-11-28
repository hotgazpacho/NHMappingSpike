using System;
using NHMappingSpike.ValueTypes;

namespace NHMappingSpike.Entities
{
    public class Component : IEquatable<Component>
    {
        protected Component()
        {
        }

        public Component(ItemRevKey itemRevKey, string name)
        {
            ItemRevKey = itemRevKey;
            Name = name;
        }
        public virtual ItemRevKey ItemRevKey { get; protected set; }
        public virtual ItemRevControl ItemRevControl { get { return ItemRevKey.Item; } }
        public virtual string Name { get; set; }

        public virtual bool Equals(Component other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.ItemRevKey, ItemRevKey);
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
            return ItemRevKey.GetHashCode();
        }
    }
}