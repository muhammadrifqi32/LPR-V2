using System.Security.Cryptography;

namespace PurchaseRequestSystem.Helpers;

/// <summary>
/// Lightweight ULID generator without external package.
/// Returns a 26-character Crockford Base32 ULID string.
/// </summary>
public static class UlidHelper
{
    private const string Alphabet = "0123456789ABCDEFGHJKMNPQRSTVWXYZ";

    public static string NewUlid()
    {
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        Span<byte> bytes = stackalloc byte[16];

        // 48-bit timestamp big-endian
        bytes[0] = (byte)(timestamp >> 40);
        bytes[1] = (byte)(timestamp >> 32);
        bytes[2] = (byte)(timestamp >> 24);
        bytes[3] = (byte)(timestamp >> 16);
        bytes[4] = (byte)(timestamp >> 8);
        bytes[5] = (byte)timestamp;

        RandomNumberGenerator.Fill(bytes[6..]);
        return Encode(bytes);
    }

    private static string Encode(ReadOnlySpan<byte> bytes)
    {
        Span<char> chars = stackalloc char[26];
        var value = new byte[17];
        bytes.CopyTo(value.AsSpan(1));

        var bitBuffer = 0;
        var bitCount = 0;
        var index = 0;

        foreach (var b in value)
        {
            bitBuffer = (bitBuffer << 8) | b;
            bitCount += 8;
            while (bitCount >= 5 && index < 26)
            {
                var shift = bitCount - 5;
                var c = (bitBuffer >> shift) & 31;
                chars[index++] = Alphabet[c];
                bitCount -= 5;
                bitBuffer &= (1 << bitCount) - 1;
            }
        }

        return new string(chars);
    }
}
