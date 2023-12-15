using PersonInfo.Models.Enums;

namespace PersonInfo.Models.Interfaces
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
