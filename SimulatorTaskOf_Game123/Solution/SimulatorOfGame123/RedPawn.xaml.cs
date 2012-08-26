using System;
using System.Windows.Media;

namespace SimulatorOfGame123
{
    /// <summary>
    /// Interaction logic for RedPawn.xaml
    /// </summary>
    public class RedPawn : BasePawn
    {
        private readonly char id = 'A';

        public RedPawn()
        {
            GradientStop colorInTheMiddle = new GradientStop(Color.FromArgb(255, 194, 7, 7), 0.259);
            GradientStop colorBetweenMiddleAndEnd = new GradientStop(Color.FromArgb(255, 255, 54, 9), 0.892);
            GradientStop colorInTheEnd = new GradientStop(Colors.Black, 0944);

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