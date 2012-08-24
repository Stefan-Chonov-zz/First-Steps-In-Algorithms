using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Traff0
{
    public partial class Traff0Form : Form
    {
        public Traff0Form()
        {
            InitializeComponent();
        }

        private void secondaryWindingsTextBox_TextChanged(object sender, EventArgs e)
        {
            bool isWindingsAreNumber = int.TryParse(this.secondaryWindingsTextBox.Text.Trim(), out this.secondaryWindings);

            if (isWindingsAreNumber)
            {
                if ((this.secondaryWindings < 5) && (this.secondaryWindings > 0))
                {
                    if ((this.windingsInfoForm == null) || (this.windingsParametersForm == null))
                    {
                        this.voltageLabelTextBoxUserControl.Visible = true;
                        this.calculateButtonLabel.Visible = true;
                        this.resetButtonLabel.Visible = true;
                    }

                    LoadWindingsParametersForm();
                    this.windingsParametersForm.VoltageTextChanged += new TextChangedHandler(windingsParameterForm_VoltageTextChanged);
                    this.windingsParametersForm.AmperageTextChanged += new TextChangedHandler(windingsParameterForm_VoltageTextChanged);
                    this.windingsParametersForm.DensityTextChanged += new TextChangedHandler(windingsParameterForm_VoltageTextChanged);
                    this.windingsParametersForm.FormClosed += new FormClosedEventHandler(windingsParameterForm_FormClosed);
                    
                    LoadWindingsInfoForm();
                    this.windingsInfoForm.FormClosed += new FormClosedEventHandler(windingsInfoForm_FormClosed);

                    this.numberOfWindingsInfoLabel.Text = this.secondaryWindingsTextBox.Text;
                }
                else if (this.secondaryWindings == 0) 
                {
                    Reset();
                }
                else
                {
                    MessageBox.Show("Моля въведете за брой намотки число по малко от 5 !!!");
                }
            }
            else
            {
                if (this.secondaryWindingsTextBox.Text.Trim() != String.Empty)
                {
                    MessageBox.Show("Моля въвеждайте само цифри !!!");
                }

                Reset();
            }
        }

        private void LoadWindingsParametersForm()
        {
            if (this.windingsParametersForm == null)
            {
                this.windingsParametersForm = new WindingsParametersForm();
                windingsParametersForm.Size = new Size(this.windingsParametersForm.WindowSizes[this.secondaryWindings - 1]);
                windingsParametersForm.Location = new Point((this.Location.X - this.windingsParametersForm.Width), this.Location.Y);
                windingsParametersForm.Show();
            }
            else if (this.windingsParametersForm != null)
            {
                windingsParametersForm.Size = new Size(this.windingsParametersForm.WindowSizes[this.secondaryWindings - 1]);
                windingsParametersForm.Location = new Point((this.Location.X - this.windingsParametersForm.Width), this.Location.Y);
            }
        }

        private void LoadWindingsInfoForm()
        {
            if (this.windingsInfoForm == null)
            {
                this.windingsInfoForm = new WindingsInfoForm();
                this.windingsInfoForm.Size = new Size(this.windingsInfoForm.WindowSizes[this.secondaryWindings - 1]);
                this.windingsInfoForm.Location = new Point(((this.Location.X + this.Width) - this.windingsInfoForm.Width), (this.Location.Y - this.windingsInfoForm.Height));
                this.windingsInfoForm.TitleSize = new Size(this.windingsInfoForm.WindowSizes[this.secondaryWindings - 1]);
                this.windingsInfoForm.XButtonPosition = this.windingsInfoForm.XButtonPositions[this.secondaryWindings - 1];
                this.windingsInfoForm.Show();
            }
            else
            {
                windingsInfoForm.Size = new Size(this.windingsInfoForm.WindowSizes[this.secondaryWindings - 1]);
                windingsInfoForm.Location = new Point(((this.Location.X + this.Width) - this.windingsInfoForm.Width), (this.Location.Y - this.windingsInfoForm.Height));
                windingsInfoForm.TitleSize = new Size(this.windingsInfoForm.WindowSizes[this.secondaryWindings - 1]);
                windingsInfoForm.XButtonPosition = this.windingsInfoForm.XButtonPositions[this.secondaryWindings - 1];
            }
        }

        private void voltageLabelTextBoxUserControl_TextChanged(object aSender, EventArgs aEventArgs)
        {
            string voltage = (String)aSender;
            bool isVoltageAreNumber = float.TryParse(voltage.Trim(), out this.primaryVoltage);

            if (isVoltageAreNumber)
            {
                this.voltageInfoLabel.Text = voltage.Trim();
                this.windingsInfoForm.PrimaryWindingVoltage = voltage.Trim();
            }
            else
            {
                if (voltage.Trim() != String.Empty)
                {
                    string message = "Моля въвеждайте само цифри !!!";
                    MessageBox.Show(message);
                    this.voltageLabelTextBoxUserControl.TextBoxTextProperty = String.Empty;
                }
            }
        }

        void sectionLabelTextBox_TextChanged(object aSender, EventArgs aEventArgs)
        {
            string section = (String)aSender;
            bool isSectionAreNumber = float.TryParse(section.Trim(), out this.primarySection);

            if (isSectionAreNumber)
            {
                this.sectionInfoLabel.Text = section.Trim();
            }
            else
            {
                if (section != String.Empty)
                {
                    string message = "Моля въвеждайте само цифри !!!";
                    MessageBox.Show(message);
                    this.sectionLabelTextBox.Text = String.Empty;
                }
            }

            CalculateNumberOfTurns(this.secondaryWindings, VoltageList, this.primarySection, this.primaryInduction);
        }

        void inductionOptionalParameterUserControl_TextChanged(object aSender, TextChangedEventArgs aEvent)
        {
            string induction = (String)aSender;
            bool isInductionAreNumber = float.TryParse(induction.Trim(), out this.primaryInduction);

            if (isInductionAreNumber)
            {
                this.inductionInfoLabel.Text = induction.Trim();
            }
            else
            {
                if (induction != String.Empty)
                {
                    string message = "Моля въвеждайте само цифри !!!";
                    MessageBox.Show(message);
                    this.inductionInfoLabel.Text = String.Empty;
                }
            }

            CalculateNumberOfTurns(this.secondaryWindings, VoltageList, this.primarySection, this.primaryInduction);
        }

        void inductionOptionalParameterUserControl_CheckedChanged(object aSender, CheckChangedArgs aEventArgs)
        {
            bool isChecked = (Boolean)aSender;
            string induction = this.primaryInduction.ToString();

            if (isChecked)
            {
                this.inductionInfoLabel.Text = ConvertStringToFloat(induction).ToString();
            }
            else
            {
                this.inductionOptionalParameterUserControl.DefaultValue = "1,2";
            }
        }

        void densityOptionalParameterUserControl_TextChanged(object aSender, TextChangedEventArgs aEvent)
        {
            string density = (String)aSender;
            bool isDensityAreNumber = float.TryParse(density.Trim(), out this.primaryDensity);

            if (isDensityAreNumber)
            {
                this.densityInfoLabel.Text = ConvertStringToFloat(density).ToString();
            }
            else
            {
                if (density != String.Empty)
                {
                    string message = "Моля въвеждайте само цифри !!!";
                    MessageBox.Show(message);
                    this.densityOptionalParameterUserControl.DefaultValue = "2,55";
                }
            }

            // Calculating Diameter of Wire of Primary Winding
            float diameter = this.comCalFormulas.CalculatingDiameter(this.primaryAmperage, this.primaryDensity);
            diameter = (float)Math.Round(diameter * 100) / 100;

            bool isDiameterValid = IsDiameterValid(diameter);

            if (isDiameterValid)
            {
                diameter = this.comCalFormulas.PickNearestDiameterOfWire(diameter);
                this.windingsInfoForm.PrimaryWindingThicknessOfWire = diameter.ToString();

                CalculateSecondaryWindingsDiameterOfWire(this.AmperageList, this.DensityList);
            }
            else
            {
                return;
            }
        }

        private void densityOptionalParameterUserControl_CheckChanged(object aSender, CheckChangedArgs aEventArgs)
        {
            bool isChecked = (Boolean)aSender;
            string density = this.primaryDensity.ToString();

            if (isChecked)
            {
                this.densityInfoLabel.Text = ConvertStringToFloat(density).ToString();
            }
            else
            {
                this.densityOptionalParameterUserControl.DefaultValue = "2,55";
            }
        }

        private void CalculateNumberOfTurns(int secondaryWindings, List<float> voltageList, float section, float induction)
        {
            float k = 1.0f;

            // Calculating the number of turns of the Primary windings.            
            this.windingsInfoForm.PrimaryWindingNumberOfTurns = this.comCalFormulas.CalculatingNumberOfWindings(k, this.primaryVoltage, this.primarySection, this.primaryInduction).ToString();

            for (int i = 0; i < secondaryWindings; i++)
            {
                k = 1.05f;
                this.windingsInfoForm.SecondaryWindingsNumberOfTurnsList[i].Text = this.comCalFormulas.CalculatingNumberOfWindings(k, voltageList[i], section, induction).ToString();
            }
        }

        private float ConvertStringToFloat(string text)
        {
            float result = 0.0f;
            float floatNumber = 0.0f;
            bool isFloatNumber = float.TryParse(text, out floatNumber);

            if (isFloatNumber)
            {
                result = floatNumber;
            }
            else
            {
                if (text.Trim() != String.Empty)
                {
                    string message = "Моля въвеждайте само цифри !!!";
                    MessageBox.Show(message);
                }
            }

            return result;
        }

        void windingsParameterForm_VoltageTextChanged(object aSender, TextChangedEventArgs aEvent)
        {
            TextBox textBox = (TextBox)aSender;
            string parentName = textBox.Parent.Name;

            if (parentName.Equals("firstSecondaryWindingsUserControl"))
            {                
                if (textBox.Name.Equals("voltageTextBox"))
                {
                    //float floatNumber = 0.0f;
                    //bool isFloatNumber = float.TryParse(aEvent.Voltage, out floatNumber);
                    //if (isFloatNumber)
                    //{
                        windingsInfoForm.FirstWindingVoltage = aEvent.Voltage;
                    //}
                }
                else if (textBox.Name.Equals("amperageTextBox"))
                {
                    this.windingsInfoForm.FirstWindingAmperage = aEvent.Amperage;
                }
                else if (textBox.Name.Equals("densityTextBox"))
                {
                    this.windingsInfoForm.FirstWindingDensity = aEvent.Density;
                }
            }
            else if (parentName.Equals("secondSecondaryWindingsUserControl"))
            {
                if (textBox.Name.Equals("voltageTextBox"))
                {
                    windingsInfoForm.SecondWindingVoltage = aEvent.Voltage;
                }
                else if (textBox.Name.Equals("amperageTextBox"))
                {
                    this.windingsInfoForm.SecondWindingAmperage = aEvent.Amperage;
                }
                else if (textBox.Name.Equals("densityTextBox"))
                {
                    this.windingsInfoForm.SecondWindingDensity = aEvent.Density;
                }
            }
            else if (parentName.Equals("thirdSecondaryWindingsUserControl"))
            {
                if (textBox.Name.Equals("voltageTextBox"))
                {
                    windingsInfoForm.ThirdWindingVoltage = aEvent.Voltage;
                }
                else if (textBox.Name.Equals("amperageTextBox"))
                {
                    this.windingsInfoForm.ThirdWindingAmperage = aEvent.Amperage;
                }
                else if (textBox.Name.Equals("densityTextBox"))
                {
                    this.windingsInfoForm.ThirdWindingDensity = aEvent.Density;
                }
            }
            else if (parentName.Equals("fourthSecondaryWindingsUserControl"))
            {
                if (textBox.Name.Equals("voltageTextBox"))
                {
                    windingsInfoForm.FourthWindingVoltage = aEvent.Voltage;
                }
                else if (textBox.Name.Equals("amperageTextBox"))
                {
                    this.windingsInfoForm.FourthWindingAmperage = aEvent.Amperage;
                }
                else if (textBox.Name.Equals("densityTextBox"))
                {
                    this.windingsInfoForm.FourthWindingDensity = aEvent.Density;
                }
            }
        }

        private void titleBarLabel_MouseDown(object sender, MouseEventArgs e)
        {
            pp = new Point(e.X, e.Y);
            trigger = true;
        }
               
        private void titleBarLabel_MouseUp(object sender, MouseEventArgs e)
        {
            trigger = false;
        }

        private void titleBarLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (trigger)
            {
                this.Top += e.Y - pp.Y;
                this.Left += e.X - pp.X;

                if ((this.windingsParametersForm != null) && (this.windingsInfoForm != null))
                {
                    this.windingsParametersForm.Top += e.Y - pp.Y;
                    this.windingsParametersForm.Left += e.X - pp.X;

                    this.windingsInfoForm.Top += e.Y - pp.Y;
                    this.windingsInfoForm.Left += e.X - pp.X;
                }
            }
        }

        private void closeButtonLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void claculateButtonLabel_Click(object sender, EventArgs e)
        {
            this.primarySection = 0;
            float diameter = 0.0f;
            float typicalPower = 0.0f;
                        
            bool isObtainedParametersOfSecondaryWindings = ObtainingParametersOfSecondaryWindings();

            if (!isObtainedParametersOfSecondaryWindings)
            {
                string message = "Моля въвеждайте само цифри за вторичните намотки!!!";
                MessageBox.Show(message);

                return;
            }
            
            this.primarySection = CalculateSectionOfSecondaryWindings(this.VoltageList, this.AmperageList);
            this.primarySection = DivideSection(primarySection);

            // Calculate Typical Power
            typicalPower = CalculateTypicalPower(this.primarySection);                
            this.typicalPowerInfoLabel.Text = typicalPower.ToString();

            // Calculate Primary Amperage                
            this.primaryAmperage = CalculateAmperage(typicalPower, this.primaryVoltage);
            this.windingsInfoForm.PrimaryWindingAmperage = this.primaryAmperage.ToString();

            // Show hidden conttrols "inductionOptionalParameterUserControl" and "densityOptionalParameterUserControl"
            this.inductionOptionalParameterUserControl.Visible = true;
            this.densityOptionalParameterUserControl.Visible = true;
            this.sectionLabelTextBox.Visible = true;

            // Set minimal section in "sectionLabelTextBox" on SecondMessage Property
            this.sectionLabelTextBox.SecondMessage = GetMinimalSection(this.primarySection).ToString();
            
            // Calculate of Primary windings diameter of wire
            diameter = this.comCalFormulas.CalculatingDiameter(this.primaryAmperage, this.primaryDensity);
            diameter = (float)Math.Round(diameter * 100) / 100;

            bool isDiameterValid = IsDiameterValid(diameter);

            if (!isDiameterValid)
            {
                return;
            }
            else
            {
                diameter = this.comCalFormulas.PickNearestDiameterOfWire(diameter);
                this.windingsInfoForm.PrimaryWindingThicknessOfWire = diameter.ToString();

                CalculateSecondaryWindingsDiameterOfWire(this.AmperageList, this.DensityList);
            }
        }

        private bool IsDiameterValid(float diameter)
        {
            bool isValid = true;

            if (diameter > this.comCalFormulas.GetTheBiggestWireDiameter)
            {
                string message = "Изчисленият диаметър е по-голям от стандартните размери заложени в програмата. Коефицентът на запълване няма да бъде пресмятан !!!";
                MessageBox.Show(message);

                isValid = false;
            }

            return isValid;
        }

        private float CalculateAmperage(float typicalPower, float voltage)
        {
            float result = 0;

            result = typicalPower / voltage;
            result = (float)Math.Round(result * 100) / 100;

            return result;
        }

        private bool ObtainingParametersOfSecondaryWindings()
        {
            bool isObtained = false;
            List<List<string>> SecondaryWindingsParametersList = new List<List<string>>();

            try
            {
                // Is need a big refactoring
                SecondaryWindingsParametersList = ObtainingParametersFromGetWindingsParametersForm();
                FilterObtainedParameters(SecondaryWindingsParametersList);

                isObtained = true;
            }
            catch (FormatException)
            {
                isObtained = false;
            }

            return isObtained;
        }

        private List<List<string>> ObtainingParametersFromGetWindingsParametersForm()
        {
            List<string> SecondaryWindingsVoltageList = new List<string>();
            List<string> SecondaryWindingsAmperageList = new List<string>();
            List<string> SecondaryWindingsDensityList = new List<string>();

            List<List<string>> SecondaryWindingsParametersList = new List<List<string>>();

            SecondaryWindingsVoltageList.Add(this.windingsParametersForm.FirstWindingVoltage);
            SecondaryWindingsVoltageList.Add(this.windingsParametersForm.SecondWindingVoltage);
            SecondaryWindingsVoltageList.Add(this.windingsParametersForm.ThirdWindingVoltage);
            SecondaryWindingsVoltageList.Add(this.windingsParametersForm.FourthWindingVoltage);

            SecondaryWindingsAmperageList.Add(this.windingsParametersForm.FirstWindingAmperage);
            SecondaryWindingsAmperageList.Add(this.windingsParametersForm.SecondWindingAmperage);
            SecondaryWindingsAmperageList.Add(this.windingsParametersForm.ThirdWindingAmperage);
            SecondaryWindingsAmperageList.Add(this.windingsParametersForm.FourthWindingAmperage);

            SecondaryWindingsDensityList.Add(this.windingsParametersForm.FirstWindingDensity);
            SecondaryWindingsDensityList.Add(this.windingsParametersForm.SecondWindingDensity);
            SecondaryWindingsDensityList.Add(this.windingsParametersForm.ThirdWindingDensity);
            SecondaryWindingsDensityList.Add(this.windingsParametersForm.FourthWindingDensity);

            SecondaryWindingsParametersList.Add(SecondaryWindingsVoltageList);
            SecondaryWindingsParametersList.Add(SecondaryWindingsAmperageList);
            SecondaryWindingsParametersList.Add(SecondaryWindingsDensityList);

            return SecondaryWindingsParametersList;
        }

        private void FilterObtainedParameters(List<List<string>> parametersLists)
        {
            this.VoltageList = new List<float>();
            this.AmperageList = new List<float>();
            this.DensityList = new List<float>();

            for (int i = 0; i < parametersLists.Count; i++)
            {
                for (int j = 0; j < this.secondaryWindings; j++)
                {
                    if (i == 0)
                    {
                        this.VoltageList.Add(float.Parse(parametersLists[i][j]));
                    }
                    else if (i == 1)
                    {
                        this.AmperageList.Add(float.Parse(parametersLists[i][j]));
                    }
                    else if (i == 2)
                    {
                        this.DensityList.Add(float.Parse(parametersLists[i][j]));
                    }
                }
            }
        }

        private void CalculateSecondaryWindingsDiameterOfWire(List<float> amperageList, List<float> densityList)
        {
            float diameter = 0.0f;

            for (int i = 0; i < this.secondaryWindings; i++)
            {
                diameter = comCalFormulas.CalculatingDiameter(amperageList[i], densityList[i]);
                diameter = (float)Math.Round(diameter * 100) / 100;

                if (diameter > this.comCalFormulas.GetTheBiggestWireDiameter)
                {
                    MessageBox.Show("Изчисленият диаметър е по-голям от стандартните размери заложени в програмата. Коефицентът на запълване няма да бъде пресмятан !!!");
                    return;
                }

                diameter = comCalFormulas.PickNearestDiameterOfWire(diameter);
                this.windingsInfoForm.SecondaryWindingsDiameterList[i].Text = diameter.ToString();
            }
        }

        private float CalculateTypicalPower(float section)
        {
            float typicalPower = section / 0.9f;
            typicalPower = (float)Math.Round(typicalPower * 100) / 100;

            return typicalPower;
        }

        private float CalculateSectionOfSecondaryWindings(List<float> voltageList, List<float> amperageList)
        {
            float result = 0.0f;

            for (int i = 0; i < this.secondaryWindings; i++)
            {
                result += voltageList[i] * amperageList[i];
            }

            return result;
        }

        float DivideSection(float section) 
        {
            float result = 0;

            if (section < 50)
            {
                result = section / 0.8f;
            }
            else if (section < 150)
            {
                result = section / 0.85f;
            }
            else
            {
                result = section / 0.9f;
            }

            return result;
        }

        private void primaryVoltageTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.windingsInfoForm != null)
            {
                this.windingsInfoForm.PrimaryWindingVoltage = this.voltageLabelTextBoxUserControl.TextBoxTextProperty;
                this.voltageInfoLabel.Text = this.voltageLabelTextBoxUserControl.TextBoxTextProperty;
            }
        }

        private float GetMinimalSection(float section)
        {
            float minimalSection = (float)Math.Sqrt(section);
            minimalSection = (float)Math.Round(minimalSection * 100) / 100;

            return minimalSection;
        }

        private void claculateButtonLabel_MouseEnter(object sender, EventArgs e)
        {
            this.calculateButtonLabel.BackColor = Color.YellowGreen;
        }

        private void claculateButtonLabel_MouseLeave(object sender, EventArgs e)
        {
            this.calculateButtonLabel.BackColor = Color.Orange;
        }

        //public float FormulaForCalculatingDiameter(float amperage, float density)
        //{
        //    float result = 0.03558f * (float)Math.Sqrt((amperage * 1000) / density);

        //    return result;
        //}

        //public float PickNearestDiameterOfWire(float diameter, List<float> diameterList)
        //{
        //    float result = 0;

        //    for (int i = 0; i < diameterList.Count; i++)
        //    {
        //        if (diameterList[i] >= diameter)
        //        {
        //            result = diameterList[i];
        //            break;
        //        }
        //    }

        //    return result;
        //}

        //float FormulaForCalculatingTheNumberOfTurns(float k, float voltage, float section, float induction)
        //{
        //    return (float)Math.Round((voltage * k) / ((4.44 * 50) * (induction * section)) * 10000) + 1;
        //}
        
        private void sectionLabelTextBox_Load(object sender, EventArgs e)
        {
            this.sectionLabelTextBox.Message = "Моля въведете сечение по голяма от";
        }

        private void voltageLabelTextBoxUserControl_Load(object sender, EventArgs e)
        {
            this.voltageLabelTextBoxUserControl.Message = "Напрежение (V)";
        }

        private void inductionOptionalParameterUserControl_Load(object sender, EventArgs e)
        {
            this.inductionOptionalParameterUserControl.Message = "Подразбираща се Индукция 1,2";
            this.inductionOptionalParameterUserControl.DefaultValue = "1,2";

            this.primaryInduction = float.Parse(this.inductionOptionalParameterUserControl.DefaultValue);
        }

        private void densityOptionalParameterUserControl_Load_1(object sender, EventArgs e)
        {
            this.densityOptionalParameterUserControl.Message = "Препоръчителна плътност на тока 2,55";
            this.densityOptionalParameterUserControl.DefaultValue = "2,55";

            this.primaryDensity = float.Parse(this.densityOptionalParameterUserControl.DefaultValue);
        }

        private void windingsInfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.windingsInfoForm = null;
        }

        private void windingsParameterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.windingsParametersForm = null;
        }

        private Point pp;        
        private bool trigger = false;

        private int secondaryWindings = 0;
        private CommonCalculatingFormulas comCalFormulas = new CommonCalculatingFormulas();

        private float primaryVoltage = 0;
        private float primaryAmperage = 0.0f;
        private float primarySection = 0.0f;
        private float primaryInduction = 0.0f;
        private float primaryDensity = 0.0f;

        public List<float> VoltageList = new List<float>();
        public List<float> AmperageList = new List<float>();
        public List<float> DensityList = new List<float>();

        //private List<float> thicknessOfWireDiameterList = new List<float>
        //{
        //    0.04f, 0.05f, 0.06f, 0.07f, 0.08f, 0.09f, 0.10f, 0.11f, 0.12f,
        //    0.13f, 0.14f, 0.15f, 0.16f, 0.17f, 0.18f, 0.19f, 0.20f, 0.21f, 0.22f, 0.23f, 0.24f,
        //    0.25f, 0.26f, 0.27f, 0.28f, 0.29f, 0.30f, 0.32f, 0.34f, 0.36f, 0.38f, 0.44f, 0.45f,
        //    0.50f, 0.55f, 0.60f, 0.65f, 0.70f, 0.75f, 0.80f, 0.85f, 0.90f, 0.95f, 1.00f, 1.04f,
        //    1.08f, 1.12f, 1.16f, 1.20f, 1.25f, 1.30f, 1.35f, 1.40f, 1.45f, 1.50f, 1.56f, 1.62f,
        //    1.68f, 1.74f, 1.81f, 1.88f, 1.95f, 2.02f
        //};

        //private List<int> numberOfTurnsList = new List<int>
        //{
        //    25100, 18500, 12600, 10050, 8200, 6650, 5650, 4500, 3900,
        //    3100, 3000, 2720, 2400, 2120, 1940, 1750, 1600, 1420, 1320, 1220, 1130,
        //    1050, 960, 900, 850, 800, 750, 650, 580, 520, 470, 430, 335, 280, 225,
        //    195, 170, 148, 126, 112, 102, 91, 81, 75, 73, 70, 65, 60, 55, 50, 45,
        //    41, 38, 36, 33, 31, 28, 25, 23, 17, 15, 14, 12
        //};

        private void resetButtonLabel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            this.voltageInfoLabel.Text = String.Empty;
            this.densityInfoLabel.Text = String.Empty;
            this.typicalPowerInfoLabel.Text = String.Empty;
            this.numberOfWindingsInfoLabel.Text = String.Empty;
            this.inductionInfoLabel.Text = String.Empty;
            this.sectionInfoLabel.Text = String.Empty;

            this.voltageLabelTextBoxUserControl.TextBoxTextProperty = String.Empty;
            this.sectionLabelTextBox.SecondMessage = String.Empty;
            this.sectionLabelTextBox.TextBoxTextProperty = string.Empty;

            this.voltageLabelTextBoxUserControl.Visible = false;
            this.sectionLabelTextBox.Visible = false;
            this.inductionOptionalParameterUserControl.Visible = false;
            this.densityOptionalParameterUserControl.Visible = false;

            this.secondaryWindingsTextBox.Text = String.Empty;

            this.calculateButtonLabel.Visible = false;
            this.resetButtonLabel.Visible = false;

            if (this.windingsInfoForm != null)
            {
                this.windingsInfoForm.Close();
            }

            if (this.windingsParametersForm != null)
            {
                this.windingsParametersForm.Close();
            }
        }

        private void resetButtonLabel_MouseEnter(object sender, EventArgs e)
        {
            this.resetButtonLabel.BackColor = Color.Orange;
        }

        private void resetButtonLabel_MouseLeave(object sender, EventArgs e)
        {
            this.resetButtonLabel.BackColor = Color.YellowGreen;
        }
    }
}