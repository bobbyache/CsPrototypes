using NumericTextboxControl;
namespace NumericTextBoxDemo
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericTextBox1 = new NumericTextboxControl.NumericTextBox();
            this.numericTextBox2 = new NumericTextboxControl.NumericTextBox();
            this.lblEventArgs = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // numericTextBox1
            // 
            this.numericTextBox1.Location = new System.Drawing.Point(12, 12);
            this.numericTextBox1.Name = "numericTextBox1";
            this.numericTextBox1.Size = new System.Drawing.Size(100, 20);
            this.numericTextBox1.TabIndex = 0;
            this.numericTextBox1.PasteRejected += new System.EventHandler<NumericTextboxControl.NumericTextBox.PasteEventArgs>(this.updateLabel_PasteRejected);
            this.numericTextBox1.KeyRejected += new System.EventHandler<NumericTextboxControl.NumericTextBox.KeyRejectedEventArgs>(this.updateLabel_KeyRejected);
            // 
            // numericTextBox2
            // 
            this.numericTextBox2.DefaultText = "<empty>";
            this.numericTextBox2.Location = new System.Drawing.Point(118, 12);
            this.numericTextBox2.Name = "numericTextBox2";
            this.numericTextBox2.Size = new System.Drawing.Size(100, 20);
            this.numericTextBox2.TabIndex = 1;
            this.numericTextBox2.Text = "<empty>";
            this.numericTextBox2.PasteRejected += new System.EventHandler<NumericTextboxControl.NumericTextBox.PasteEventArgs>(this.updateLabel_PasteRejected);
            this.numericTextBox2.KeyRejected += new System.EventHandler<NumericTextboxControl.NumericTextBox.KeyRejectedEventArgs>(this.updateLabel_KeyRejected);
            // 
            // lblEventArgs
            // 
            this.lblEventArgs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEventArgs.Location = new System.Drawing.Point(7, 40);
            this.lblEventArgs.Name = "lblEventArgs";
            this.lblEventArgs.Size = new System.Drawing.Size(216, 19);
            this.lblEventArgs.TabIndex = 2;
            this.lblEventArgs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 68);
            this.Controls.Add(this.lblEventArgs);
            this.Controls.Add(this.numericTextBox2);
            this.Controls.Add(this.numericTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Numeric Text Box Demo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NumericTextBox numericTextBox1;
        private NumericTextBox numericTextBox2;
        private System.Windows.Forms.Label lblEventArgs;
    }
}

