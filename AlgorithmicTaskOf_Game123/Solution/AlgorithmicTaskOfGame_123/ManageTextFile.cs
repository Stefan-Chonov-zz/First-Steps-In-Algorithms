//using System.Collections.Generic;
//using System.IO;
//using System.Text;

//namespace Game_1_2_3
//{
//    class ManageTextFile
//    {
//        public void WritingInTextFile(string filename, char[,] stream)
//        {
//            StreamWriter writer = new StreamWriter(filename, false, Encoding.GetEncoding("UTF-8"));

//            using (writer)
//            {
//                for (int i = 0; i < stream.GetLength(0); i++)
//                {
//                    string line = null;

//                    for (int j = 0; j < stream.GetLength(1); j++)
//                    {
//                        line += stream[i, j];
//                    }

//                    writer.WriteLine(line);
//                }

//                writer.Flush();
//            }
//        }

//        public List<string> ReadingTextFile(string filename)
//        {
//            List<string> list = new List<string>();
//            StreamReader reader = new StreamReader(filename);

//            using (reader)
//            {
//                while (reader.Peek() >= 0)
//                {
//                    list.Add(reader.ReadLine());
//                }
//            }

//            return list;
//        }

//        public bool IsFileExist(string filename)
//        {
//            bool isFileExist = false;

//            if (File.Exists(filename))
//            {
//                isFileExist = true;
//            }

//            return isFileExist;
//        }

//        public void DeleteFile(string filename)
//        {
//            File.Delete(filename);
//        }

//        public string ReadingBuffer(string filename)
//        {            
//            byte[] bytes = null;
//            string readedData = null;
//            UTF8Encoding encoding = new UTF8Encoding();

//            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
//            {
//                bytes = new byte[fs.Length];
//                int numBytesToRead = (int)fs.Length;
//                int numBytesRead = 0;  

//                while (fs.Read(bytes, numBytesRead, numBytesToRead) > 0)
//                {
//                    readedData += encoding.GetString(bytes, 0, numBytesToRead);
//                }
//            }

//            return readedData;
//        }
//    }
//}