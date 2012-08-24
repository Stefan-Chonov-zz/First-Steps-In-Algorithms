using System;
using System.Windows.Controls;

namespace SimulatorOfGame123
{
	/// <summary>
	/// Interaction logic for ScoreControl.xaml
	/// </summary>
	public partial class ScoreControl : UserControl
	{
        public ScoreControl()
		{			
			this.InitializeComponent();
			this.scoreTextBlock.FontSize = 32;
		}

        public string Scores
        {
            get
            {
                return this.scoreTextBlock.Text;
            }
            set
            {
                this.scoreTextBlock.Text = value;
            }
        }
	}
}