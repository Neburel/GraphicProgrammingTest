namespace GraphicTestProject
{
    partial class FormTestPaintEvent
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
            this.SuspendLayout();
            // 
            // FormTestPaintEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 419);
            this.Name = "FormTestPaintEvent";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormTestPaintEvent_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormTestPaintEvent_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormTestPaintEvent_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}