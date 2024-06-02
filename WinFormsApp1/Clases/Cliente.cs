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
        private Estado sA;
        private int id;

        public Cliente(Estado sA, float reloj)
        {
            this.sA = sA;
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

        public void setEstadoSA(Estado estado) {
        
        }

        internal int getId()
        {
            return this.id;
        }

        internal string getNombreEstado()
        {
            return this.sA.getNombre();
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
