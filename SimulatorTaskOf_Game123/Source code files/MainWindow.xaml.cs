using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using Microsoft.Win32;
using System.ComponentModel;

namespace SimulatorOfGame123
{
    /// <summary>
    /// Interaction logic for Game123.xaml
    /// </summary>
    public partial class Game123 : Window
    {
        private const string FIRST_ALGORITHM_PATH = "firstAlgorithmPath.txt";
        private const string SECOND_ALGORITHM_PATH = "secondAlgorithmPath.txt";
        private const int ERROR_FILE_NOT_FOUND = 2;
        private const int ERROR_ACCESS_DENIED = 5;
        private const string PATH_TO_ALGORITHMS_FILE = "pathToAlgorithms.txt";
        
        private BoardSettingsWindow boardSettingsWindow = null;

        private Point pp = new Point();
        private bool triger = false;
        
        public Game123()
        {
            this.InitializeComponent();
            // Insert code required on object creation below this point.
                        
            File.Delete(PATH_TO_ALGORITHMS_FILE);
        }
        
        private void Image_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            pp = e.GetPosition(null);
            triger = true;
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (triger)
            {
                Point newPoint = e.GetPosition(null);
                this.Top += newPoint.Y - pp.Y;
                this.Left += newPoint.X - pp.X;
            }
        }

