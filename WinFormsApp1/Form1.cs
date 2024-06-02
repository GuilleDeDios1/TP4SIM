using System;
using System.Xml.Serialization;
using WinFormsApp1.Clases;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Random random = new Random();
        //estados
        private Estado EA = new Estado("EA");
        private Estado SA = new Estado("SA");
        private Estado EVA = new Estado("EVA");
        private Estado SVA = new Estado("SVA");
        private Estado EVB = new Estado("EVB");
        private Estado SVB = new Estado("SVB");
        private Estado EstadoLibre = new Estado("Libre");
        private Estado EstadoOcupado = new Estado("Ocupado");
        
        //peluqueros
        private Peluquero Aprendiz;
        private Peluquero VeteranoA;
        private Peluquero VeteranoB;
        private float probAprendiz;
        private float probVeteranoA;
        private float probVeteranoB;

        private double RNDFinAtencion;
        private float tiempoCalcFinAtencion;
        private List<Cliente> clientesEnElSistema;

        //estadisticas
        private int colaMax = 0;


        //para mostrar
        private List<Object> lista;
        private List<List<Object>> MatrizMostrar;

        //datosLlegadaCliente
        private double RNDAtencion = 0;
        private string quienAtiende = "";
        private double RNDLlegada = 0;
        private float tiempo = 0;
        private float tiempoLlegada = 0;

        private float desdeClient;
        private float hastaClient;

        //tiempo
        private float reloj = 0;
        private float relojAnterior = 0;
        private int clienteEnCola = 0;
        private int diaAnterior = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            int desdeAprendiz = (int) txtDesdeAprendiz.Value;
            int hastaAprendiz = (int) txtHastaAprendiz.Value;
            probAprendiz = (float) txtProbApren.Value;

            int desdeVeterarnoA = (int)txtDesdeVeterA.Value;
            int hastaVeterarnoA = (int)txtHastaVeterA.Value;
            probVeteranoA = (float)txtProbVeterA.Value;

            int desdeVeterarnoB = (int)txtDesdeVeterB.Value;
            int hastaVeterarnoB = (int)txtHastaVeterB.Value;
            probVeteranoB = (float)txtProbVeterB.Value;

            Aprendiz = new Peluquero(desdeAprendiz, hastaAprendiz, EstadoLibre);
            VeteranoA = new Peluquero(desdeVeterarnoA, hastaVeterarnoA, EstadoLibre);
            VeteranoB = new Peluquero(desdeVeterarnoB, hastaVeterarnoB, EstadoLibre);

            desdeClient = (int)txtDesdeCliente.Value;
            hastaClient = (int)txtHastaCliente.Value;
        }

        public void llegadaCliente () {
            calcularTiempoLlegada();
            crearCliente();
            verificarTiempoEsperaCliente();
            calcualarTiempoLibreAprendiz();
            calcularColaMax();
            setlistaActual();
        }

        public void finAtencion() { }

        public void verQuePeluquero() { }

        public void calcualarTiempoLibreAprendiz() {
            Aprendiz.calcularTiempoLibre(reloj,EstadoLibre,relojAnterior);
        }

        public void verificarTiempoEsperaCliente() {
            Aprendiz.tenesClientesTiempoMayor(reloj);
            VeteranoA.tenesClientesTiempoMayor(reloj);
            VeteranoB.tenesClientesTiempoMayor(reloj);
        }

        public void setlistaActual() {
            lista.Add("Llegada");
            if (reloj > 8 && clienteEnCola == 0) {
                lista.Add(diaAnterior);
                diaAnterior += 1;
                reloj = 0f;
            }
            lista.Add(reloj);
            if (RNDAtencion != 0)
            {
                lista.Add(RNDAtencion);
                RNDAtencion = 0f;
            }
            else {
                lista.Add("");
            }
            if (quienAtiende != "")
            {
                lista.Add(quienAtiende);
                quienAtiende = "";
            }
            else
            {
                lista.Add("");
            }
            if (RNDLlegada != 0)
            {
                lista.Add(RNDLlegada);
                RNDLlegada = 0f;
            }
            else
            {
                lista.Add("");
            }
            if (tiempo != 0)
            {
                lista.Add(tiempo);
                tiempo = 0f;
            }
            else
            {
                lista.Add("");
            }
            if (tiempoLlegada != 0)
            {
                lista.Add(tiempoLlegada);
                tiempoLlegada = 0f;
            }
            else
            {
                lista.Add("");
            }
            lista.Add(RNDFinAtencion);
            RNDFinAtencion = 0f;
            lista.Add(tiempoCalcFinAtencion);
            tiempoCalcFinAtencion = 0f;
            lista.Add(Aprendiz.getFinAtencion());
            lista.Add(VeteranoA.getFinAtencion());
            lista.Add(VeteranoB.getFinAtencion());

            lista.Add(Aprendiz.getNombreEstado);
            lista.Add(Aprendiz.clientesEnCola);
            lista.Add(VeteranoA.getNombreEstado);
            lista.Add(VeteranoA.clientesEnCola);
            lista.Add(VeteranoB.getNombreEstado);
            lista.Add(VeteranoB.clientesEnCola);

            lista.Add(Aprendiz.getTiempoLibre());
            lista.Add(colaMax);

            List<Cliente> clientesAprendiz = Aprendiz.getClientes();
            List<Cliente> clientesVeteranoA = VeteranoA.getClientes();
            List<Cliente> clientesVeteranoB = VeteranoB.getClientes();
            
            clientesEnElSistema.AddRange(clientesAprendiz);
            clientesEnElSistema.AddRange(clientesVeteranoA);
            clientesEnElSistema.AddRange(clientesVeteranoB);

            foreach (Cliente cliente in clientesEnElSistema) {
                lista.Add((int)cliente.getId());
                lista.Add((string)cliente.getNombreEstado());
                lista.Add((float)cliente.getTiempoLlegada());
                lista.Add((float)cliente.getTiempoEspera());
            }





        }

        public void borrarVariable() { }

        public void addListaMatriz() { }

        public void setProxtiempoLlegada(float tiempoLlegada) { }

        public void crearCliente() {
            // Generar un número aleatorio entre 0 y 1
            RNDAtencion = random.NextDouble();


            // Tomar acciones basadas en el valor aleatorio
            if (RNDAtencion < probAprendiz)
            {
                // Acción para el aprendiz
                quienAtiende = "Aprendiz";
                Object[] finAtencion = Aprendiz.crearCliente(reloj,EstadoLibre,EstadoOcupado,SA,EA);
                RNDFinAtencion = (float)finAtencion[0];
                tiempoCalcFinAtencion = (float)finAtencion[0];
            }
            else if (RNDAtencion < probAprendiz + probVeteranoA)
            {
                // Acción para el veterano A
                quienAtiende = "VeteranoA";
                Object[] finAtencion = VeteranoA.crearCliente(reloj, EstadoLibre, EstadoOcupado, SVA, EVA);
                RNDFinAtencion = (float)finAtencion[0];
                tiempoCalcFinAtencion = (float)finAtencion[0];
            }
            else if (RNDAtencion < probAprendiz + probVeteranoA + probVeteranoB)
            {
                // Acción para el veterano B
                quienAtiende = "VeteranoB";
                Object[] finAtencion = VeteranoB.crearCliente(reloj, EstadoLibre, EstadoOcupado, SVB, EVB);
                RNDFinAtencion = (float)finAtencion[0];
                tiempoCalcFinAtencion = (float)finAtencion[0];
            }


        }
        public void calcularColaMax() {
            int colaApren = Aprendiz.clientesEnCola();
            int colaVeteranoA = VeteranoA.clientesEnCola();
            int colaVeteranoB = VeteranoB.clientesEnCola();
            if (colaApren > colaMax) {
                colaMax = colaApren;
            }
            if (colaVeteranoA > colaMax)
            {
                colaMax = colaVeteranoA;
            }
            if (colaVeteranoB > colaMax)
            {
                colaMax = colaVeteranoB;
            }
            clienteEnCola = colaApren + colaVeteranoA + colaVeteranoB;
        }



        public void calcularTiempoLlegada()
        {
            //Llegada
            RNDLlegada = random.NextDouble();
            tiempo = ((hastaClient - desdeClient) * (float) RNDLlegada + desdeClient);
            tiempoLlegada = reloj + tiempo;
        }

    }
}