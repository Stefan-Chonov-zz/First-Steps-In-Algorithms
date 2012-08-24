using System;
using System.Windows.Controls;

namespace SimulatorOfGame123
{
    /// <summary>
    /// Interaction logic for StartButton.xaml
    /// </summary>
    public partial class StartButton : UserControl
    {
        public StartButton()
        {
            this.InitializeComponent();
        }

        public string Text
        {
            set
            {
                this.textField.Text = value;
            }
        }
    }
}