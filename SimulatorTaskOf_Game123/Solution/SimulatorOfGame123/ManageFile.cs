using System.Collections.Generic;
using System.IO;
using System.Text;

class ManageFile
{
    public void WritingInFile(string filename, char[,] stream)
    {
        using (StreamWriter writer = new StreamWriter(filename, true, Encoding.GetEncoding("UTF-8")))
        {
            for (int i = 0; i < stream.GetLength(0); i++)
            {
                string line = null;

                for (int j = 0; j < stream.GetLength(1); j++)
                {
                    line += stream[i, j];
                }

                writer.WriteLine(line);
            }

            writer.Flush();
        }
    }

    public void WritingInFile(string filename, string text)
    {
        using (StreamWriter writer = new StreamWriter(filename, true))
        { 
            writer.WriteLine(text);            
        }
    }

    public void AppendTextToFile(string filename, string text)
    {
        using (StreamWriter writer = new StreamWriter(filename, true))
        {
            writer.WriteLine(text);
        }
    }

    public string[] ReadingTextFile(string filename)
    {
        List<string> list = new List<string>();

        using (StreamReader reader = new StreamReader(filename))
        {
            while (reader.Peek() >= 0)
            {
                list.Add(reader.ReadLine());
            }
        }

        string[] readerRows = list.ToArray();
        return readerRows;
    }

    public bool IsFileExist(string filename)
    {
        bool isFileExist = false;

        if (File.Exists(filename))
        {
            isFileExist = true;
        }

        return isFileExist;
    }
}