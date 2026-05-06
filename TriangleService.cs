using System;
using System.Collections.Generic;

public class TriangleService
{
    public static (string, List<(int, int)>) Calculate(string aStr, string bStr, string cStr)
    {
        if (!float.TryParse(aStr, out float a) ||
            !float.TryParse(bStr, out float b) ||
            !float.TryParse(cStr, out float c))
        {
            return ("", new List<(int, int)> { (-2, -2), (-2, -2), (-2, -2) });
        }

        if (a <= 0 || b <= 0 || c <= 0)
        {
            return ("", new List<(int, int)> { (-2, -2), (-2, -2), (-2, -2) });
        }

        if (a + b <= c || a + c <= b || b + c <= a)
        {
            return ("не треугольник", new List<(int, int)> { (-1, -1), (-1, -1), (-1, -1) });
        }

        string type;

        if (a == b && b == c)
            type = "равносторонний";
        else if (a == b || a == c || b == c)
            type = "равнобедренный";
        else
            type = "разносторонний";

        var coords = GetCoordinates(a, b, c);

        return (type, coords);
    }

    private static List<(int, int)> GetCoordinates(float a, float b, float c)
    {
        double x = (b * b + c * c - a * a) / (2 * c);
        double y = Math.Sqrt(Math.Max(b * b - x * x, 0));

        var points = new List<(double, double)>
        {
            (0, 0),
            (c, 0),
            (x, y)
        };

        double maxX = double.MinValue, maxY = double.MinValue;

        foreach (var p in points)
        {
            if (p.Item1 > maxX) maxX = p.Item1;
            if (p.Item2 > maxY) maxY = p.Item2;
        }

        double scale = 90 / Math.Max(maxX, maxY);

        var result = new List<(int, int)>();

        foreach (var p in points)
        {
            int sx = (int)(p.Item1 * scale + 5);
            int sy = (int)(p.Item2 * scale + 5);
            result.Add((sx, sy));
        }

        return result;
    }
}