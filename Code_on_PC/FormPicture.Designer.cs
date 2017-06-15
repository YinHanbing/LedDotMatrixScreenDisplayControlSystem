namespace LedDotMatrixScreenDisplayControlSystemOnPC
{
    partial class FormPicture
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
            this.picDraw = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDraw)).BeginInit();
            this.SuspendLayout();
            // 
            // picDraw
            // 
            this.picDraw.Location = new System.Drawing.Point(200, 12);
            this.picDraw.Name = "picDraw";
            this.picDraw.Size = new System.Drawing.Size(332, 332);
            this.picDraw.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picDraw.TabIndex = 0;
            this.picDraw.TabStop = false;
            // 
            // FormPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 356);
            this.Controls.Add(this.picDraw);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormPicture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图形模式";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormPicture_FormClosed);
            this.Load += new System.EventHandler(this.FormPicture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picDraw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDraw;
    }
}