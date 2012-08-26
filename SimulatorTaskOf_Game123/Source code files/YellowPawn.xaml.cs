using System;
using System.Windows.Media;

namespace SimulatorOfGame123
{
    /// <summary>
    /// Interaction logic for YellowPawn.xaml
    /// </summary>
    public partial class YellowPawn : BasePawn
    {
        private char id = '-';

        public YellowPawn()
        {
            GradientStop colorInTheMiddle = new GradientStop(Color.FromArgb(255, 255, 139, 0), 0.388);
            GradientStop colorBetweenMiddleAndEnd = new GradientStop(Color.FromArgb(255, 255, 179, 11), 0.892);
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