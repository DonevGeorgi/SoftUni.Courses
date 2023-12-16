using P04.WildFarm.Core;
using P04.WildFarm.Factories;
using P04.WildFarm.Factories.Interface;
using P04.WildFarm.IO.Reader;
using P04.WildFarm.IO.Writer;
using P04.WildFarm.Core.Interfaces;
using P04.WildFarm.IO.Reader.Interface;
using P04.WildFarm.IO.Writer.Interface;

IWriter writer = new ConsoleWriter();
IReader reader = new ConsoleReader();

IFoodFactory foodFactory = new FoodFactory();
IAnimalFactory animalFactory = new AnimalFactory();

IEngine engine = new Engine(writer, reader, foodFactory, animalFactory);

engine.Run();