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
        private List<Cliente> cola = new List<Cliente>();
        private int desde;
        private int hasta;
        private float finAtencion = 0f;
        private string nombre;
        private float tiempo;
        private float tiempoLibre;
        private Estado estado;
        private Estado estadoAnterior;


        //metodos
        public Peluquero(int desde, int hasta, Estado estado) {
            this.desde = desde;
            this.hasta = hasta;
            this.estado = estado;
            this.tiempoLibre = 0;
        }

        public int finAtencionCliente(Estado Libre, Estado Ocupado, Estado SA, Estado SVA, Estado SVB, float reloj, double RNDFinAtencion) 
        {
            int colaAtencion = this.clientesEnCola();
            int id;
            if(colaAtencion == 0)
            {
                this.setEstadoLibre(Libre);
                id = clienteAtendiendo.getId();
                clienteAtendiendo = null;
                finAtencion = 0f;
            }
            else
            {
                this.setEstadoOcupado(Ocupado);
                cambiarEstadoCliente(cola[0], SA, SVA, SVB);
                id = clienteAtendiendo.getId();
                clienteAtendiendo = cola[0];
                this.calcularFinAtencion(RNDFinAtencion, reloj);
                cola.Remove(cola[0]);
            }
            return id;
        }

        public void cambiarEstadoCliente(Cliente cliente, Estado SA, Estado SVA, Estado SVB)
        { 
            if(this.nombre == "Aprendiz")
            {
                cliente.setEstadoSA(SA);
            }
            if(this.nombre == "VeteranoA")
            {
                cliente.setEstadoSVA(SVA);
            }
            if(this.nombre == "VeteranoB")
            {
                cliente.setEstadoSVB(SVB);
            }
        }

        public void setClienteAtendiendo() { }

        public bool tenesClientesTiempoMayor(float reloj) {
            bool var = false;
            List<Cliente> colaCopy = new List<Cliente>(cola); ;
            foreach (Cliente cliente in colaCopy) {
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
                Object[] a = { (float)RNDFinAtencion, this.tiempo, this.finAtencion };
                return a;
            }
            if (!this.sosEstadoLibre(estadoLibre))
            {
                Cliente cliente = new Cliente(estadoClienteEsperando, reloj);
                this.addClienteCola(cliente);
                Object[] b = {0f,0f,0f};
                return b;
            }
            Object[] c = { 0f, 0f,0f};
            return c;
        }

        public void setClienteACtual() { }

        public void calcularFinAtencion(Double random,float reloj) {
            this.tiempo = (desde + (float)random * (hasta - desde));
            this.finAtencion = reloj + tiempo;
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

        public void setEstadoLibre(Estado Libre)
        {
            this.estadoAnterior = this.estado;
            this.estado = Libre;
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
            if (clienteAtendiendo != null)
            {
                clientes.Add(clienteAtendiendo);
            }
            return clientes;
        }
    }
}
