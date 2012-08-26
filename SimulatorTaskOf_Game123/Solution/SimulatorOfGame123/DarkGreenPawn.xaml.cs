using System;
using System.Windows.Media;

namespace SimulatorOfGame123
{
    /// <summary>
    /// Interaction logic for DarkGreenPawn.xaml
    /// </summary>
    public partial class DarkGreenPawn : BasePawn
    {
        private char id = 'B';

        public DarkGreenPawn()
        {
            GradientStop colorInTheMiddle = new GradientStop(Color.FromArgb(255, 6, 77, 3), 0.388);
            GradientStop colorBetweenMiddleAndEnd = new GradientStop(Color.FromArgb(255, 56, 110, 9), 0.892);
            GradientStop colorInTheEnd = new GradientStop(Colors.Black, 0.944);

            Initialization(this, colorInTheMiddle, colorBetweenMiddleAndEnd, colorInTheEnd);
        }

        public override char ID
        {
            get
            {
                return this.id;
            }
        }
    }
}
