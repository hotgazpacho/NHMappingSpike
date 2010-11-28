using NHMappingSpike.ValueTypes;

namespace NHMappingSpike.Entities
{
    public class ComponentWithDetails : Component
    {
        public ComponentWithDetails(ItemRevKey itemRevKey, string name) : base(itemRevKey, name)
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