using System;
using System.Windows.Media;

namespace SimulatorOfGame123
{
    /// <summary>
    /// Interaction logic for DarkRedPawn.xaml
    /// </summary>
    public partial class DarkRedPawn : BasePawn
    {
        private char id = 'A';

        public DarkRedPawn()
        {
            GradientStop colorInTheMiddle = new GradientStop(Color.FromArgb(255, 159, 7, 7), 0.388);
            GradientStop colorBetweenMiddleAndEnd = new GradientStop(Color.FromArgb(255, 69, 15, 3), 0.892);
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
