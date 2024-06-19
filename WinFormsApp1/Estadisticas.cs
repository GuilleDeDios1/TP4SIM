using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Estadisticas : Form
    {
        private float porcent;
        private int colaMax;
        public Estadisticas(float porcent, int colaMax)
        {
            InitializeComponent();
            this.porcent = porcent;
            this.colaMax = colaMax;
        }

        private void Estadisticas_Load(object sender, EventArgs e)
        {
            this.txtPorcentTiempoLibreA.Text = porcent.ToString();
            txtColaMax.Text = colaMax.ToString();
        }
    }
}
