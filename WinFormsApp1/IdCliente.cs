using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class IdCliente
    {
        private static IdCliente _instance;
        private static int idClient = -1;

        // Constructor privado para evitar instanciación directa
        private IdCliente() { }

        // Método estático para obtener la instancia única
        public static IdCliente getInstance()
        {
            if (_instance == null)
            {
                _instance = new IdCliente();
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
