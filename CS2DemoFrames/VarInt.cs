namespace CS2DemoFrames;

public class VarInt
{
    public const byte MostSignificantBitMask = 0x80;
    public const byte LeastSignificantBitsMask = 0xFF ^ MostSignificantBitMask;
    public const byte LeastSignificantBitsCount = 7;
}