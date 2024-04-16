using CS2DemoFrames.Extensions;

var demoPathArg = args.FirstOrDefault();

if (string.IsNullOrWhiteSpace(demoPathArg))
{
    Console.Error.WriteLine("Demo file path is required.");
    Environment.Exit(1);
}

var demoPath = demoPathArg.Normalize();

if (!File.Exists(demoPath))
{
    Console.Error.WriteLine("Demo file does not exist.");
    Environment.Exit(1);
}

var stream = File.OpenRead(demoPath);
var reader = new BinaryReader(stream);

// Skipping filestamp and unknown bytes 
reader.ReadBytes(8);
reader.ReadBytes(8);

var framesWithIndex = reader.ReadAllFrames()
    .Select((frame, index) => (frame, index));

foreach (var (frame, index) in framesWithIndex)
{
    Console.WriteLine($"{index} - {frame}");
}