namespace AquaWorld.Data.Models.Contracts
{
    public interface ICreature
    {
        string Name { get; set; }

        string ImageUrl { get; set; }

        string Category { get; set; }

        string Description { get; set; }

        int AvailableCount { get; set; }
    }
}
