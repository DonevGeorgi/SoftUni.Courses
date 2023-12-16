using P03.Raiding.Core.Interfaces;
using P03.Raiding.Factory.Interfaces;
using P03.Raiding.IO.Reader.Interface;
using P03.Raiding.IO.Writer.Interface;
using P03.Raiding.Models.Interfaces;

namespace P03.Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IFactory factory;

        private readonly ICollection<IHero> party;

        public Engine(IWriter writer, IReader reader, IFactory heroFactory)
        {
            this.writer = writer;
            this.reader = reader;
            this.factory = heroFactory;

            this.party = new List<IHero>();
        }

        public void Run()
        {
            int n = int.Parse(reader.ReaderLine());

            for (int i = 0; i < n; i++)
            {
                string name = reader.ReaderLine();
                string type = reader.ReaderLine();

                try
                {
                    party.Add(factory.Create(type, name));
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                    i--;
                }
                catch (Exception ex)
                {
                    throw;
                }

            }

            int bossPower = int.Parse(reader.ReaderLine());

            int partyDamage = 0;

            foreach (var currMember in party)
            {
                Console.WriteLine(currMember.CastAbility());
                partyDamage += currMember.Power;
            }

            if (partyDamage >= bossPower)
            {
                writer.WriteLine("Victory!");
            }
            else
            {
                writer.WriteLine("Defeat...");
            }
        }
    }
}
