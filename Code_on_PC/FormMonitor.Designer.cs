namespace LedDotMatrixScreenDisplayControlSystemOnPC
{
    partial class FormMonitor
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
            pbMonitor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pbMonitor)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMonitor
            // 
            pbMonitor.Location = new System.Drawing.Point(12, 13);
            pbMonitor.Name = "pbMonitor";
            pbMonitor.Size = new System.Drawing.Size(257, 257);
            pbMonitor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            pbMonitor.TabIndex = 0;
            pbMonitor.TabStop = false;
            // 
            // FormMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 282);
            this.Controls.Add(pbMonitor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "监视点阵屏";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMonitor_FormClosed);
            this.Load += new System.EventHandler(this.FormMonitor_Load);
            ((System.ComponentModel.ISupportInitialize)(pbMonitor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public static System.Windows.Forms.PictureBox pbMonitor;
    }
}