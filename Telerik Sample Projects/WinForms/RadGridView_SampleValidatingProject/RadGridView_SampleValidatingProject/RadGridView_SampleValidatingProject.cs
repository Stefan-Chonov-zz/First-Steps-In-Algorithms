using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace RadControlsWinFormsApp1_Delete
{
    public partial class Form1 : Form
    {
        private const char PHONE_SEPARATOR = '-';
        private const byte PHONE_NUMBER_LENGTH = 12;
        private const string FEMALE = "F";
        private const string MALE = "M";
        private const string GENDER_COLUMN_NAME = "Gender";
        private const string GENDER_ERROR_MESSAGE = "Gender must be 'F' or 'M'!";
        private const string PHONE_COLUMN_NAME = "Phone";
        private const string INVALID_PHONE_MESSAGE = "Phone number could contain only digits!";
        private RadGridView radGridView1;
        private const string INVALID_PHONE_LENGTH_MESSAGE = "Invalid phone number!";
        
        public Form1()
        {
            InitializeComponent();

            InitiazlizeRadGridView();
        }

        private void InitializeComponent()
        {
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // radGridView1
            // 
            this.radGridView1.Location = new System.Drawing.Point(13, 13);
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Size = new System.Drawing.Size(353, 237);
            this.radGridView1.TabIndex = 0;
            this.radGridView1.Text = "radGridView1";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(378, 260);
            this.Controls.Add(this.radGridView1);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            this.ResumeLayout(false);
        }

        private void InitiazlizeRadGridView()
        {
            this.radGridView1.AllowRowResize = true;
            this.radGridView1.AllowColumnResize = true;
            this.radGridView1.CellValidating += new Telerik.WinControls.UI.CellValidatingEventHandler(radGridView1_CellValidating);

            ObservableCollection<PersonInfo> personInfos = InitializeCollection();
            this.radGridView1.DataSource = personInfos;            
        }

        private ObservableCollection<PersonInfo> InitializeCollection()
        {
            ObservableCollection<PersonInfo> personInfos = new ObservableCollection<PersonInfo>();

            for (int i = 0; i < 10; i++)
            {
                personInfos.Add(new PersonInfo()
                {
                    ID = this.id[i],
                    Name = this.names[i],
                    Gender = this.genders[i],
                    Phone = this.phones[i],
                });
            }

            return personInfos;
        }

        void radGridView1_CellValidating(object sender, Telerik.WinControls.UI.CellValidatingEventArgs e)
        {
            GridViewColumn currentColumn = e.Column;

            // Validate Gender
            if (currentColumn.FieldName == GENDER_COLUMN_NAME)
            {
                string currentColumnValue = e.Value.ToString();
                if ((currentColumnValue.ToUpper() != FEMALE && currentColumnValue.ToUpper() != MALE) ||
                   (currentColumnValue.Length > 1))
                {
                    e.Cancel = true;
                    e.Row.ErrorText = GENDER_ERROR_MESSAGE;
                }
                else
                {
                    e.Row.ErrorText = String.Empty;
                }
            } // Validate Phone number
            else if (currentColumn.FieldName == PHONE_COLUMN_NAME)
            {
                bool isPhoneNumberValid = IsPhoneNumberValid((string)e.Value, PHONE_SEPARATOR);
                if (!isPhoneNumberValid)
                {
                    e.Cancel = true;
                    e.Row.ErrorText = INVALID_PHONE_MESSAGE;
                }

                bool isPhoneNumberLengthValid = IsPhoneNumberLengthValid((string)e.Value);
                if (!isPhoneNumberLengthValid)
                {
                    e.Cancel = true;
                    e.Row.ErrorText = INVALID_PHONE_LENGTH_MESSAGE;
                }

                if (isPhoneNumberValid && isPhoneNumberLengthValid)
                {
                    e.Row.ErrorText = String.Empty;
                }
            }
        }

        private bool IsPhoneNumberLengthValid(string phoneNumber)
        {
            bool isPhoneNumberLengthvalid = true;

            if (phoneNumber.Length != PHONE_NUMBER_LENGTH)
            {
                isPhoneNumberLengthvalid = false;
            }

            return isPhoneNumberLengthvalid;
        }

        private bool IsPhoneNumberValid(string phoneNumber, char separator)
        {
            string[] sequencesOfDigits = phoneNumber.Split(separator);

            foreach (string sequenceOfDigit in sequencesOfDigits)
            {
                foreach (char digit in sequenceOfDigit)
                {
                    if (!char.IsDigit(digit))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private List<int> id = new List<int>()
        {
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
        };

        private List<string> names = new List<string>()
        {
            "David Beckham",
            "Peter Pan",
            "Robin Hood",
            "Katrin Zita Jones",
            "Paris Hilton",
            "Kylie Minogue",
            "Lorenzo Lamas",
            "Joe Black",
            "Eva Longoria",
            "Jack Daniels",
        };

        private List<char> genders = new List<char>()
        {
            'M', 'M', 'M', 'F', 'F',
            'F', 'M', 'M', 'F', 'M',
        };

        private List<string> phones = new List<string>()
        {
            "555-12-34-56", "555-78-90-12",
            "555-34-56-78", "555-90-12-34",
            "555-56-78-90", "555-12-34-56",
            "555-78-90-12", "555-34-56-78",
            "555-90-12-34", "555-56-78-90",
        };
    }

    public class PersonInfo
    {
        private int id;
        private string name;
        private char gender;
        private string phone;

        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public char Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                this.gender = value;
            }
        }

        public string Phone
        {
            get
            {
                return this.phone;
            }
            set
            {
                this.phone = value;
            }
        }
    }
}