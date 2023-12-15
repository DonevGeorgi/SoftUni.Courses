using PersonInfo.Models.Enums;

namespace PersonInfo.Models.Interfaces
{
    public interface IMission
    {
        string CodeName { get; }
        State State { get; }
        void CompleteMission();
    }
}
