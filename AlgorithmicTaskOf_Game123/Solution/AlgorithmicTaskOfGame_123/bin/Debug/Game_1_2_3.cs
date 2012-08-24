using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game_1_2_3
{
    class Game_1_2_3
    {
        static void Main(string[] args)
        {
            string readNM = Console.ReadLine();
            bool isContainSpace = readNM.Contains(' ');

            if (isContainSpace)
            {                
                char element = '0';
                string readM = null;
                string readN = null;                
                int iterator = 0;

                while (true)
                {
                    element = readNM[iterator];

                    if (element != ' ')
                    {
                        readM += element;
                        iterator++;
                    }
                    else
                    {
                        iterator++;
                        break;
                    }
                }

                while (iterator != readNM.Length)
                {
                    readN += readNM[iterator];
                    iterator++;
                }

                byte n = 0;
                byte m = 0;
                bool isNNumerics = byte.TryParse(readN, out n);
                bool isMNumerics = byte.TryParse(readM, out m);

                if (isNNumerics && isMNumerics)
                {
                    // Default empty board
                    char[,] emptyBoard = DefaultEmptyBoard(n, m);
                    string[] readMRow = new string[m];

                    if ((3 <= n) && (n <= m) && (m <= 20))
                    {
                        for (int i = 0; i < n; i++)
                        {
                            readMRow[i] = Console.ReadLine();                            
                        }

                        bool isColumnsLengthValid = true;
                        byte errorInRow = 0;

                        for (byte i = 0; i < n; i++)
                        {
                            if (readMRow[i].Length != m)
                            {
                                isColumnsLengthValid = false;
                                errorInRow = i;
                                break;
                            }
                        }
                        
                        if (isColumnsLengthValid)
                        {

                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        Console.Write("error");
                    }
                }
                else
                {
                    Console.Write("error");
                }
            }
            else
            {
                Console.Write("error");
            }
        }

        private static char[,] DefaultEmptyBoard(byte n, byte m)
        {
            char[,] board = new char[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    board[i, j] = '-';
                }
            }

            return board;
        }
    }
}