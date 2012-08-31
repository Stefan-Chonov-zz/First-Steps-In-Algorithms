﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Traff0
{
    public partial class WindingsInfoForm : Form
    {
        public WindingsInfoForm()
        {
            InitializeComponent();

            this.SecondaryWindingsDiameterList.Add(this.firstWindingThicknessOfWireLabel);
            this.SecondaryWindingsDiameterList.Add(this.secondWindingThicknessOfWireLabel);
            this.SecondaryWindingsDiameterList.Add(this.thirdWindingThicknessOfWireLabel);
            this.SecondaryWindingsDiameterList.Add(this.fourthWindingThicknessOfWireLabel);

            this.SecondaryWindingsNumberOfTurnsList.Add(this.firstWindingNumberOfTurnsLabel);
            this.SecondaryWindingsNumberOfTurnsList.Add(this.secondWindingNumberOfTurnsLabel);
            this.SecondaryWindingsNumberOfTurnsList.Add(this.thirdWindingNumberOfTurnsLabel);
            this.SecondaryWindingsNumberOfTurnsList.Add(this.fourthWindingNumberOfTurnsLabel);
        }
        
        // Primary Winding
        public string PrimaryWindingVoltage
        {
            get
            {
                return this.primaryWindingVoltageLabel.Text;
            }
            set
            {
                this.primaryWindingVoltageLabel.Text = value;
            }
        }

        public string PrimaryWindingAmperage
        {
            get
            {
                return this.primaryWindingAmperageLabel.Text;
            }
            set
            {
                this.primaryWindingAmperageLabel.Text = value;
            }
        }

        public string PrimaryWindingDensity
        {
            get
            {
                return this.primaryWindingDensityLabel.Text;
            }
            set
            {
                this.primaryWindingDensityLabel.Text = value;
            }
        }

        public string PrimaryWindingThicknessOfWire
        {
            get
            {
                return this.primaryWindingThicknessOfWireLabel.Text;
            }
            set
            {
                this.primaryWindingThicknessOfWireLabel.Text = value;
            }
        }

        public string PrimaryWindingNumberOfTurns
        {
            get
            {
                return this.primaryWindingNumberOfTurnsLabel.Text;
            }
            set
            {
                this.primaryWindingNumberOfTurnsLabel.Text = value;
            }
        }

        // First Winding
        public string FirstWindingVoltage
        {
            get
            {
                return this.firstWindingVoltageLabel.Text;
            }
            set
            {
                this.firstWindingVoltageLabel.Text = value;
            }
        }

        public string FirstWindingAmperage
        {
            get
            {
                return this.firstWindingAmperageLabel.Text;
            }
            set
            {
                this.firstWindingAmperageLabel.Text = value;
            }
        }

        public string FirstWindingDensity
        {
            get
            {
                return this.firstWindingDensityLabel.Text;
            }
            set
            {
                this.firstWindingDensityLabel.Text = value;
            }
        }

        public string FirstWindingThicknessOfWire
        {
            get
            {
                return this.firstWindingThicknessOfWireLabel.Text;
            }
            set
            {
                this.firstWindingThicknessOfWireLabel.Text = value;
            }
        }

        public string FirstWindingNumberOfTurns
        {
            get
            {
                return this.firstWindingNumberOfTurnsLabel.Text;
            }
            set
            {
                this.firstWindingNumberOfTurnsLabel.Text = value;
            }
        }

        // Second Winding
        public string SecondWindingVoltage
        {
            get
            {
                return this.secondWindingVoltageLabel.Text;
            }
            set
            {
                this.secondWindingVoltageLabel.Text = value;
            }
        }

        public string SecondWindingAmperage
        {
            get
            {
                return this.secondWindingAmperageLabel.Text;
            }
            set
            {
                this.secondWindingAmperageLabel.Text = value;
            }
        }

        public string SecondWindingDensity
        {
            get
            {
                return this.secondWindingDensityLabel.Text;
            }
            set
            {
                this.secondWindingDensityLabel.Text = value;
            }
        }

        public string SecondWindingThicknessOfWire
        {
            get
            {
                return this.secondWindingThicknessOfWireLabel.Text;
            }
            set
            {
                this.secondWindingThicknessOfWireLabel.Text = value;
            }
        }

        public string SecondWindingNumberOfTurns
        {
            get
            {
                return this.secondWindingNumberOfTurnsLabel.Text;
            }
            set
            {
                this.secondWindingNumberOfTurnsLabel.Text = value;
            }
        }

        // Third Winding
        public string ThirdWindingVoltage
        {
            get
            {
                return this.thirdWindingVoltageLabel.Text;
            }
            set
            {
                this.thirdWindingVoltageLabel.Text = value;
            }
        }

        public string ThirdWindingAmperage
        {
            get
            {
                return this.thirdWindingAmperageLabel.Text;
            }
            set
            {
                this.thirdWindingAmperageLabel.Text = value;
            }
        }

        public string ThirdWindingDensity
        {
            get
            {
                return this.thirdWindingDensityLabel.Text;
            }
            set
            {
                this.thirdWindingDensityLabel.Text = value;
            }
        }

        public string ThirdWindingThicknessOfWire
        {
            get
            {
                return this.thirdWindingThicknessOfWireLabel.Text;
            }
            set
            {
                this.thirdWindingThicknessOfWireLabel.Text = value;
            }
        }

        public string ThirdWindingNumberOfTurns
        {
            get
            {
                return this.thirdWindingNumberOfTurnsLabel.Text;
            }
            set
            {
                this.thirdWindingNumberOfTurnsLabel.Text = value;
            }
        }

        // Fourth Winding
        public string FourthWindingVoltage
        {
            get
            {
                return this.fourthWindingVoltageLabel.Text;
            }
            set
            {
                this.fourthWindingVoltageLabel.Text = value;
            }
        }

        public string FourthWindingAmperage
        {
            get
            {
                return this.fourthWindingAmperageLabel.Text;
            }
            set
            {
                this.fourthWindingAmperageLabel.Text = value;
            }
        }

        public string FourthWindingDensity
        {
            get
            {
                return this.fourthWindingDensityLabel.Text;
            }
            set
            {
                this.fourthWindingDensityLabel.Text = value;
            }
        }

        public string FourthWindingThicknessOfWire
        {
            get
            {
                return this.fourthWindingThicknessOfWireLabel.Text;
            }
            set
            {
                this.fourthWindingThicknessOfWireLabel.Text = value;
            }
        }

        public string FourthWindingNumberOfTurns
        {
            get
            {
                return this.fourthWindingNumberOfTurnsLabel.Text;
            }
            set
            {
                this.fourthWindingNumberOfTurnsLabel.Text = value;
            }
        }

        private void titleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            this.trigger = true;
            this.pp = new Point(e.X, e.Y);
        }
               
        private void titleLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (trigger)
            {
                this.Top += e.Y - pp.Y;
                this.Left += e.X - pp.X;
            }
        }

        private void titleLabel_MouseUp(object sender, MouseEventArgs e)
        {
            this.trigger = false;
        }
        
        private void closeButtonLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool trigger;
        private Point pp;

        public List<Label> SecondaryWindingsDiameterList = new List<Label>();
        public List<Label> SecondaryWindingsNumberOfTurnsList = new List<Label>();

        public Point XButtonPosition 
        {
            set
            {
                this.closeButtonLabel.Location = value;
            }
        }

        public Size TitleSize
        {
            set
            {
                this.titleLabel.Size = value;
            }
        }

        public List<Point> WindowSizes = new List<Point>
        {
            new Point(341, 159),
            new Point(456, 159),
            new Point(571, 159),
            new Point(686, 159)
        };

        public List<Point> XButtonPositions = new List<Point>
        {
            new Point(320, 3),
            new Point(435, 3),
            new Point(550, 3),
            new Point(664, 3)
        };
    }
}
