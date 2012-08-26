using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;

namespace SimulatorOfGame123
{
    /// <summary>
    /// Interaction logic for BoardWindow.xaml
    /// </summary>
    public partial class BoardWindow : Window
    {
        private const char FIGURE_A = 'A';
        private const char FIGURE_B = 'B';
        private const string FIRST_ALGORITHM_PATH = "firstAlgorithmPath.txt";
        private const string SECOND_ALGORITHM_PATH = "secondAlgorithmPath.txt";
        private const string OLD_BOARD_FILENAME = "oldBoard.txt";
        private const string NEW_BOARD_FILENAME = "newBoard.txt";
        private const string TEMP_BOARD_FILENAME = "temporaryBoard.txt";
        private const char EMPTY_BOX = '-';
        private const int MAX_LENGTH_OF_EMPTY_BOXES = 3;

        private string executableFileOfAlgorithmOnTurn = null;
        private System.Windows.Point pp = new System.Windows.Point();
        private bool trigger = false;

        private BasePawn currentPawn = null;

        private byte rows = 0;
        private byte columns = 0;

        public BoardWindow(byte rows, byte columns, BasePawn pawn)
        {
            InitializeComponent();

            this.rows = rows;
            this.columns = columns;

            this.currentPawn = pawn;

            LoadBoard(this.boardGrid, rows, columns);

            if (this.boardGrid.Height + this.topMiddleGrid.Height < this.leftGrid.Height)
            {
                this.Height = this.leftGrid.Height;
                this.Width = this.leftGrid.Width + this.topMiddleGrid.Width + this.rightGrid.Width;
            }
            else
            {
                this.Height = this.boardGrid.Height + this.topMiddleGrid.Height + this.bottomCenterGrid.Height;
                this.Width = this.boardGrid.Width + this.leftGrid.Width + this.rightGrid.Width;
            }
        }
        
        private void LoadBoard(Grid grid, byte rows, byte columns)
        {
            YellowPawn[,] defaultPawns = new YellowPawn[rows, columns];
            
            // Initialize default pawns             
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    defaultPawns[i, j] = new YellowPawn();
                }
            }

