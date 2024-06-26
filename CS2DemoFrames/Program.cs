﻿using System.Text.Json;
using CS2DemoFrames;
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

long offset = stream.Position;

var serializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);

foreach (var frame in reader.ReadAllFrames())
{
    Result result = new(offset, frame);

    Console.Out.WriteLine(JsonSerializer.Serialize(result, serializerOptions));

    offset = stream.Position;
}

record Result(long Offset, Frame Frame);