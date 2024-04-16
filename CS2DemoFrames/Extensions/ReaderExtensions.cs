using System.Collections.Generic;

namespace CS2DemoFrames.Extensions;

public static class ReaderExtensions
{
    public static int ReadVarInt(this BinaryReader reader)
    {
        int result = 0;

        for (int i = 0; i <= sizeof(int); i++)
        {
            var b = reader.ReadByte();

            result |= (b & VarInt.LeastSignificalBitsMask) << (VarInt.LeastSignificalBitsCount * i);

            if ((b & VarInt.MostSignificantBitMask) == 0)
            {
                break;
            }
        }

        return result;
    }

    public static Frame ReadFrame(this BinaryReader reader)
    {
        var commandValue = reader.ReadVarInt();

        var frame = new Frame(
            Command: new(
                Value: commandValue,
                IsCompressed: (commandValue & 64) == 64,
                Message: commandValue & -65),
            Tick: reader.ReadVarInt(),
            Size: reader.ReadVarInt());

        reader.ReadBytes(frame.Size);

        return frame;
    }

    public static IEnumerable<Frame> ReadAllFrames(this BinaryReader reader)
    {
        Frame currentFrame;

        while (true)
        {
            try
            {
                currentFrame = reader.ReadFrame();
            }
            catch (EndOfStreamException)
            {
                break;
            }

            yield return currentFrame;
        }
    }
}