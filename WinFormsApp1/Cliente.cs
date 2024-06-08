using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Cliente
    {
        private int ID;
        private string estado;
        private float tiempoLlegada;
        private float tiempoEspera;


        public Cliente(string estado, float tiempoLlegada) {
            this.estado = estado;
            this.tiempoLlegada= tiempoLlegada;
            IdCliente i = IdCliente.getInstance();
            this.ID = i.GetIdClient();
        }
        public string getEstado() { return estado; }
        public float getTiempoLlegada() { return tiempoLlegada; }

        public float getTiempoEspera() { return tiempoEspera;}

        public int getId() { return ID; }

        public void setEstado(string estado) {
            this.estado= estado;
        }

        internal bool superasteLos30Min(float v)
        {
            if ((v - this.tiempoLlegada) > 30f)
            {
                return true;
            }
            else {
                this.tiempoEspera = v - tiempoLlegada;
            }
            return false;
        }
    }
}
