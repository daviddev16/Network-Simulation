using System.Text;
using System;

public static class Utility
{

    public static readonly char[] HEX = { '0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F' };
    public static readonly Random RANDOM = new Random();

    public static float Clamp(float value, float min, float max)
    {
        if (value > max)
        {
            return max;
        }
        else if (value < min)
        {
            return min;
        }

        return value;
    }

    public static string GenerateMACAddress()
    {
        string RandomHexDigit() 
        {
            return HEX[(int)Math.Floor(HEX.Length * RANDOM.NextDouble())] + "" + 
                HEX[(int)Math.Floor(HEX.Length * RANDOM.NextDouble())];
        }
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < 6; i++)
        {
            builder.Append('-').Append(RandomHexDigit());
        }
        return builder.ToString().Substring(1);
    }

}
