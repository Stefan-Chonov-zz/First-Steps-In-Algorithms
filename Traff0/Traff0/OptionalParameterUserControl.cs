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
    public partial class OptionalParameterUserControl : UserControl
    {
        public OptionalParameterUserControl()
        {
            InitializeComponent();
            this.textBox.TextChanged += new EventHandler(textBox_TextChanged);
            this.checkBox.CheckedChanged += new EventHandler(checkBox_CheckedChanged);
        }

        void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckChanged != null)
            {
                CheckChangedArgs args = new CheckChangedArgs();
                CheckChanged(this.checkBox.Checked, args);
            }
        }

        void textBox_TextChanged(object sender, EventArgs e)
        {
            if (TextChanged != null)
            {
                TextChangedEventArgs args = new TextChangedEventArgs();
                this.TextChanged(this.textBox.Text, args);
            }
        }

        public string Message
        {
            set
            {
                this.messageLabel.Text = value;
            }
        }

        public string ParameterValue
        {
            get
            {
                return this.textBox.Text;
            }
            set
            {
                this.textBox.Text = value;
            }
        }

        public string DefaultValue
        {
            get
            {
                return this.textBox.Text;
            }
            set
            {
                this.textBox.Text = value;
            }
        }

        private void inductionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox.CheckState == CheckState.Checked)
            {
                this.textBox.ReadOnly = false;
            }
            else if (this.checkBox.CheckState == CheckState.Unchecked)
            { 
                this.textBox.ReadOnly = true;
            }
        }

        public new event TextChangedHandler TextChanged;
        public event CheckChangedEventHandler CheckChanged;
    }

    public class CheckChangedArgs : EventArgs
    {
        public CheckChangedArgs()
        {
        
        }
    }

    public delegate void CheckChangedEventHandler(object aSender, CheckChangedArgs aEventArgs);
}