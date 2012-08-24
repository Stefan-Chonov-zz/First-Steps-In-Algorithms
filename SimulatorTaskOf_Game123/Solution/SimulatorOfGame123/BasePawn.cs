using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace SimulatorOfGame123
{
    public partial class BasePawn : UserControl
    {
        private char id = ' ';

        public UserControl Initialization(
            UserControl userControl, GradientStop colorInTheMiddle, 
            GradientStop colorBetweenMiddleAndEndOfEllipse, GradientStop colorInTheEnd)
        {
            userControl.Height = 25;
            userControl.Width = 25;

            Grid grid = new Grid();
            grid.Name = "LayoutRoot";
            grid.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            grid.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            grid.Height = 25;
            grid.Width = 25;

            Ellipse ellipse = new Ellipse();
            ellipse.Stroke = Brushes.Black;
            ellipse.StrokeMiterLimit = 0;
            ellipse.StrokeThickness = 0;

            RadialGradientBrush radianGradientBrush = new RadialGradientBrush();
            radianGradientBrush.GradientStops.Add(colorInTheMiddle);//new GradientStop(Color.FromArgb(255, 194, 7, 7), 0.259));
            radianGradientBrush.GradientStops.Add(colorBetweenMiddleAndEndOfEllipse);//new GradientStop(Color.FromArgb(255, 255, 54, 9), 0.892));
            radianGradientBrush.GradientStops.Add(colorInTheEnd);//new GradientStop(Colors.Black, 0.944));

            ellipse.Fill = radianGradientBrush;

            DropShadowEffect dropShadowEffect = new DropShadowEffect();
            dropShadowEffect.BlurRadius = 10;
            dropShadowEffect.Color = Colors.White;
            dropShadowEffect.ShadowDepth = 0;
            dropShadowEffect.Direction = 435;

            ellipse.Effect = dropShadowEffect;

            Ellipse reflectedEllipse = new Ellipse();
            reflectedEllipse.Margin = new Thickness(0.375, 3.834, 10.375, 0);
            reflectedEllipse.Stroke = Brushes.Black;
            reflectedEllipse.StrokeThickness = 0;
            reflectedEllipse.StrokeMiterLimit = 0;
            reflectedEllipse.RenderTransformOrigin = new Point(0.5, 0.5);
            reflectedEllipse.Opacity = 0.645;
            reflectedEllipse.Height = 7.5;
            reflectedEllipse.VerticalAlignment = System.Windows.VerticalAlignment.Top;

            LinearGradientBrush linearGradientBrush = new LinearGradientBrush();
            linearGradientBrush.StartPoint = new Point(0.5, 0);
            linearGradientBrush.EndPoint = new Point(0.5, 1);
            
            GradientStop gradientStop = new GradientStop();
            gradientStop.Offset = 1;

            GradientStop gradientStop2 = new GradientStop();
            gradientStop2.Color = Colors.White;
            gradientStop2.Offset = 0.026;

            linearGradientBrush.GradientStops.Add(gradientStop);
            linearGradientBrush.GradientStops.Add(gradientStop2);

            reflectedEllipse.Fill = linearGradientBrush;

            RotateTransform rotateTransform = new RotateTransform();
            rotateTransform.Angle = -44.77;

            reflectedEllipse.RenderTransform = rotateTransform;

            grid.Children.Add(ellipse);
            grid.Children.Add(reflectedEllipse);

            userControl.Content = grid;

            return userControl;
        }
        
        public virtual char ID
        {
            get
            {
                return this.id;
            }
        }
    }
}