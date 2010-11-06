using NHMappingSpike.ValueTypes;

namespace NHMappingSpike.Entities
{
    public class ComponentWithDetails : Component
    {
        public ComponentWithDetails(ItemKey itemKey, string name) : base(itemKey, name)
        {
        }

        protected ComponentWithDetails()
        {
        }

        public virtual string Category { get; set; }
        public virtual double Cost { get; set; }
        public virtual bool IsCertified { get; set; }
    }
}