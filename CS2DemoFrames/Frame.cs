namespace CS2DemoFrames;

public record struct Command(int Message, int Value, bool IsCompressed);
public record struct Frame(Command Command, int Tick, int Size);