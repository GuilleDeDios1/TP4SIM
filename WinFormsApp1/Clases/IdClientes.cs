using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Clases
{
    internal class IdClientes
    {
        private static IdClientes _instance;
        private static int idClient = -1;

        // Constructor privado para evitar instanciación directa
        private IdClientes() { }

        // Método estático para obtener la instancia única
        public static IdClientes getInstance()
        {
            if (_instance == null)
            {
                _instance = new IdClientes();
            }

            idClient += 1;
            return _instance;
        }

        // Método para obtener el valor actual del idClient
        public int GetIdClient()
        {
            return idClient;
        }
    }
}
