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
    public partial class Mostrar : Form
    {
        private List<List<object>> matrizMostrar;
        private int filaMax;
        public Mostrar(List<List<object>> matrizMostrar, int filaMax)
        {
            InitializeComponent();
            this.matrizMostrar= matrizMostrar;
            this.filaMax= filaMax;

        }

        private void Mostrar_Load(object sender, EventArgs e)
        {
            // Agregar columnas con nombres específicos
            string[] columnNames = { "Evento", "Dia", "Reloj", "RNDAtencion", "QuienAteiende", "RNDTiempo", "Tiempo", "TiempoLlegada", "RNDTiempo", "Tiempo", "A", "VA", "VB",
                                 "EstadoAprendiz", "ColaAprendiz", "EstadoVeteranoA", "ColaVeteranoA", "EstadoVeteranoB", "ColaVeteranoB", "TiempoLibreA", "ColaMax" };

            foreach (string columnName in columnNames)
            {
                dataGridView.Columns.Add(columnName, columnName);
            }

            // Agregar columnas sin nombre hasta filaMax
            int additionalColumns = filaMax - columnNames.Length;
            for (int i = 0; i < additionalColumns; i++)
            {
                dataGridView.Columns.Add($"columna_{i + columnNames.Length + 1}", "");
            }
            foreach (var row in matrizMostrar)
            {
                var rowData = new object[filaMax];
                row.CopyTo(rowData);
                dataGridView.Rows.Add(rowData);
            }

        }
    }
}
