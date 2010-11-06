using FluentNHibernate.Mapping;
using NHMappingSpike.Entities;

namespace NHMappingSpike.Mappings
{
    public class ItemRevControlMap : ClassMap<ItemRevControl>
    {
        public ItemRevControlMap()
        {
            Table("ItemRevControl");
            Id(x => x.ItemId)
                .GeneratedBy.Identity()
                .Access.BackingField();
            Map(x => x.RevNo)
                .Not.Nullable()
                .Check("RevNo > 0");
        }
    }
}