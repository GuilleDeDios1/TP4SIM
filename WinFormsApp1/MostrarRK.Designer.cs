namespace WinFormsApp1
{
    partial class MostrarRK
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
            this.dgvRK = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRK)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRK
            // 
            this.dgvRK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRK.Location = new System.Drawing.Point(0, 0);
            this.dgvRK.Name = "dgvRK";
            this.dgvRK.RowTemplate.Height = 25;
            this.dgvRK.Size = new System.Drawing.Size(800, 450);
            this.dgvRK.TabIndex = 0;
            // 
            // MostrarRK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvRK);
            this.Name = "MostrarRK";
            this.Text = "MostrarRK";
            this.Load += new System.EventHandler(this.MostrarRK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRK)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvRK;
    }
}