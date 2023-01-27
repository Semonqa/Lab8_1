using System;
using System.IO;
using System.Linq;
using System.Threading;

class Program
{
    public static string[] arrayOfData = File.ReadAllLines("file.txt");
    public static int sixty = 60;
    private static void Main()
    {
        string[] position = new string[arrayOfData.Length];
        string[] color = new string[arrayOfData.Length];
        string[] text = new string[arrayOfData.Length];
        int[] firstSec = new int[arrayOfData.Length];
        int[] lastSec= new int[arrayOfData.Length];
        int[] allSec = new int[arrayOfData.Length];
        DistributeParametr(position, color, text, firstSec,lastSec, allSec);
        WriteTable();

        int secMax = lastSec.Max();
        for (int i = 0;i < secMax + 1;i++)
        {
            for (int j = 0; j < arrayOfData.Length;j++)
            {
                if (firstSec[j] == i) FillTable(position[j], color[j], text[j]);

                if (lastSec[j] == i) DeleteText(position[j], text[j]);
            }
            Thread.Sleep(1000);
        }

        Console.WriteLine();
        Console.WriteLine();

    }

    private static void DistributeParametr(string[] position, string[] color, string[] text, int[] firstSec, int[] lastSec, int[] allSec)
    {
        for (int i = 0; i<arrayOfData.Length; i++)
        {
            position[i] = FillArrayPosition(arrayOfData[i]);
            color[i] = FillArrayColor(arrayOfData[i]);
            text[i] = FillArrayText(arrayOfData[i]);
            firstSec[i] = FillArrayFirstSec(arrayOfData[i]);
            lastSec[i] = FillArrayLastSec(arrayOfData[i]);
        }

    }

    private static string FillArrayPosition(string line)
    {
        int index = line.IndexOf('[');
        string position;

        if (index != -1)
        {
            int indexOfComma = line.IndexOf(',');
            int posLength = indexOfComma - index;
            position = line.Substring(index + 1, posLength - 1);
        }
        else position = "Bottom";

        return position;
    }

    private static string FillArrayColor(string line)
    {
        int index = line.IndexOf(",");
        string color;

        if (index != -1)
        {
            int indexOfBkt = line.IndexOf("]");
            int colLength = indexOfBkt - index;
            color = line.Substring(index + 2, colLength - 2);
        }

        else color = "White";

        return color;   
    }

    private static string FillArrayText(string line)
    {
        int index = line.IndexOf("]");
        string text;

        if (index != -1)
        {
            text = line.Substring(index + 2);

        }
        else text = line.Substring(14);

        return text;
    }

    private static int FillArrayFirstSec(string line)
    {
        line = line.Replace(" - ", " ");
        line = line.Substring(0, 11);

        int sec;

        string secIndex = line.Substring(0, 6);
        int indexDoublePoint = line.IndexOf(":");
        int minute = Convert.ToInt32(secIndex.Substring (0, indexDoublePoint));
        int second = Convert.ToInt32(secIndex.Substring(3));
        sec = minute * sixty + second;

        return sec;
    }
    
    private static int FillArrayLastSec(string line)
    {
        line = line.Replace(" - ", " ");
        line = line.Substring(0, 11);

        int sec;

        string secIndex = line.Substring(6);
        int indexDoublePoint = line.IndexOf(":");
        int minute = Convert.ToInt32(secIndex.Substring(0, indexDoublePoint));
        int second = Convert.ToInt32(secIndex.Substring(3));
        sec = minute * sixty + second;

        return sec;
    }

    private static void WriteTable()
    {
        for (int i = 0; i <= 100; i++)
        {
            Console.Write("─");
        }

        for (int j = 1; j <= 20; j++)
        {
            Console.SetCursorPosition(0, j);
            Console.Write("│");
            Console.SetCursorPosition(100, j);
            Console.Write("│");
        }
        Console.SetCursorPosition(0, 21);

        for (int g = 0; g <= 100; g++)
        {
            Console.Write("─");
        }
    }

    private static void FillTable(string position, string color, string text)
    {
        switch (position)
        {
            case "Top":
                Console.SetCursorPosition(50 - text.Length/2, 1);
                break;

            case "Bottom":
                Console.SetCursorPosition(50 - text.Length / 2, 20);
                break;

            case "Left":
                Console.SetCursorPosition(1, 10);
                break;

            case "Right":
                Console.SetCursorPosition(100 - text.Length , 10);
                break;
        }

        switch (color)
        {
            case "Red":
                Console.ForegroundColor= ConsoleColor.Red;
                break;

            case "Green":
                Console.ForegroundColor= ConsoleColor.Green;
                break;

            case "Blue":
                Console.ForegroundColor= ConsoleColor.Blue;
                break;

            case "White":
                Console.ForegroundColor= ConsoleColor.White;
                break;
        }

        Console.Write(text);
    }

    private static void DeleteText(string position, string text)
    {
        switch (position)
        {
            case "Top":
                Console.SetCursorPosition(50 - text.Length / 2, 1);
                for (int i = 0; i <= text.Length; i++)
                {
                    Console.Write(" ");
                }
                break;

            case "Bottom":
                Console.SetCursorPosition(50 - text.Length / 2, 20);
                for (int i = 0; i <= text.Length; i++)
                {
                    Console.Write(" ");
                }
                break;

            case "Left":
                Console.SetCursorPosition(1, 10);
                for (int i = 0; i <= text.Length; i++)
                {
                    Console.Write(" ");
                }
                break;

            case "Right":
                Console.SetCursorPosition(99 - text.Length, 10);
                for (int i = 0; i <= text.Length; i++)
                {
                    Console.Write(" ");
                }
                break;
        }
    }
}