namespace CS2DemoFrames;

public record struct Command(int Value)
{
    public readonly int Message => Value & MessageMask;
    public readonly bool IsCompressed => (Value & CompressedMask) == CompressedMask;

    public const byte CompressedMask = 0x40;
    public const sbyte MessageMask = -(CompressedMask + 1);
}

public record struct Frame(Command Command, int Tick, int Size);