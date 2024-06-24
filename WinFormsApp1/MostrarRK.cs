using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class MostrarRK : Form
    {
        private List<List<float>> rk;
        public MostrarRK(List<List<float>> rk)
        {
            InitializeComponent();
            this.rk = rk;
        }

        private void MostrarRK_Load(object sender, EventArgs e)
        {
            // Define las columnas del DataGridView
            dgvRK.ColumnCount = 8; // Número de columnas
            dgvRK.Columns[0].Name = "t(i)";
            dgvRK.Columns[1].Name = "C(i)";
            dgvRK.Columns[2].Name = "k1";
            dgvRK.Columns[3].Name = "k2";
            dgvRK.Columns[4].Name = "k3";
            dgvRK.Columns[5].Name = "k4";
            dgvRK.Columns[6].Name = "t(i+1)";
            dgvRK.Columns[7].Name = "C(i+1)";

            // Limpia cualquier fila existente en el DataGridView
            dgvRK.Rows.Clear();

            // Itera sobre la matriz y agrega las filas al DataGridView
            foreach (var fila in rk)
            {
                // Convierte la lista de floats en un array de objetos para agregarlo como fila
                object[] filaArray = fila.Cast<object>().ToArray();
                dgvRK.Rows.Add(filaArray);
            }
        }
    }
}
