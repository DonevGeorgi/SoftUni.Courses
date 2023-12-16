
using P03.Raiding.Core;
using P03.Raiding.Core.Interfaces;
using P03.Raiding.Factory;
using P03.Raiding.Factory.Interfaces;
using P03.Raiding.IO.Reader.Interface;
using P03.Raiding.IO.Writer.Interface;
using P03.VehiclesExtension.IO.Reader;
using P03.VehiclesExtension.IO.Writer;

IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWriter();
IFactory factory = new BornHero();

IEngine engine = new Engine(writer, reader, factory);

engine.Run();