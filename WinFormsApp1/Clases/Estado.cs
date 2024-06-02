using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Clases
{
    internal class Estado
    {
        //atributos
        private string nombre;
       

        //metodos
        public Boolean sosEstadoLibre(){
            if (nombre == "libre") {
            return true;
            }
            return false;
        }
        public Estado(string nombre)
        {
            this.nombre = nombre;
        }
        public string getNombre() {
            return this.nombre;
        }
    }
}
