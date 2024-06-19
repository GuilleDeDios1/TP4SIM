namespace WinFormsApp1
{
    partial class Estadisticas
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
            label1 = new Label();
            label2 = new Label();
            txtPorcentTiempoLibreA = new TextBox();
            txtColaMax = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 46);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 0;
            label1.Text = "Cola Maxima:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 18);
            label2.Name = "label2";
            label2.Size = new Size(137, 15);
            label2.TabIndex = 1;
            label2.Text = "% Tiempo libre aprendiz:";
            // 
            // txtPorcentTiempoLibreA
            // 
            txtPorcentTiempoLibreA.Location = new Point(153, 15);
            txtPorcentTiempoLibreA.Name = "txtPorcentTiempoLibreA";
            txtPorcentTiempoLibreA.ReadOnly = true;
            txtPorcentTiempoLibreA.Size = new Size(100, 23);
            txtPorcentTiempoLibreA.TabIndex = 2;
            // 
            // txtColaMax
            // 
            txtColaMax.Location = new Point(153, 44);
            txtColaMax.Name = "txtColaMax";
            txtColaMax.ReadOnly = true;
            txtColaMax.Size = new Size(100, 23);
            txtColaMax.TabIndex = 3;
            // 
            // Estadisticas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(265, 74);
            Controls.Add(txtColaMax);
            Controls.Add(txtPorcentTiempoLibreA);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Estadisticas";
            Text = "Estadisticas";
            Load += Estadisticas_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtPorcentTiempoLibreA;
        private TextBox txtColaMax;
    }
}