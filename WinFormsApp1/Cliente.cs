using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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

        public Cliente()
        {
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
            this.tiempoEspera = v - tiempoLlegada;
            if (this.estado == "EAVA" || this.estado == "EAVB" || this.estado == "EAA") {
                if ((v - this.tiempoLlegada) > 30f)
                {
                    return true;
                }
    
            }
            return false;

        }

        public void setId(int id) {
            this.ID = id;
        }
        public void setTiempoLlegada(float tiempoLlegada) {
            this.tiempoLlegada = tiempoLlegada; 
        }
        public void setTiempoEspera(float tiempoEspera) {
            this.tiempoEspera= tiempoEspera;
        }
    }
}
