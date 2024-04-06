using System.Xml;
using static System.Console;
using static System.Formats.Asn1.AsnWriter;

class TestResults
{
    public static XmlDocument? document;
    public static XmlElement? titleNode;
    public static XmlElement? scoreNode;
    public static int min;
    public static int max;
    public static int average;
    //public static XmlNodeList? nodeList;

    public TestResults(string fileName, string titleNodeName, string scoreNodeName)
    {
        document = new XmlDocument();
        document.Load(fileName);
        titleNode = document.CreateElement(titleNodeName);
        scoreNode = document.CreateElement(scoreNodeName);
        min = FindMinScore();
        max = FindMaxScore();
        average = FindAverageScore();
    }

    private static int FindMinScore()
    {
        return 0;
    }

    private static int FindMaxScore()
    {
        return 10;
    }

    private static int FindAverageScore()
    {
        return 5;
    }

    public int[] GetScores()
    {
        return [min, max, average];
    }

    public string[] GetTitles()
    {
        return []; // parent to subtitle
    }
}

class Program
{
    static bool doesXmlFileExists(string path)
    {
        try
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
        }
        catch
        {
            return false;
        }
        return true;
    }

    static string[] GetParameters()
    {
        //WriteLine("Напишите, как называется файл");
        //string? file = ReadLine();
        string file = "1.xml";
        if (doesXmlFileExists(file))
        {
            WriteLine("Файл принят");

            //WriteLine("Напишите, как называется узел с названием задания");
            //string? title = ReadLine();
            string title = "subtitle";
            if (title != null)
            {
                //WriteLine("Напишите, как называется узел с кол-вом баллов по заданию");
                //string? score = ReadLine();
                string score = "score";
                if (score != null)
                {
                    try
                    {
                        TestResults test = new TestResults(file, title, score);
                        return [file, title, score];
                    }
                    catch (Exception e)
                    {
                        WriteLine("Ошибка: " + e.Message);
                    }
                }
            }
            else
            {
                WriteLine("Узлы с такими названиями отсуствуют в файле!");
            }
        }
        else
        {
            WriteLine("Файла не существует!");
        }
        return null;
    }

    static void Main()
    {
        string[] parameters = GetParameters();

        if (parameters != null)
        {
            WriteLine("Данные приняты :)");

            TestResults test = new TestResults(parameters[0], parameters[1], parameters[2]);
            int[] scores = test.GetScores();
            foreach (int i in scores)
            {
                Write(i + " ");
            }
        }
        else
        {
            //WriteLine("Контент файла имеет ошибки в оформлении!");
        }

        //Main(); // рекурсия
    }
}

