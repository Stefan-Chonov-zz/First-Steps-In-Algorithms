using System;
using System.Windows.Controls;

namespace SimulatorOfGame123
{
    class InBoundsValidationRule : ValidationRule
    {
        private uint number = 0;
        private uint minBounds = 0;
        private uint maxBounds = 0;
        private string message = String.Empty;

        public uint Number
        {
            get
            {
                return this.number;
            }
            set
            {
                this.number = value;
            }
        }

        public uint MinBounds
        {
            get
            {
                return this.minBounds;
            }
            set
            {
                this.minBounds = value;
            }
        }

        public uint MaxBounds
        {
            get
            {
                return this.maxBounds;
            }
            set
            {
                this.maxBounds = value;
            }
        }

        public string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                this.message = value;
            }
        }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            bool isInBounds = ValidationOfNumbers.IsNumberInBounds(this.number, this.minBounds, this.maxBounds);

            if (!isInBounds)
            {
                return new ValidationResult(false, this.message);
            }

            return new ValidationResult(true, null);
        }
    }
}