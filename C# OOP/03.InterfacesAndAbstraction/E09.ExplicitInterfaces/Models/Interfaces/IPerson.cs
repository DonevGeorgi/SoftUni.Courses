namespace PersonInfo.Models.Interface
{
    public interface IPerson
    {
        string Name { get; }
        int Age { get; }
        public string GetName();
    }
}
