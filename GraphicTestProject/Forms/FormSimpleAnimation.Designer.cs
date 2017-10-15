namespace GraphicTestProject
{
    partial class FormSimpleAnimation
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
            this.label_yPos = new System.Windows.Forms.Label();
            this.label_xPos = new System.Windows.Forms.Label();
            this.label_SizeFormWidth = new System.Windows.Forms.Label();
            this.label_SizeFormHigh = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FormGrößeWidth = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_yPos
            // 
            this.label_yPos.AutoSize = true;
            this.label_yPos.Location = new System.Drawing.Point(86, 32);
            this.label_yPos.Name = "label_yPos";
            this.label_yPos.Size = new System.Drawing.Size(35, 13);
            this.label_yPos.TabIndex = 0;
            this.label_yPos.Text = "label1";
            this.label_yPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_xPos
            // 
            this.label_xPos.AutoSize = true;
            this.label_xPos.Location = new System.Drawing.Point(12, 32);
            this.label_xPos.Name = "label_xPos";
            this.label_xPos.Size = new System.Drawing.Size(35, 13);
            this.label_xPos.TabIndex = 1;
            this.label_xPos.Text = "label2";
            this.label_xPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_SizeFormWidth
            // 
            this.label_SizeFormWidth.AutoSize = true;
            this.label_SizeFormWidth.Location = new System.Drawing.Point(639, 32);
            this.label_SizeFormWidth.Name = "label_SizeFormWidth";
            this.label_SizeFormWidth.Size = new System.Drawing.Size(35, 13);
            this.label_SizeFormWidth.TabIndex = 3;
            this.label_SizeFormWidth.Text = "label2";
            this.label_SizeFormWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_SizeFormHigh
            // 
            this.label_SizeFormHigh.AutoSize = true;
            this.label_SizeFormHigh.Location = new System.Drawing.Point(732, 32);
            this.label_SizeFormHigh.Name = "label_SizeFormHigh";
            this.label_SizeFormHigh.Size = new System.Drawing.Size(35, 13);
            this.label_SizeFormHigh.TabIndex = 2;
            this.label_SizeFormHigh.Text = "label1";
            this.label_SizeFormHigh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "ViereckPosX";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "ViereckPosY";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormGrößeWidth
            // 
            this.FormGrößeWidth.AutoSize = true;
            this.FormGrößeWidth.Location = new System.Drawing.Point(639, 9);
            this.FormGrößeWidth.Name = "FormGrößeWidth";
            this.FormGrößeWidth.Size = new System.Drawing.Size(87, 13);
            this.FormGrößeWidth.TabIndex = 7;
            this.FormGrößeWidth.Text = "FormGrößeWidth";
            this.FormGrößeWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(732, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "FormGrößeHeight";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormSimpleAnimation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(834, 562);
            this.Controls.Add(this.FormGrößeWidth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_SizeFormWidth);
            this.Controls.Add(this.label_SizeFormHigh);
            this.Controls.Add(this.label_xPos);
            this.Controls.Add(this.label_yPos);
            this.MinimumSize = new System.Drawing.Size(850, 600);
            this.Name = "FormSimpleAnimation";
            this.Text = "Form1";
            this.AutoSizeChanged += new System.EventHandler(this.FormSimpleAnimation_SizeChanged);
            this.Load += new System.EventHandler(this.FormSimpleAnimation_Load);
            this.SizeChanged += new System.EventHandler(this.FormSimpleAnimation_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormSpimpleAnimation_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormSimpleAnimation_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_yPos;
        private System.Windows.Forms.Label label_xPos;
        private System.Windows.Forms.Label label_SizeFormWidth;
        private System.Windows.Forms.Label label_SizeFormHigh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label FormGrößeWidth;
        private System.Windows.Forms.Label label4;
    }
}