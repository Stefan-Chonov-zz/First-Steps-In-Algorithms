using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Traff0
{
    public partial class LabelTextBox : UserControl
    {
        public LabelTextBox()
        {
            InitializeComponent();
            this.parameterTextBox.TextChanged += new EventHandler(parameterTextBox_TextChanged);
        }

        void parameterTextBox_TextChanged(object sender, EventArgs e)
        {
            OnTextChanged();
        }

        public string Message
        {
            set
            {
                this.textLabel.Text = value;
            }
        }

        public string SecondMessage
        {
            set
            {
                this.secondMessageLabel.Text = value;
            }
        }

        public string TextBoxTextProperty
        {
            get
            {
                return this.parameterTextBox.Text;
            }
            set
            {
                this.parameterTextBox.Text = value;
            }
        }

        protected void OnTextChanged()
        {
            if (TextChanged != null)
            {
                EventArgs args = new EventArgs();                
                TextChanged(this.parameterTextBox.Text, args);
            }
        }

        public new event TextChanged2Handler TextChanged;
    }

    public class TextChanged2EventArgs : EventArgs
    {
        public TextChanged2EventArgs()
        {

        }
    }

    public delegate void TextChanged2Handler(object aSender, EventArgs aEventArgs);
}
