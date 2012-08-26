using System;
using System.Windows.Media;

namespace SimulatorOfGame123
{
    /// <summary>
    /// Interaction logic for GreenPawn.xaml
    /// </summary>
    public partial class GreenPawn : BasePawn
    {
        private char id = 'B';

        public GreenPawn()
        {
            GradientStop colorInTheMiddle = new GradientStop(Color.FromArgb(255, 13, 194, 7), 0.918);
            GradientStop colorBetweenMiddleAndEnd = new GradientStop(Color.FromArgb(255, 91, 165, 6), 0.302);
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
