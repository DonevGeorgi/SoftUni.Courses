
using P02.VehicleExtension.Core;
using P02.VehicleExtension.Core.Interfaces;
using P02.VehicleExtension.Factory;
using P02.VehicleExtension.Factory.Interfaces;
using P02.VehiclesExtension.IO.Reader;
using P02.VehiclesExtension.IO.Reader.Interface;
using P02.VehiclesExtension.IO.Writer;
using P02.VehiclesExtension.IO.Writer.Interface;

IWriter writer = new ConsoleWriter();
IReader reader = new ConsoleReader();
IFactory factory = new Factory();

IEngine engine = new Engine(writer, reader, factory);

engine.Run();
