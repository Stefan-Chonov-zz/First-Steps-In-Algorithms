using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace SimulatorOfGame123
{
    /// <summary>
    /// Interaction logic for BoardSettingsWindow.xaml
    /// </summary>
    public partial class BoardSettingsWindow : Window
    {
        Window parentWindow = null;
        Point pp = new Point();
        bool trigger = false;
                
        public BoardSettingsWindow()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {            
            byte rows = 0;
            byte columns = 0;

            bool isRowsANumber = byte.TryParse(this.rowsTextBox.Text, out rows);
            bool isColumnsANumber = byte.TryParse(this.columnsTextBox.Text, out columns);
            
            if (!isRowsANumber)
            {
                ShowToolTip(this.rowsTextBox);
            }
            else if (!isColumnsANumber)
            {
                ShowToolTip(this.columnsTextBox);
            }
            else
            {
                bool isColumnsInBounds = ValidationOfNumbers.IsNumberInBounds(columns, 3, 20);
                bool isRowsInBounds = ValidationOfNumbers.IsNumberInBounds(rows, 3, 20);

                bool isRedPawnRadioButtonSet = (bool)this.redPawnRadioButton.IsChecked;
                bool isGreenPawnRadioButtonSet = (bool)this.greenPawnRadioButton.IsChecked;

                if (isColumnsInBounds && isRowsInBounds)
                {
                    if (isRedPawnRadioButtonSet)
                    {
                        BoardWindow boardWindow = new BoardWindow(rows, columns, this.redPawn);
                        boardWindow.Show();
                    }
                    else if(isGreenPawnRadioButtonSet)
                    {
                        BoardWindow boardWindow = new BoardWindow(rows, columns, this.greenPawn);
                        boardWindow.Show();
                    }

                    this.Visibility = System.Windows.Visibility.Hidden;
                }
                else if (!isRowsInBounds)
                {
                    ShowToolTip(this.rowsTextBox);
                }
                else
                {
                    ShowToolTip(this.columnsTextBox);
                }
            }
        }

        private void ShowToolTip(TextBox textBox)
        {
            ToolTip tt = ToolTipService.GetToolTip(textBox) as ToolTip;
            ToolTipService.SetPlacement(textBox, PlacementMode.Left);
            tt.IsOpen = true;

            textBox.ToolTip = tt;
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            pp = e.GetPosition(null);
            trigger = true;
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            trigger = false;
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (trigger)
            {
                Point newPositionCursor = e.GetPosition(null);

                this.Top += newPositionCursor.Y - pp.Y;
                this.Left += newPositionCursor.X - pp.X;
            }
        }

        private void redPawnBG_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.redPawnRadioButton.IsChecked = true;
        }

        private void greenPawnBG_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.greenPawnRadioButton.IsChecked = true;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.parentWindow = Application.Current.MainWindow;

            if (this.parentWindow != null)
            {
                if (this.parentWindow.IsLoaded)
                {
                    if (this.parentWindow.Visibility == System.Windows.Visibility.Hidden)
                    {
                        this.Hide();
                        this.parentWindow.Visibility = System.Windows.Visibility.Visible;
                        return;
                    }
                    else
                    {
                        this.parentWindow.Focus();
                        return;
                    }
                }
            }

            this.parentWindow = new Game123();
            this.parentWindow.Show();
        }

        private void rowsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox rowsTextBox = (TextBox)sender;
            string readRows = rowsTextBox.Text;

            byte rows = 0;
            bool isNumeric = byte.TryParse(readRows, out rows);

            if (!isNumeric)
            {
                this.rowsTextBox.Text = String.Empty;

                for (int i = 0; i < readRows.Length - 1; i++)
                {
                    this.rowsTextBox.Text += readRows[i];
                }
            }
            else
            {
                bool isRowsInBounds = ValidationOfNumbers.IsNumberInBounds(rows, 3, 20);

                if (!isRowsInBounds)
                {
                    ShowToolTip(this.rowsTextBox);
                }
                else
                {
                    HideToolTip(this.rowsTextBox);
                }
            }
        }

        private void columnsTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            TextBox columnsTextBox = (TextBox)sender;
            string readColumns = columnsTextBox.Text;

            byte columns = 0;
            bool isNumeric = byte.TryParse(readColumns, out columns);

            if (!isNumeric)
            {
                this.columnsTextBox.Text = String.Empty;

                for (int i = 0; i < readColumns.Length - 1; i++)
                {
                    this.columnsTextBox.Text += readColumns[i];
                }
            }
            else
            {
                bool isColumnsInBounds = ValidationOfNumbers.IsNumberInBounds(columns, 3, 20);

                if (!isColumnsInBounds)
                {
                    ShowToolTip(this.columnsTextBox);
                }
                else
                {
                    HideToolTip(this.columnsTextBox);
                }
            }
        }

        private void HideToolTip(TextBox textBox)
        {
            ToolTip toolTip = ToolTipService.GetToolTip(textBox) as ToolTip;
            if (toolTip != null)
            {
                if (toolTip.IsOpen)
                {
                    toolTip.IsOpen = false;
                    textBox.ToolTip = toolTip;
                }
            }
        }
    }
}