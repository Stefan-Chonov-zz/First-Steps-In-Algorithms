using System;
using System.Drawing;

namespace AlgorithmicTaskOfGame_123
{
    class AlgorithmicTaskOfGame_123 
    {
        private const char FIGURE_A = 'A';
        private const char FIGURE_B = 'B';
        private const char EMPTY_BOX = '-';

        static void Main(string[] args)
        {
            InitializeGame_123();
        }

        private static void InitializeGame_123()
        {
            byte m = 0;
            byte n = 0;
            char currentFigureTurn = ' ';
            char[,] board = null;

            try
            {
                // Read M and N from console
                string readMN = Console.ReadLine();

                // Check is input for M and N valid
                MNValidation mnValidation = new MNValidation();
                mnValidation.MNValidationProcess(readMN, out n, out m);

                // Read new board from Console
                string[] readBoard = new string[n];
                ReadDataFromConsole(readBoard);

                // Check is inputed board valid
                bool isJagged = readBoard.IsArrayJagged(n, m);
                if (isJagged)
                {
                    throw new InvalidBoardException(Notifications.INVALID_BOARD_MESSAGE);
                }
                                
                board = new char[n, m];
                board = readBoard.ToArrayOfChars();

                bool isBoardFilled = board.IsContain(EMPTY_BOX);

                if (!isBoardFilled)
                {
                    throw new InvalidBoardException();
                }

                // Read who is next turn
                string readFigureTurn = Console.ReadLine();

                // Check is entered figure valid
                FigureValidations figureValidations = new FigureValidations();
                bool isFigureLengthValid = figureValidations.IsFigureLengthValid(readFigureTurn);                
                if(isFigureLengthValid)
                {
                    currentFigureTurn = char.Parse(readFigureTurn);
                }

                bool isFigureCharacterValid = figureValidations.IsFigureCharacterValid(currentFigureTurn);
                if (!isFigureCharacterValid)
                {
                    Console.WriteLine(Notifications.ERROR_MESSAGE);
                    Console.WriteLine(Notifications.INVALID_TURN_MESSAGE);
                    return;
                }

                StartGame(board, currentFigureTurn);
            }
            catch (InvalidMNException invalidMNEx)
            {
                string message = invalidMNEx.Message;

                Console.WriteLine(Notifications.ERROR_MESSAGE);
                Console.WriteLine("{0}", message);

                int exitCode = Environment.ExitCode;
                Environment.Exit(exitCode);
            }
            catch (InvalidBoardException invalidBoardEx)
            {
                string message = invalidBoardEx.Message;
                Forfeiture((ushort)(n * m), currentFigureTurn, message);
            }
        }

        private static void ReadDataFromConsole(string[] rows)
        {
            for (int i = 0; i < rows.Length; i++)
            {
                rows[i] = Console.ReadLine();
            }
        }

        private static void StartGame(char[,] board, char currentFigureTurn)
        {
            StateOfBoard stateOfBoard = new StateOfBoard();
            stateOfBoard.MatrixFilledEvent += new StateOfBoard.MatrixEventHandler(stateOfGame_MatrixFilledEvent);

            // Check the board is filled
            bool isBoardContainEmptyBoxes = board.IsContain(EMPTY_BOX);
            stateOfBoard.NotifyIsBoardFilled(!isBoardContainEmptyBoxes, board);

            // Start algorithm            
            Game_123_Algorithm algorithm = new Game_123_Algorithm();            
            Point[] maximalSequenceOfEmptyBoxes = algorithm.Algorithm(board, currentFigureTurn);
                        
            char[,] newBoard = new char[board.GetLength(0), board.GetLength(1)];
            if (maximalSequenceOfEmptyBoxes != null)
            {
                board.CopyTo(newBoard);
                FillingTheBoard.MultipleFillingOfElements(newBoard, maximalSequenceOfEmptyBoxes, currentFigureTurn);
            }

            // Check is given board valid
            BoardValidations boardValidations = new BoardValidations();
            boardValidations.BoardValidationProcess(newBoard, board, currentFigureTurn);

            // Print filled board on screen
            CommonFuctionalityOfBoard.PrintBoardOnScreen(newBoard);

            // Check the board is filled
            isBoardContainEmptyBoxes = newBoard.IsContain(EMPTY_BOX);
            stateOfBoard.NotifyIsBoardFilled(!isBoardContainEmptyBoxes, newBoard);
        }

        static void stateOfGame_MatrixFilledEvent(object sender, MatrixFilledArgs args)
        {
            bool isBoardFilled = (bool)sender;

            if (isBoardFilled)
            {
                int exitCode = Environment.ExitCode;
                Environment.Exit(exitCode);
            }
        }
        
        private static void Forfeiture(ushort result, char figure, string message)
        {
            Console.WriteLine(Notifications.ERROR_MESSAGE);

            if (message != String.Empty)
            {
                Console.WriteLine(message);
            }

            if (figure == FIGURE_A)
            {
                Console.WriteLine("{0} - {1}", FIGURE_A, FIGURE_B);
                Console.WriteLine("0 - {0}", result);
            }
            else
            {
                Console.WriteLine("{0} - {1}", FIGURE_A, FIGURE_B);
                Console.WriteLine("{0} - 0", result);
            }
        }
    }
}