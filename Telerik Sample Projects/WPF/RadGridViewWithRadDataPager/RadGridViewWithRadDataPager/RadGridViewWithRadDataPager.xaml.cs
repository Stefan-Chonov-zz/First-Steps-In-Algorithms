using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace RadGridViewWithRadDataPager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class RadGridViewWithRadDataPagerWindow : Window
    {
        private const char PHONE_SEPARATOR = '-';
        private const byte PHONE_NUMBER_LENGTH = 12;
        private const string FEMALE = "F";
        private const string MALE = "M";
        private const string GENDER_COLUMN_NAME = "Gender";
        private const string GENDER_ERROR_MESSAGE = "Gender must be 'F' or 'M'!";
        private const string PHONE_COLUMN_NAME = "Phone";
        private const string INVALID_PHONE_MESSAGE = "Phone number could contain only digits!";
        private const string INVALID_PHONE_LENGTH_MESSAGE = "Invalid phone number!";

        public RadGridViewWithRadDataPagerWindow()
        {
            InitializeComponent();

            this.radDataPager1.Source = InitializeCollection();
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

        private void radGridView1_CellValidating(object sender, Telerik.Windows.Controls.GridViewCellValidatingEventArgs e)
        {
            string currentCellValue = e.NewValue.ToString().ToUpper();

            if (e.Cell.Column.UniqueName == GENDER_COLUMN_NAME)
            {
                if (currentCellValue != FEMALE && currentCellValue != MALE)
                {
                    e.IsValid = false;
                    e.ErrorMessage = GENDER_ERROR_MESSAGE;
                }
            }
            else if (e.Cell.Column.UniqueName == PHONE_COLUMN_NAME)
            {
                string phoneNumber = e.NewValue.ToString();

                bool isPhoneNumberValid = IsPhoneNumberValid(phoneNumber, PHONE_SEPARATOR);
                if (!isPhoneNumberValid)
                {
                    e.IsValid = false;
                    e.ErrorMessage = INVALID_PHONE_MESSAGE;
                }

                bool isPhoneNumberLengthValid = IsPhoneNumberLengthValid(phoneNumber);
                if (!isPhoneNumberLengthValid)
                {
                    e.IsValid = false;
                    e.ErrorMessage = INVALID_PHONE_LENGTH_MESSAGE;
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
