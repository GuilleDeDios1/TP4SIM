using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Posicion
    {
        private Cliente cliente;
        private int posicion;

        public Posicion(Cliente cli,int posicion) {
            this.cliente = cli;
            this.posicion = posicion;
        }
        public Cliente getCliente () { 
            return cliente;
        }
        public int getPosicion()
        {
            return posicion;
        }
    }
}
