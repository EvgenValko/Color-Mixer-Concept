using UnityEngine;

public static class ColorUtil
{
    public static float ColorMatching(Color32 color1, Color32 color2)
    {
        float maxValue = 765;

        long rmean = (color1.r + color2.r) / 2;
        long r = color1.r - color2.r;
        long g = color1.g - color2.g;
        long b = color1.b - color2.b;

        float result = Mathf.Sqrt((((512 + rmean) * r * r) >> 8) + 4 * g * g + (((767 - rmean) * b * b) >> 8));
        return 1 - result / maxValue;
    }

    public static Color MixColor(Color[] colors)
    {
        float r = 0;
        float g = 0;
        float b = 0;

        foreach (var item in colors)
        {
            r += item.r;
            g += item.g;
            b += item.b;
        }

        r = (r / colors.Length);
        g = (g / colors.Length);
        b = (b / colors.Length);

        return new Color(r, g, b);
    }
}
