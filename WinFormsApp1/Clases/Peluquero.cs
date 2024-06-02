using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Clases
{
    internal class Peluquero
    {
        //atributos
        private Cliente clienteAtendiendo;
        private List<Cliente> cola;
        private int desde;
        private int hasta;
        private float finAtencion;
        private string nombre;
        private float rndTiempo;
        private float tiempo;
        private float tiempoLibre;
        private float tiempoPromedioOcio;
        private float tiempoTotal;
        private Estado estado;


        //metodos
        public Peluquero(int desde, int hasta,Estado estado) { 
            this.desde= desde;
            this.hasta= hasta;
            this.estado= estado;
            this.tiempoLibre = 0;
        }

        public void cambiarCliente() { }

        public void verificarCola() { }

        public void setEstadoLibre() { }

        public void cambiarEstadoCliente() { }

        public void setClienteAtendiendo() { }

        public void sosAprediz() { }

        public void tenesClientesTiempoMayor() { }

        public void sacarColaCliente() { }

        public void setNuevoTiempoLibre() { }

        public void crearCliente(float reloj) { }

        public void setClienteACtual() { }

        public void calcularFinAtencion() { }

        public void setEstadoOcupado() { }

        public void addClienteCola() { }

        public void calcularTiempoLibre() { }

        public void sosNuevoTiempoLibre() { }

        public void clientesEnCola() { }
    }
}
