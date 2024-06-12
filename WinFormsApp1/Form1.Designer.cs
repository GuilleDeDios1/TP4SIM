namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbPeluqueros = new System.Windows.Forms.GroupBox();
            this.txtProbVeterB = new System.Windows.Forms.TextBox();
            this.txtProbVeterA = new System.Windows.Forms.TextBox();
            this.txtProbApren = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHastaVeterB = new System.Windows.Forms.NumericUpDown();
            this.txtHastaVeterA = new System.Windows.Forms.NumericUpDown();
            this.txtHastaAprendiz = new System.Windows.Forms.NumericUpDown();
            this.txtDesdeVeterB = new System.Windows.Forms.NumericUpDown();
            this.txtDesdeVeterA = new System.Windows.Forms.NumericUpDown();
            this.txtDesdeAprendiz = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtHastaItera = new System.Windows.Forms.TextBox();
            this.txtDesdeItera = new System.Windows.Forms.TextBox();
            this.txtTiempoSumu = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtHastaCliente = new System.Windows.Forms.NumericUpDown();
            this.txtDesdeCliente = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.gbPeluqueros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHastaVeterB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHastaVeterA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHastaAprendiz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesdeVeterB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesdeVeterA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesdeAprendiz)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHastaCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesdeCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // gbPeluqueros
            // 
            this.gbPeluqueros.Controls.Add(this.txtProbVeterB);
            this.gbPeluqueros.Controls.Add(this.txtProbVeterA);
            this.gbPeluqueros.Controls.Add(this.txtProbApren);
            this.gbPeluqueros.Controls.Add(this.label10);
            this.gbPeluqueros.Controls.Add(this.label9);
            this.gbPeluqueros.Controls.Add(this.label8);
            this.gbPeluqueros.Controls.Add(this.label7);
            this.gbPeluqueros.Controls.Add(this.txtHastaVeterB);
            this.gbPeluqueros.Controls.Add(this.txtHastaVeterA);
            this.gbPeluqueros.Controls.Add(this.txtHastaAprendiz);
            this.gbPeluqueros.Controls.Add(this.txtDesdeVeterB);
            this.gbPeluqueros.Controls.Add(this.txtDesdeVeterA);
            this.gbPeluqueros.Controls.Add(this.txtDesdeAprendiz);
            this.gbPeluqueros.Controls.Add(this.label6);
            this.gbPeluqueros.Controls.Add(this.label5);
            this.gbPeluqueros.Controls.Add(this.label4);
            this.gbPeluqueros.Location = new System.Drawing.Point(12, 193);
            this.gbPeluqueros.Name = "gbPeluqueros";
            this.gbPeluqueros.Size = new System.Drawing.Size(288, 160);
            this.gbPeluqueros.TabIndex = 0;
            this.gbPeluqueros.TabStop = false;
            this.gbPeluqueros.Text = "Peluqueros";
            // 
            // txtProbVeterB
            // 
            this.txtProbVeterB.Location = new System.Drawing.Point(233, 130);
            this.txtProbVeterB.Name = "txtProbVeterB";
            this.txtProbVeterB.Size = new System.Drawing.Size(43, 23);
            this.txtProbVeterB.TabIndex = 19;
            this.txtProbVeterB.Text = "0,50";
            this.txtProbVeterB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProbVeterB_KeyPress);
            // 
            // txtProbVeterA
            // 
            this.txtProbVeterA.Location = new System.Drawing.Point(233, 92);
            this.txtProbVeterA.Name = "txtProbVeterA";
            this.txtProbVeterA.Size = new System.Drawing.Size(43, 23);
            this.txtProbVeterA.TabIndex = 18;
            this.txtProbVeterA.Text = "0,25";
            this.txtProbVeterA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProbVeterA_KeyPress);
            // 
            // txtProbApren
            // 
            this.txtProbApren.Location = new System.Drawing.Point(233, 57);
            this.txtProbApren.Name = "txtProbApren";
            this.txtProbApren.Size = new System.Drawing.Size(43, 23);
            this.txtProbApren.TabIndex = 17;
            this.txtProbApren.Text = "0,25";
            this.txtProbApren.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProbApren_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(139, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 15);
            this.label10.TabIndex = 16;
            this.label10.Text = "Distr Uni";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(233, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "Prob";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(175, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "Hasta";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(112, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Desde";
            // 
            // txtHastaVeterB
            // 
            this.txtHastaVeterB.Location = new System.Drawing.Point(175, 130);
            this.txtHastaVeterB.Name = "txtHastaVeterB";
            this.txtHastaVeterB.Size = new System.Drawing.Size(43, 23);
            this.txtHastaVeterB.TabIndex = 9;
            this.txtHastaVeterB.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // txtHastaVeterA
            // 
            this.txtHastaVeterA.Location = new System.Drawing.Point(175, 92);
            this.txtHastaVeterA.Name = "txtHastaVeterA";
            this.txtHastaVeterA.Size = new System.Drawing.Size(43, 23);
            this.txtHastaVeterA.TabIndex = 8;
            this.txtHastaVeterA.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // txtHastaAprendiz
            // 
            this.txtHastaAprendiz.Location = new System.Drawing.Point(175, 57);
            this.txtHastaAprendiz.Name = "txtHastaAprendiz";
            this.txtHastaAprendiz.Size = new System.Drawing.Size(43, 23);
            this.txtHastaAprendiz.TabIndex = 7;
            this.txtHastaAprendiz.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // txtDesdeVeterB
            // 
            this.txtDesdeVeterB.Location = new System.Drawing.Point(112, 130);
            this.txtDesdeVeterB.Name = "txtDesdeVeterB";
            this.txtDesdeVeterB.Size = new System.Drawing.Size(43, 23);
            this.txtDesdeVeterB.TabIndex = 6;
            this.txtDesdeVeterB.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // txtDesdeVeterA
            // 
            this.txtDesdeVeterA.Location = new System.Drawing.Point(112, 92);
            this.txtDesdeVeterA.Name = "txtDesdeVeterA";
            this.txtDesdeVeterA.Size = new System.Drawing.Size(43, 23);
            this.txtDesdeVeterA.TabIndex = 4;
            this.txtDesdeVeterA.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // txtDesdeAprendiz
            // 
            this.txtDesdeAprendiz.Location = new System.Drawing.Point(112, 57);
            this.txtDesdeAprendiz.Name = "txtDesdeAprendiz";
            this.txtDesdeAprendiz.Size = new System.Drawing.Size(43, 23);
            this.txtDesdeAprendiz.TabIndex = 3;
            this.txtDesdeAprendiz.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Veterano B";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Veterano A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Aprendiz";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tiempo Simulacion(horas)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Desde Iteracion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hasta Iteracion";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.txtHastaItera);
            this.groupBox1.Controls.Add(this.txtDesdeItera);
            this.groupBox1.Controls.Add(this.txtTiempoSumu);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 175);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Simulacion";
            // 
            // txtHastaItera
            // 
            this.txtHastaItera.Location = new System.Drawing.Point(166, 111);
            this.txtHastaItera.Name = "txtHastaItera";
            this.txtHastaItera.Size = new System.Drawing.Size(100, 23);
            this.txtHastaItera.TabIndex = 9;
            this.txtHastaItera.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHastaItera_KeyPress);
            // 
            // txtDesdeItera
            // 
            this.txtDesdeItera.Location = new System.Drawing.Point(166, 69);
            this.txtDesdeItera.Name = "txtDesdeItera";
            this.txtDesdeItera.Size = new System.Drawing.Size(100, 23);
            this.txtDesdeItera.TabIndex = 8;
            this.txtDesdeItera.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDesdeItera_KeyPress);
            // 
            // txtTiempoSumu
            // 
            this.txtTiempoSumu.Location = new System.Drawing.Point(166, 28);
            this.txtTiempoSumu.Name = "txtTiempoSumu";
            this.txtTiempoSumu.Size = new System.Drawing.Size(100, 23);
            this.txtTiempoSumu.TabIndex = 7;
            this.txtTiempoSumu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTiempoSumu_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtHastaCliente);
            this.groupBox2.Controls.Add(this.txtDesdeCliente);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Location = new System.Drawing.Point(12, 359);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 97);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cliente";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(166, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 15);
            this.label11.TabIndex = 22;
            this.label11.Text = "Distr Uni";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(216, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 15);
            this.label12.TabIndex = 21;
            this.label12.Text = "Hasta";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(122, 38);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 15);
            this.label13.TabIndex = 20;
            this.label13.Text = "Desde";
            // 
            // txtHastaCliente
            // 
            this.txtHastaCliente.Location = new System.Drawing.Point(205, 56);
            this.txtHastaCliente.Name = "txtHastaCliente";
            this.txtHastaCliente.Size = new System.Drawing.Size(60, 23);
            this.txtHastaCliente.TabIndex = 19;
            this.txtHastaCliente.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // txtDesdeCliente
            // 
            this.txtDesdeCliente.Location = new System.Drawing.Point(122, 56);
            this.txtDesdeCliente.Name = "txtDesdeCliente";
            this.txtDesdeCliente.Size = new System.Drawing.Size(56, 23);
            this.txtDesdeCliente.TabIndex = 18;
            this.txtDesdeCliente.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 58);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 15);
            this.label14.TabIndex = 17;
            this.label14.Text = "Llegada Cliente";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(219, 474);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 9;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(57, 150);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(181, 19);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Mostrar simulacion completa";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 509);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbPeluqueros);
            this.Name = "Form1";
            this.Text = "Peluqueria";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbPeluqueros.ResumeLayout(false);
            this.gbPeluqueros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHastaVeterB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHastaVeterA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHastaAprendiz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesdeVeterB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesdeVeterA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesdeAprendiz)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHastaCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesdeCliente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox gbPeluqueros;
        private Label label1;
        private Label label2;
        private Label label3;
        private GroupBox groupBox1;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private NumericUpDown txtHastaVeterB;
        private NumericUpDown txtHastaVeterA;
        private NumericUpDown txtHastaAprendiz;
        private NumericUpDown txtDesdeVeterB;
        private NumericUpDown txtDesdeVeterA;
        private NumericUpDown txtDesdeAprendiz;
        private Label label6;
        private Label label5;
        private Label label4;
        private GroupBox groupBox2;
        private Label label11;
        private Label label12;
        private Label label13;
        private NumericUpDown txtHastaCliente;
        private NumericUpDown txtDesdeCliente;
        private Label label14;
        private Button btnGenerar;
        private TextBox txtProbVeterB;
        private TextBox txtProbApren;
        private TextBox txtProbVeterA;
        private TextBox txtHastaItera;
        private TextBox txtDesdeItera;
        private TextBox txtTiempoSumu;
        private CheckBox checkBox1;
    }
}