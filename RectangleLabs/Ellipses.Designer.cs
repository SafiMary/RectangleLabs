namespace RectangleLabs
{
    partial class Ellipses
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
            // Ellipses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Ellipses";
            this.Text = "Ellipses";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Ellipses_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Ellipse_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Ellipses_MouseUp);
            this.Resize += new System.EventHandler(this.Ellipses_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}