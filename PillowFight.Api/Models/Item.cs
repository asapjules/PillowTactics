using PillowFight.Repositories.Enumerations;

namespace PillowFight.Api.Models
{
    public class Item
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ItemTypeEnum Type { get; set; }
    }
}
