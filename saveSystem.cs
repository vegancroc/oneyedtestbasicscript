using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public static class saveSystem
{
    private static string fileName { get; set; } = @"\dataFile.txt";

    private static string dataName1 { get; set; } = "unlockedLevels=";

    public static string data1 { get; set; }

    private static string fullPath
    {
        get
        {
            return Application.persistentDataPath + fileName;
        }
        
    }

    private static string allData
    {
        get
        { 
            return dataName1 + data1 + "\r\n";
        }
    }

    public static void CreateSaveFile()
    { 
        List<string> dataInString = new List<string>();

        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }

        FileStream fs = File.Create(fullPath);
        fs.Close();

        if (string.IsNullOrEmpty(data1))
        {
            data1 = "0";
        }

        File.AppendAllText(fullPath, allData);
    }

    public static List<int> ReadNumbersInLine(int lineIndex)
    {
        List<int> numbersInLine = new List<int>();

        List<string> line = new List<string>();

        line.AddRange(File.ReadAllLines(fullPath));

        foreach (char c in line[lineIndex])
        {
            if (int.TryParse(c.ToString(), out _))
            {
                numbersInLine.Add(int.Parse(c.ToString()));
            }
        }

        return numbersInLine;
    }

    public static string ReadNumbersInLineString(int lineIndex)
    {
        string numbersInLineString = string.Empty;

        List<string> line = new List<string>();

        line.AddRange(File.ReadAllLines(fullPath));

        foreach (char c in line[lineIndex])
        {
            if (int.TryParse(c.ToString(), out _))
            {
                numbersInLineString += c;
            }
        }

        return numbersInLineString;
    }

    private static string GetOneLine(int lineIndex)
    {
        return File.ReadAllLines(fullPath)[lineIndex];
    }

    public static bool FileCheck()
    {
       return File.Exists(fullPath);
    }
}
