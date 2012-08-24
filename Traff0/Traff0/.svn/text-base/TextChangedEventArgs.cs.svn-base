using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traff0
{
    public class TextChangedEventArgs : EventArgs
    {
        public TextChangedEventArgs()
        {
            
        }

        public string Voltage
        {
            get
            {
                return this.voltage;
            }
            set
            {
                this.voltage = value;
            }
        }

        public string Amperage
        {
            get
            {
                return this.amperage;
            }
            set
            {
                this.amperage = value;
            }
        }

        public string Density
        {
            get
            {
                return this.density;
            }
            set
            {
                this.density = value;
            }
        }

        private string voltage = null;
        private string amperage = null;
        private string density = null;
    }

    public delegate void TextChangedHandler(object aSender, TextChangedEventArgs aEvent);
}
