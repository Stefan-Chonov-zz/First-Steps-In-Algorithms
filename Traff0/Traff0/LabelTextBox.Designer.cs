﻿namespace Traff0
{
    partial class LabelTextBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.parameterTextBox = new System.Windows.Forms.TextBox();
            this.textLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.secondMessageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // parameterTextBox
            // 
            this.parameterTextBox.BackColor = System.Drawing.Color.DimGray;
            this.parameterTextBox.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parameterTextBox.ForeColor = System.Drawing.Color.Gold;
            this.parameterTextBox.Location = new System.Drawing.Point(69, 56);
            this.parameterTextBox.MaxLength = 4;
            this.parameterTextBox.Name = "parameterTextBox";
            this.parameterTextBox.Size = new System.Drawing.Size(50, 26);
            this.parameterTextBox.TabIndex = 48;
            this.parameterTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textLabel
            // 
            this.textLabel.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textLabel.ForeColor = System.Drawing.Color.Orange;
            this.textLabel.Location = new System.Drawing.Point(11, 7);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(166, 30);
            this.textLabel.TabIndex = 47;
            this.textLabel.Text = "Message";
            this.textLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(1, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(187, 88);
            this.label8.TabIndex = 46;
            this.label8.Text = "label8";
            // 
            // secondMessageLabel
            // 
            this.secondMessageLabel.BackColor = System.Drawing.Color.Black;
            this.secondMessageLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secondMessageLabel.ForeColor = System.Drawing.Color.LawnGreen;
            this.secondMessageLabel.Location = new System.Drawing.Point(55, 36);
            this.secondMessageLabel.Name = "secondMessageLabel";
            this.secondMessageLabel.Size = new System.Drawing.Size(79, 16);
            this.secondMessageLabel.TabIndex = 49;
            this.secondMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.secondMessageLabel);
            this.Controls.Add(this.parameterTextBox);
            this.Controls.Add(this.textLabel);
            this.Controls.Add(this.label8);
            this.Name = "LabelTextBox";
            this.Size = new System.Drawing.Size(189, 90);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox parameterTextBox;
        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label secondMessageLabel;
    }
}
