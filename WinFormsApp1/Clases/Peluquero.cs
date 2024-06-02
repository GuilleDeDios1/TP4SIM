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
        private float finAtencion = 0;
        private string nombre;
        private float rndTiempo;
        private float tiempo;
        private float tiempoLibre;
        private float tiempoPromedioOcio;
        private float tiempoTotal;
        private Estado estado;
        private Estado estadoAnterior;


        //metodos
        public Peluquero(int desde, int hasta, Estado estado) {
            this.desde = desde;
            this.hasta = hasta;
            this.estado = estado;
            this.tiempoLibre = 0;
        }

        public void cambiarCliente() { }

        public void verificarCola() { }

        public void cambiarEstadoCliente() { }

        public void setClienteAtendiendo() { }

        public void sosAprediz() { }

        public bool tenesClientesTiempoMayor(float reloj) {
            bool var = false;
            foreach (Cliente cliente in cola) {
                cliente.calcularNuevoTiempoEspera(reloj);
                if (cliente.tiempoEsperaMayor()) {
                    sacarColaCliente(cliente);
                    var = true; }
            }
            return var;
        }

        public void sacarColaCliente(Cliente cliente) {
            cola.Remove(cliente);
        }

        public void setNuevoTiempoLibre() { }

        public Object[] crearCliente (float reloj,Estado estadoLibre,Estado estadoOcupado,Estado estadoClienteAtendiendo, Estado estadoClienteEsperando) {
            if (this.sosEstadoLibre(estadoLibre))
            {
                Cliente cliente = new Cliente(estadoClienteAtendiendo, reloj);
                this.setClienteActual(cliente);
                Random random = new Random();
                Double RNDFinAtencion = random.NextDouble();
                this.calcularFinAtencion(RNDFinAtencion,reloj);
                this.setEstadoOcupado(estadoOcupado);
                Object[] a = { RNDFinAtencion, this.tiempo, this.finAtencion };
                return a;
            }
            if (!this.sosEstadoLibre(estadoLibre))
            {
                Cliente cliente = new Cliente(estadoClienteEsperando, reloj);
                this.addClienteCola(cliente);
                Object[] b = {"","",""};
                return b;
            }
            Object[] c = { "", "", "" };
            return c;
        }

        public void setClienteACtual() { }

        public void calcularFinAtencion(Double random,float reloj) {
            this.finAtencion = reloj + (desde + (float) random*(hasta - desde));
        }

        public void setEstadoOcupado(Estado ocupado) {
            this.estadoAnterior = this.estado;
            this.estado = ocupado;
        }

        public void addClienteCola(Cliente cliente) {
            cola.Add(cliente);
        }

        public void calcularTiempoLibre(float reloj,Estado estadolibre,float tiempoAnterior) {
            if (estadoAnterior == estadolibre) {
                tiempoLibre += tiempoLibre + (reloj - tiempoAnterior);
            }
        }

        public void sosNuevoTiempoLibre() { }

        public int clientesEnCola() {
            return cola.Count();
        }

        internal bool sosEstadoLibre(Estado libre)
        {
            if (this.estado == libre) {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal void setClienteActual(Cliente cliente)
        {
            this.clienteAtendiendo = cliente;
        }

        public string getNombreEstado() {
            return this.estado.getNombre();
        }

        internal object getFinAtencion()
        {
            return finAtencion;
        }

        internal float getTiempoLibre()
        {
            return tiempoLibre;
        }

        internal List<Cliente> getClientes()
        {
            List<Cliente> clientes = cola;
            clientes.Add(clienteAtendiendo);
            return clientes;
        }
    }
}
