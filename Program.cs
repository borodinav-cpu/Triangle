using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите A: ");
        string a = Console.ReadLine();

        Console.Write("Введите B: ");
        string b = Console.ReadLine();

        Console.Write("Введите C: ");
        string c = Console.ReadLine();

        var result = TriangleService.Calculate(a, b, c);

        Console.WriteLine($"Тип треугольника: {result.Item1}");
        Console.WriteLine("Координаты:");

        foreach (var point in result.Item2)
        {
            Console.WriteLine(point);
        }

        Log(a, b, c, result);
    }

    static void Log(string a, string b, string c, (string, List<(int, int)>) result)
    {
        string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string parameters = $"A={a}, B={b}, C={c}";
        string coordinates = string.Join(", ", result.Item2);

        bool success = result.Item1 == "равносторонний" ||
                       result.Item1 == "равнобедренный" ||
                       result.Item1 == "разносторонний";

        string logMessage;

        if (success)
        {
            logMessage = $"{time} | SUCCESS | {parameters} | Тип: {result.Item1} | Коорд: {coordinates}";
        }
        else
        {
            logMessage = $"{time} | ERROR | {parameters} | Результат: {result.Item1} | Коорд: {coordinates}";
        }

        // вывод в консоль
        Console.WriteLine("LOG: " + logMessage);

        // запись в файл
        File.AppendAllText("app.log", logMessage + Environment.NewLine);
    }
}