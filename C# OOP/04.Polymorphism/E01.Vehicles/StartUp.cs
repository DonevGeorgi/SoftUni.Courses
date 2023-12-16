using P01.Vehicles.Core;
using P01.Vehicles.Core.Interfaces;
using P01.Vehicles.Factories;
using P01.Vehicles.Factories.Interface;
using P01.Vehicles.IO.Reader;
using P01.Vehicles.IO.Reader.Interface;
using P01.Vehicles.IO.Writer;
using P01.Vehicles.IO.Writer.Interface;

IWriter writer = new ConsoleWriter();
IReader reader = new ConsoleReader();

IFactory factory = new Factory();

IEngine engine = new Engine(writer, reader, factory);

engine.Run();