        private void Image_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            triger = false;
        }

        private void xButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (File.Exists(FIRST_ALGORITHM_PATH))
            {
                File.Delete(FIRST_ALGORITHM_PATH);
            }

            if (File.Exists(SECOND_ALGORITHM_PATH))
            {
                File.Delete(SECOND_ALGORITHM_PATH);
            }

            Process process = Process.GetCurrentProcess();
            process.Kill();
        }

        private void minimizeButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void Grid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // TODO: Add event handler implementation here.
        }

        private void xButton_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBlock obj = FindChild<TextBlock>(xButton, "TextField");
            obj.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            Ellipse ellipse = FindChild<Ellipse>(xButton, "XButtonEllipse");
            ellipse.Opacity = 0.2;
        }

        private void xButton_MouseLeave(object sender, MouseEventArgs e)
        {
            TextBlock obj = FindChild<TextBlock>(this, "TextField");
            obj.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            Ellipse ellipse = FindChild<Ellipse>(xButton, "XButtonEllipse");
            ellipse.Opacity = 0.85;
        }

        public static T FindChild<T>(DependencyObject depObj, string childName)
            where T : DependencyObject
        {
            if (depObj == null)
            {
                return null;
            }

            if (depObj is T && ((FrameworkElement)depObj).Name == childName)
            {
                return depObj as T;
            }

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(depObj, i);

                T obj = FindChild<T>(child, childName);

                if (obj != null)
                {
                    return obj;
                }
            }

            return null;
        }

        private void minimizeButton_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBlock obj = FindChild<TextBlock>(minimizeButton, "MinimizeButtonText");
            obj.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            Ellipse ellipse = FindChild<Ellipse>(minimizeButton, "MinimizeBGEllipse");
            ellipse.Opacity = 0.2;
        }

        private void minimizeButton_MouseLeave(object sender, MouseEventArgs e)
        {
            TextBlock obj = FindChild<TextBlock>(minimizeButton, "MinimizeButtonText");
            obj.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            Ellipse ellipse = FindChild<Ellipse>(minimizeButton, "MinimizeBGEllipse");
            ellipse.Opacity = 0.85;
        }

        private void FirstAlgorithmButton_Click(object sender, RoutedEventArgs e)
        {
            //Process firstAlgorithm = new Process();
            OpenFileDialog openFileDlg = new OpenFileDialog();

            try
            {
                openFileDlg.DefaultExt = ".exe";
                openFileDlg.Filter = "Executable files (.exe)|*.exe";

                Nullable<bool> result = openFileDlg.ShowDialog();

                if (result == true)
                {
                    string fileName = openFileDlg.FileName;

                    if (fileName != null)
                    {
                        File.Delete(FIRST_ALGORITHM_PATH);
                        ManageFile savePathOfAlgorithms = new ManageFile();
                        savePathOfAlgorithms.WritingInFile(FIRST_ALGORITHM_PATH, fileName);
                    }
                }
            }
            catch (Win32Exception ex)
            {
                if (ex.NativeErrorCode == ERROR_FILE_NOT_FOUND)
                {
                    MessageBox.Show("File with name '" + openFileDlg.FileName + "' not found!");
                }
                else if (ex.NativeErrorCode == ERROR_ACCESS_DENIED)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void SecondAlgorithmButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();

            try
            {
                openFileDlg.DefaultExt = ".exe";
                openFileDlg.Filter = "Executable files (.exe)|*.exe";

                Nullable<bool> result = openFileDlg.ShowDialog();

                if (result == true)
                {
                    string fileName = openFileDlg.FileName;

                    if (fileName != null)
                    {
                        File.Delete(SECOND_ALGORITHM_PATH);
                        ManageFile mngFile = new ManageFile();
                        mngFile.WritingInFile(SECOND_ALGORITHM_PATH, fileName);
                    }
                }
            }
            catch (Win32Exception ex)
            {
                if (ex.NativeErrorCode == ERROR_FILE_NOT_FOUND)
                {
                    MessageBox.Show("File with name '" + openFileDlg.FileName + "' not found!");
                }
                else if (ex.NativeErrorCode == ERROR_ACCESS_DENIED)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard sbShowNextButton = this.FindResource("sbShowNextButton") as Storyboard;
            Storyboard.SetTarget(sbShowNextButton, this.NextButton);
            sbShowNextButton.Begin(this);
        }

        private void NextButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard sbHideNextButton = this.FindResource("sbHideNextButton") as Storyboard;
            Storyboard.SetTarget(sbHideNextButton, this.NextButton);
            sbHideNextButton.Begin(this);
        }
        
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            bool isFileOfFirstAlgorithmExist = File.Exists(FIRST_ALGORITHM_PATH);
            bool isFileOfSecondAlgorithmExist = File.Exists(SECOND_ALGORITHM_PATH);
            
            if (!isFileOfFirstAlgorithmExist)
            {
                string message = "Please load the first algorithm from 'First algorithm' button!";
                MessageBox.Show(message);
                return;
            }
            
            if (!isFileOfSecondAlgorithmExist)
            {
                string message = "Please load the second algorithm from 'Second algorithm' button!";
                MessageBox.Show(message);
                return;
            }

            ManageFile mngFile = new ManageFile();
            string[] readFirstAlgorithmFile = mngFile.ReadingTextFile(FIRST_ALGORITHM_PATH);
            string[] readSecondAlgorithmFile = mngFile.ReadingTextFile(SECOND_ALGORITHM_PATH);

            if ((readFirstAlgorithmFile.Length > 1) || 
                (readFirstAlgorithmFile.Length == 0))
            {
                string message = "The file with name '" + FIRST_ALGORITHM_PATH + "' is changed!\n" +
                    "Please load the first algorithm from 'First algorithm' button!";
                MessageBox.Show(message);
                return;
            }

            if ((readSecondAlgorithmFile.Length > 1) ||
                (readSecondAlgorithmFile.Length == 0))
            {
                string message = "The file with name '" + SECOND_ALGORITHM_PATH + "' is changed!\n" + 
                    "Please load the second algorithm from 'Second algorithm' button!";
                MessageBox.Show(message);
                return;
            }

            string getExtensionOfFirstAlgorithm = System.IO.Path.GetExtension(readFirstAlgorithmFile[0]);
            string getExtensionOfSecondAlgorithm = System.IO.Path.GetExtension(readFirstAlgorithmFile[0]);

            if (getExtensionOfFirstAlgorithm != ".exe")                
            {
                MessageBox.Show("Please load valid executable file for the First algorithm!!!");

                return;
            }

            if (getExtensionOfSecondAlgorithm != ".exe")
            {
                MessageBox.Show("Please load valid executable file for the Second algorithm!!!");

                return;
            }

            this.Hide();

            if (this.boardSettingsWindow != null)
            {
                if (this.boardSettingsWindow.Visibility == System.Windows.Visibility.Hidden)
                {
                    this.boardSettingsWindow.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    this.boardSettingsWindow.Focus();
                }

                return;
            }

            boardSettingsWindow = new BoardSettingsWindow();
            boardSettingsWindow.Show();
        }
    }
}