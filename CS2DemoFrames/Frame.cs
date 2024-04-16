namespace CS2DemoFrames;

public record struct Command(int Message, int Value, bool IsCompressed)
{
    public const byte CompressedMask = 0x40;
    public const sbyte MessageMask = -(CompressedMask + 1);
}

public record struct Frame(Command Command, int Tick, int Size);