            RowDefinition[,] defineRowsInGrid = new RowDefinition[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    defineRowsInGrid[i, j] = new RowDefinition();

                    // Initialize height
                    defineRowsInGrid[i, j].Height = new GridLength(defaultPawns[i, j].Height); 
                }
            }
            
            ColumnDefinition[,] defineColumnsInGrid = new ColumnDefinition[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    defineColumnsInGrid[i, j] = new ColumnDefinition();

                    // Initialize Width
                    defineColumnsInGrid[i, j].Width = new GridLength(defaultPawns[i, j].Width);
                }
            }
            
            // Set rows and columns
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Grid.SetRow(defaultPawns[i, j], i);
                    Grid.SetColumn(defaultPawns[i, j], j);
                }
            }
            
            grid.Width = (defaultPawns[0, 0].Width * columns);
            grid.Height = (defaultPawns[0, 0].Height * rows);
            grid.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            grid.VerticalAlignment = System.Windows.VerticalAlignment.Top;

            // Add rows and columns to grid
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    grid.RowDefinitions.Add(defineRowsInGrid[i, j]);
                    grid.ColumnDefinitions.Add(defineColumnsInGrid[i, j]);
                }
            }

            // Add pawns to current row and column in grid
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    grid.Children.Add(defaultPawns[i, j]);
                }
            }
        }

        public UIElement GetElement(Grid grid, UIElement element, int row, int col)
        {
            foreach (UIElement pawn in grid.Children)
            {
                if (Grid.GetRow(pawn) == row &&
                    Grid.GetColumn(pawn) == col)
                {
                    return pawn;
                }
            }

            return null;
        }
       
        private void boardGrid_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (trigger)
            {
                System.Windows.Point position = e.GetPosition(null);
                this.Top += position.Y - pp.Y;
                this.Left += position.X - pp.X;
            }
        }

        private void boardGrid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            pp = e.GetPosition(null);
            trigger = true;
        }

        private void boardGrid_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            trigger = false;
        }

        private void boardGrid_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.boardGrid.Width < this.startButton.Width)
            {
                // Set board position on window
                double boardGridLeft = (this.topMiddleGrid.Width - this.boardGrid.Width) / 2;
                this.boardGrid.Margin = new Thickness(
                                                      this.boardGrid.Margin.Left + boardGridLeft,
                    this.boardGrid.Margin.Top,
                                              this.boardGrid.Margin.Right + boardGridLeft,
                    this.boardGrid.Margin.Bottom);
            }
            else
            {
                this.Width = this.leftGrid.Width + this.boardGrid.Width + this.rightGrid.Width;
            }

            File.Delete(NEW_BOARD_FILENAME);

            RedPawn redPawn = new RedPawn();
            GreenPawn greenPawn = new GreenPawn();
            
            if (this.currentPawn.GetType() == redPawn.GetType())
            {
                AddPawnToScorePanel(this.leftGrid, redPawn);
                AddPawnToScorePanel(this.rightGrid, greenPawn);                
            }
            else
            {
                AddPawnToScorePanel(this.leftGrid, greenPawn);
                AddPawnToScorePanel(this.rightGrid, redPawn);                                
            }

            char[,] defaultBoard = new char[this.rows, this.columns];
            FillingTheBoard.FillingAllElements(defaultBoard, '-');

            ManageFile saveBoardInFile = new ManageFile();
            saveBoardInFile.WritingInFile(NEW_BOARD_FILENAME, defaultBoard);
        }

        public void AddPawnToScorePanel(Grid grid, BasePawn pawn)
        {
            grid.ClearCellAt(1, 0);

            RowDefinition rowDef = new RowDefinition();
            rowDef.Height = new GridLength(pawn.Height);

            ColumnDefinition colDef = new ColumnDefinition();
            double width = grid.Width - pawn.Width;
            colDef.Width = new GridLength(pawn.Width + width);

            Grid.SetRow(pawn, 1);
            Grid.SetColumn(pawn, 0);

            grid.RowDefinitions.Add(rowDef);
            grid.ColumnDefinitions.Add(colDef);

            grid.Children.Add(pawn);
        }

        private void startButton_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                string[] pathOfAlgorithm = new string[1];

                // Load path of algorithm on turn
                if (this.currentPawn.ID == FIGURE_A)
                {
                    // Load path of the first algorithm
                    ManageFile readPathOfAlgorithm = new ManageFile();
                    pathOfAlgorithm = readPathOfAlgorithm.ReadingTextFile(FIRST_ALGORITHM_PATH);
                    this.executableFileOfAlgorithmOnTurn = pathOfAlgorithm[0];
                    this.secondAlgorithmNextButton.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    // Load path of the second algorithm
                    ManageFile readPathOfAlgorithm = new ManageFile();
                    pathOfAlgorithm = readPathOfAlgorithm.ReadingTextFile(SECOND_ALGORITHM_PATH);
                    this.executableFileOfAlgorithmOnTurn = pathOfAlgorithm[0];
                    this.firstAlgorithmNextButton.Visibility = System.Windows.Visibility.Visible;
                }

                File.Delete(TEMP_BOARD_FILENAME);

                Stopwatch sw = new Stopwatch();
                sw.Start();
                StartExecutionOfAlgorithm(pathOfAlgorithm[0], 'A', NEW_BOARD_FILENAME, TEMP_BOARD_FILENAME);
                sw.Stop();

                TimeSpan timeSpan = sw.Elapsed;
                int seconds = timeSpan.Seconds;
                if (seconds > 0)
                {
                    string message = "Time elapsed!!!";
                    throw new ElapsedTimeException(message);
                }

                ManageFile mngFile = new ManageFile();
                char[,] newBoard = mngFile.ReadingTextFile(NEW_BOARD_FILENAME).ToArrayOfChars();
                char[,] tempBoard = mngFile.ReadingTextFile(TEMP_BOARD_FILENAME).ToArrayOfChars();

                if (this.currentPawn.ID == FIGURE_A)
                {
                    int numberOfNewElements = DifferencesBetweenTwoMatrices.CountAllDifferences(newBoard, tempBoard);
                    AddPointsToScorePanel(ref this.firstAlgorithmScores, (byte)numberOfNewElements);
                }
                else
                {
                    int numberOfNewElements = DifferencesBetweenTwoMatrices.CountAllDifferences(newBoard, tempBoard);
                    AddPointsToScorePanel(ref this.secondAlgorithmScores, (byte)numberOfNewElements);
                }

                AnalyzeBoard analyzeBoard = new AnalyzeBoard(tempBoard);
                System.Drawing.Point[] positionsOfNewElementsInBoard = analyzeBoard.ExtractPositionsOfAdjacentElements('A', 3);

                this.boardGrid = MultipleClearingOfCells(this.boardGrid, positionsOfNewElementsInBoard);

                foreach (System.Drawing.Point position in positionsOfNewElementsInBoard)
                {
                    DarkRedPawn darkRedPawn = new DarkRedPawn();
                    this.boardGrid.AddElementAtCell(darkRedPawn, position.X, position.Y);
                }

                string[] loadNewBoard = mngFile.ReadingTextFile(NEW_BOARD_FILENAME);

                File.Delete(OLD_BOARD_FILENAME);
                mngFile.WritingInFile(OLD_BOARD_FILENAME, loadNewBoard.ToArrayOfChars());

                File.Delete(NEW_BOARD_FILENAME);
                mngFile.WritingInFile(NEW_BOARD_FILENAME, tempBoard);

                currentPawn = new GreenPawn();

                this.startButton.Opacity = 0;
            }
            catch (FileNotFoundException fileNotFoundEx)
            {
                string fileName = fileNotFoundEx.FileName;
                string message = "The file with name '" + fileName + "' is missing!!!";
                MessageBox.Show(message);

                int exitCode = Environment.ExitCode;
                Environment.Exit(exitCode);
            }
            catch (ElapsedTimeException elapsedTimeEx)
            {
                string message = elapsedTimeEx.Message;
                message += "\nThe winner is algorithm who plays with 'Green pawns'!\n";
                message += "The result is: " + this.rows * this.columns + "- 0 for Green pawns!";
            }
        }

        private void StartExecutionOfAlgorithm(
            string pathOfAlgorithm, char figureOnTurn,
            string pathToOldBoardFile, string pathToNewBoardFile)
        { 
            ProcessStartInfo currentAlgorithmProcess = new ProcessStartInfo();
            currentAlgorithmProcess.FileName = pathOfAlgorithm;
            currentAlgorithmProcess.CreateNoWindow = true;
            currentAlgorithmProcess.UseShellExecute = false;
            currentAlgorithmProcess.RedirectStandardOutput = true;
            currentAlgorithmProcess.RedirectStandardInput = true;

            ManageFile mngBoardFile = new ManageFile();
            string[] readOldBoardFile = mngBoardFile.ReadingTextFile(pathToOldBoardFile);

            using (Process process = Process.Start(currentAlgorithmProcess))
            {
                using (StreamWriter streamWriter = process.StandardInput)
                {
                    streamWriter.WriteLine(this.columns + " " + this.rows);
                    for (int i = 0; i < readOldBoardFile.Length; i++)
                    {
                        streamWriter.WriteLine(readOldBoardFile[i]);
                    }
                    streamWriter.WriteLine(figureOnTurn);
                }

                process.WaitForExit();

                using (StreamReader reader = process.StandardOutput)
                {
                    while (reader.Peek() >= 0)
                    {
                        mngBoardFile.WritingInFile(pathToNewBoardFile, reader.ReadLine());
                    }
                }

                process.WaitForExit();
            }
        }

        private Grid MultipleClearingOfCells(Grid grid, System.Drawing.Point[] positions)
        {
            foreach (System.Drawing.Point position in positions)
            {
                grid.ClearCellAt(position.X, position.Y);
            }

            return grid;
        }
        
        private void firstAlgorithmNextButton_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                ManageFile loadSecondAlgorithmPath = new ManageFile();
                string[] loadPathOfAlgorithm = loadSecondAlgorithmPath.ReadingTextFile(FIRST_ALGORITHM_PATH);
                string pathOfAlgorithm = loadPathOfAlgorithm[0];

                ManageFile mngBoardFile = new ManageFile();
                string[] newBoard = mngBoardFile.ReadingTextFile(NEW_BOARD_FILENAME);

                bool isBoardFilled = newBoard.IsContain(EMPTY_BOX);
                if (!isBoardFilled)
                {
                    StateOfBoard stateOfBoard = new StateOfBoard();
                    stateOfBoard.MatrixFilledEvent += new StateOfBoard.MatrixEventHandler(stateOfBoard_MatrixFilledEvent);
                    stateOfBoard.NotifyIsBoardFilled(true, newBoard.ToArrayOfChars());
                }

                if (newBoard.Length > this.rows)
                {
                    int numberOfRowsInFile = newBoard.Length;
                    int numberOfNewLines = numberOfRowsInFile - this.rows;
                    string[] readLinesAfterBoard = new string[numberOfNewLines];

                    for (int i = 0; i < numberOfNewLines; i++)
                    {
                        readLinesAfterBoard[i] = newBoard[numberOfRowsInFile + i];
                    }

                    // Check new lines
                    if (readLinesAfterBoard[0] == Notifications.ERROR_MESSAGE)
                    {
                        string message = null;

                        for (int i = 1; i < readLinesAfterBoard.Length; i++)
                        {
                            message += readLinesAfterBoard[i];
                        }

                        throw new InvalidBoardException(message);
                    }
                    else
                    {
                        string message = null;

                        for (int i = 0; i < readLinesAfterBoard.Length; i++)
                        {
                            message += readLinesAfterBoard[i];
                        }

                        MessageBox.Show(message);
                        return;
                    }
                }

                Playing(this.currentPawn.ID, pathOfAlgorithm, this.firstAlgorithmScores);

                if (this.currentPawn.ID == FIGURE_A)
                {
                    this.currentPawn = new GreenPawn();
                }
                else
                {
                    this.currentPawn = new RedPawn();
                }

                this.secondAlgorithmNextButton.Visibility = System.Windows.Visibility.Visible;
                this.firstAlgorithmNextButton.Visibility = System.Windows.Visibility.Hidden;
            }
            catch (InvalidBoardException)
            {
                RedPawn redPawn = new RedPawn();
                string message = null;

                if (this.currentPawn.GetType() == redPawn.GetType())
                {
                    message = "The algorithm who playing with 'Green pawns' submit wrong board!!!\n";
                    message += "The winner is the algorithm who plays with 'Red pawns'!!!\n";
                    message += "The result is: " + this.rows * this.columns + " - 0 for 'Red pawns'!";
                }
                else
                {
                    message = "The algorithm who playing with 'Red pawns' submit wrong board!!!\n";
                    message += "The winner is the algorithm who plays with 'Green pawns'!!!\n";
                    message += "The result is: " + this.rows * this.columns + " - 0 for 'Green pawns'!";
                }

                MessageBox.Show(message);

                int exitCode = Environment.ExitCode;
                Environment.Exit(exitCode);
            }
            catch (FileNotFoundException fileNotFoundEx)
            {
                string fileName = fileNotFoundEx.FileName;
                string message = "The file with name '" + fileName + "' is missing!!!";
                MessageBox.Show(message);

                int exitCode = Environment.ExitCode;
                Environment.Exit(exitCode);
            }
        }

        private void AddPointsToScorePanel(ref ScoreControl scorePanel, byte points)
        {
            int currentPoints = int.Parse(scorePanel.scoreTextBlock.Text);
            currentPoints = currentPoints + points;

            scorePanel.scoreTextBlock.Text = currentPoints.ToString();
        }

        public virtual byte GetGreatestLengthAtGivenStartPosition(char[,] newBoard, char currentFigure, System.Drawing.Point position)
        {
            int row = position.X;
            int column = position.Y;

            AnalyzeBoard analyzeBoard = new AnalyzeBoard(newBoard);
            System.Drawing.Point[] positionsOfRightDiagonal = analyzeBoard.RightDiagonal(row, column, MAX_LENGTH_OF_EMPTY_BOXES, currentFigure);
            System.Drawing.Point[] positionsOfLeftDiagonal = analyzeBoard.LeftDiagonal(row, column, MAX_LENGTH_OF_EMPTY_BOXES, currentFigure);
            System.Drawing.Point[] positionsOflementsHorizontal = analyzeBoard.Horizontal(row, column, MAX_LENGTH_OF_EMPTY_BOXES, currentFigure);
            System.Drawing.Point[] positionsOfVertical = analyzeBoard.Vertical(row, column, MAX_LENGTH_OF_EMPTY_BOXES, currentFigure);

            byte getMaxLenghtOfSequence = (byte)Math.Max(positionsOfLeftDiagonal.Length, positionsOfRightDiagonal.Length);
            getMaxLenghtOfSequence = (byte)Math.Max(getMaxLenghtOfSequence, positionsOflementsHorizontal.Length);
            getMaxLenghtOfSequence = (byte)Math.Max(getMaxLenghtOfSequence, positionsOfVertical.Length);

            return getMaxLenghtOfSequence;
        }

        private void SingleChangingOfPawnAtPosition(BasePawn pawn, byte row, byte column)
        {
            this.boardGrid.ClearCellAt(row, column);
            boardGrid.AddElementAtCell(pawn, row, columns);
        }

        private void MultipleChangingOfPawnAtPosition(BasePawn pawn, System.Drawing.Point[] positions)
        {
            foreach (System.Drawing.Point position in positions)
            {
                this.boardGrid.ClearCellAt(position.X, position.Y);
                boardGrid.AddElementAtCell(pawn, position.X, position.Y);   
            }
        }

        void stateOfBoard_MatrixFilledEvent(object sender, MatrixFilledArgs args)
        {
            bool isBoardFilled = (bool)sender;

            if (isBoardFilled)
            {
                File.Delete(FIRST_ALGORITHM_PATH);
                File.Delete(SECOND_ALGORITHM_PATH);
                File.Delete(OLD_BOARD_FILENAME);
                File.Delete(NEW_BOARD_FILENAME);
                File.Delete(TEMP_BOARD_FILENAME);

                BasePawn pawn = new BasePawn();
                BasePawn leftGridPawn = GetElement(this.leftGrid, pawn, 1, 0) as BasePawn;

                ScoreControl scoreControl = new ScoreControl();
                ScoreControl leftScoreControl = GetElement(this.leftGrid, scoreControl, 2, 0) as ScoreControl;
                ScoreControl rightScoreControl = GetElement(this.rightGrid, scoreControl, 2, 0) as ScoreControl;

                RedPawn redPawn = new RedPawn();
                string message = null;

                if (leftGridPawn.GetType() == redPawn.GetType())
                {
                    message = "RedPawn - GreenPawn \n";
                    message += leftScoreControl.scoreTextBlock.Text + " - " + rightScoreControl.scoreTextBlock.Text;
                }
                else
                {
                    message = "RedPawn - GreenPawn \n";
                    message += rightScoreControl.scoreTextBlock.Text + " - " + leftScoreControl.scoreTextBlock.Text;
                }

                MessageBox.Show(message);

                //this.Close();
                int exitCode = Environment.ExitCode;
                Environment.Exit(exitCode);
            }
        }
        
        private void secondAlgorithmNextButton_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                ManageFile loadSecondAlgorithmPath = new ManageFile();
                string[] loadPathOfAlgorithm = loadSecondAlgorithmPath.ReadingTextFile(SECOND_ALGORITHM_PATH);
                string pathOfAlgorithm = loadPathOfAlgorithm[0];
                                
                ManageFile mngBoardFile = new ManageFile();                
                string[] newBoard = mngBoardFile.ReadingTextFile(NEW_BOARD_FILENAME);

                bool isBoardFilled = newBoard.IsContain(EMPTY_BOX);
                if (!isBoardFilled)
                {
                    StateOfBoard stateOfBoard = new StateOfBoard();
                    stateOfBoard.MatrixFilledEvent += new StateOfBoard.MatrixEventHandler(stateOfBoard_MatrixFilledEvent);
                    stateOfBoard.NotifyIsBoardFilled(true, newBoard.ToArrayOfChars());
                }

                if (newBoard.Length > this.rows)
                {
                    int numberOfRowsInFile = newBoard.Length;
                    int numberOfNewLines = numberOfRowsInFile - this.rows;
                    string[] readLinesAfterBoard = new string[numberOfNewLines];

                    for (int i = 0; i < numberOfNewLines; i++)
                    {
                        readLinesAfterBoard[i] = newBoard[this.rows + i];
                    }

                    // Check new lines
                    if (readLinesAfterBoard[0] == Notifications.ERROR_MESSAGE)
                    {
                        string message = null;

                        for (int i = 1; i < readLinesAfterBoard.Length; i++)
                        {
                            message += readLinesAfterBoard[i];
                        }

                        throw new InvalidBoardException(message);
                    }
                    else
                    {
                        string message = null;

                        for (int i = 0; i < readLinesAfterBoard.Length; i++)
                        {
                            message += readLinesAfterBoard[i] + "\n";
                        }

                        MessageBox.Show(message);
                        return;
                    }
                }

                Playing(this.currentPawn.ID, pathOfAlgorithm, this.secondAlgorithmScores);

                if (this.currentPawn.ID == FIGURE_A)
                {
                    this.currentPawn = new GreenPawn();
                }
                else
                {
                    this.currentPawn = new RedPawn();
                }

                this.firstAlgorithmNextButton.Visibility = System.Windows.Visibility.Visible;
                this.secondAlgorithmNextButton.Visibility = System.Windows.Visibility.Hidden;
            }
            catch (InvalidBoardException)
            {
                RedPawn redPawn = new RedPawn();
                string message = null;

                if (this.currentPawn.GetType() == redPawn.GetType())
                {
                    message = "The algorithm who playing with 'Green pawns' submit wrong board!!!\n";
                    message += "The winner is the algorithm who plays with 'Red pawns'!!!\n";
                    message += "The result is: " + this.rows * this.columns + " - 0 for 'Red pawns!'";
                }
                else
                {
                    message = "The algorithm who playing with 'Red pawns' submit wrong board!!!\n";
                    message += "The winner is the algorithm who plays with 'Green pawns'!!!\n";
                    message += "The result is: " + this.rows * this.columns + " - 0 for 'Green pawns!'";
                }

                MessageBox.Show(message);

                int exitCode = Environment.ExitCode;
                Environment.Exit(exitCode);
            }
            catch (FileNotFoundException fileNotFoundEx)
            {
                string fileName = fileNotFoundEx.FileName;
                string message = "The file with name '" + fileName + "' is missing!!!";
                MessageBox.Show(message);

                int exitCode = Environment.ExitCode;
                Environment.Exit(exitCode);
            }
        }

        private void Playing(char figureOnTurn, string pathOfAlgorithm, ScoreControl scorePanel)
        {
            ManageFile mngBoardFile = new ManageFile();
            char[,] oldBoard = mngBoardFile.ReadingTextFile(OLD_BOARD_FILENAME).ToArrayOfChars();
            char[,] newBoard = mngBoardFile.ReadingTextFile(NEW_BOARD_FILENAME).ToArrayOfChars();
            
            RedPawn redPawn = new RedPawn();
            GreenPawn greenPawn = new GreenPawn();
            DarkRedPawn darkRedPawn = new DarkRedPawn();
            DarkGreenPawn darkGreenPawn = new DarkGreenPawn();

            if (figureOnTurn == FIGURE_A)
            {
                BoardValidations checkBoard = new BoardValidations();
                checkBoard.BoardValidationProcess(newBoard, oldBoard, FIGURE_B);

                System.Drawing.Point[] positionsOfEnemyNewElements = DifferencesBetweenTwoMatrices.GetPositionsOfAllDifferences(oldBoard, newBoard);

                this.boardGrid = MultipleClearingOfCells(this.boardGrid, positionsOfEnemyNewElements);

                foreach (System.Drawing.Point position in positionsOfEnemyNewElements)
                {
                    greenPawn = new GreenPawn();
                    this.boardGrid.AddElementAtCell(greenPawn, position.X, position.Y);
                }
            }
            else
            {
                BoardValidations checkBoard = new BoardValidations();
                checkBoard.BoardValidationProcess(newBoard, oldBoard, FIGURE_A);

                System.Drawing.Point[] positionsOfEnemyNewElements = DifferencesBetweenTwoMatrices.GetPositionsOfAllDifferences(oldBoard, newBoard);

                this.boardGrid = MultipleClearingOfCells(this.boardGrid, positionsOfEnemyNewElements);

                foreach (System.Drawing.Point position in positionsOfEnemyNewElements)
                {
                    redPawn = new RedPawn();
                    this.boardGrid.AddElementAtCell(redPawn, position.X, position.Y);
                }
            }

            File.Delete(TEMP_BOARD_FILENAME);
            StartExecutionOfAlgorithm(pathOfAlgorithm, this.currentPawn.ID, NEW_BOARD_FILENAME, TEMP_BOARD_FILENAME);

            // Povtaria se
            ManageFile mngFile = new ManageFile();
            string[] tempBoard = mngFile.ReadingTextFile(TEMP_BOARD_FILENAME); 

            if (tempBoard.Length <= this.rows)
            {
                if (figureOnTurn == FIGURE_A)
                {
                    // Count new elements in Board.
                    int numberOfNewElements = DifferencesBetweenTwoMatrices.CountAllDifferences(newBoard, tempBoard.ToArrayOfChars());
                    // Adding number of elements as points to score panel
                    AddPointsToScorePanel(ref scorePanel, (byte)numberOfNewElements);

                    System.Drawing.Point[] positionsOfNewElementsInBoard = DifferencesBetweenTwoMatrices.GetPositionsOfAllDifferences(newBoard, tempBoard.ToArrayOfChars());

                    this.boardGrid = MultipleClearingOfCells(this.boardGrid, positionsOfNewElementsInBoard);

                    foreach (System.Drawing.Point position in positionsOfNewElementsInBoard)
                    {
                        darkRedPawn = new DarkRedPawn();
                        this.boardGrid.AddElementAtCell(darkRedPawn, position.X, position.Y);
                    }
                }
                else
                {
                    // Count new elements in Board.
                    int numberOfNewElements = DifferencesBetweenTwoMatrices.CountAllDifferences(newBoard, tempBoard.ToArrayOfChars());
                    // Adding number of elements as points to score panel
                    AddPointsToScorePanel(ref scorePanel, (byte)numberOfNewElements);

                    System.Drawing.Point[] positionsOfNewElementsInBoard = DifferencesBetweenTwoMatrices.GetPositionsOfAllDifferences(newBoard, tempBoard.ToArrayOfChars());

                    this.boardGrid = MultipleClearingOfCells(this.boardGrid, positionsOfNewElementsInBoard);

                    foreach (System.Drawing.Point position in positionsOfNewElementsInBoard)
                    {
                        darkGreenPawn = new DarkGreenPawn();
                        this.boardGrid.AddElementAtCell(darkGreenPawn, position.X, position.Y);
                    }
                }
            }

            File.Delete(OLD_BOARD_FILENAME);
            mngFile.WritingInFile(OLD_BOARD_FILENAME, newBoard);

            File.Delete(NEW_BOARD_FILENAME);
            for (int i = 0; i < tempBoard.Length; i++)
            {
                mngFile.WritingInFile(NEW_BOARD_FILENAME, tempBoard[i]);
            }
        }

        private void backButton_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            File.Delete(OLD_BOARD_FILENAME);
            File.Delete(NEW_BOARD_FILENAME);
            File.Delete(TEMP_BOARD_FILENAME);

            Window parentWindow = Application.Current.MainWindow;

            if (parentWindow != null)
            {
                if (parentWindow.IsLoaded)
                {
                    if (parentWindow.Visibility == System.Windows.Visibility.Hidden)
                    {
                        parentWindow.Visibility = System.Windows.Visibility.Visible;
                        this.Hide();
                        return;
                    }
                    else
                    {
                        parentWindow.Focus();
                        this.Hide();
                        return;
                    }
                }
            }

            parentWindow = new Game123();
            parentWindow.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            File.Delete(OLD_BOARD_FILENAME);
            File.Delete(NEW_BOARD_FILENAME);
            File.Delete(TEMP_BOARD_FILENAME);

            int exitCode = Environment.ExitCode;
            Environment.Exit(exitCode);
        }
    }
}