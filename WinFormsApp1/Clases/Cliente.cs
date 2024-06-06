using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Clases
{
    internal class Cliente
    {
        //atributos
        private float tiempoEspera;
        private float tiempoLlegada;
        private Estado estadoAnterior;
        private Estado estado;
        private int id;


        public Cliente(Estado SA, float reloj)
        {
            this.estado = SA;
            this.tiempoLlegada = reloj;
            IdClientes i = IdClientes.getInstance();
            id = i.GetIdClient();
        }

        //metodos
        public void newEstSA(string nomPelu)  //tiene que retornar Cliente
        {

        }

        public void newEstEA(string nomPelu) { //tiene que retornar Cliente
        
        }

        public void calcularNuevoTiempoEspera(float reloj) {
            this.tiempoEspera = reloj - tiempoLlegada;
        }

        public bool tiempoEsperaMayor() {
            if (tiempoEspera > 0.5f) {
                return true;
            }
            return false;
        }

        public void setEstadoSA(Estado SA)
        {
            this.estadoAnterior = this.estado;
            this.estado = SA;
        }

        public void setEstadoSVA(Estado SVA)
        {
            this.estadoAnterior = this.estado;
            this.estado = SVA;
        }

        public void setEstadoSVB(Estado SVB)
        {
            this.estadoAnterior = this.estado;
            this.estado = SVB;
        }

        internal int getId()
        {
            return this.id;
        }

        internal string getNombreEstado()
        {
            return this.estado.getNombre();
        }

        internal float getTiempoLlegada()
        {
            return this.tiempoLlegada;
        }

        internal float getTiempoEspera()
        {
            return this.tiempoEspera;
        }
    }
}
