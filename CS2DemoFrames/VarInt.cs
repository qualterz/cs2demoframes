namespace CS2DemoFrames;

public class VarInt
{
    public const byte MostSignificantBitMask = 0x80;
    public const byte LeastSignificalBitsMask = 0xFF ^ MostSignificantBitMask;
    public const byte LeastSignificalBitsCount = 7;
}