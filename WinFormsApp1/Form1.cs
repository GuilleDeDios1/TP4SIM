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

        //estadisticas
        private int colaMax = 0;


        //para mostrar
        private List<Object> lista;
        private List<List<Object>> MatrizMostrar;

        //datosLlegadaCliente
        private double RNDAtencion;
        private string quienAtiende;
        private double RNDLlegada;
        private float tiempo;
        private float tiempoLlegada;

        private float desdeClient;
        private float hastaClient;

        //tiempo
        private float reloj;

        
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

        }

        public void finAtencion() { }

        public void verQuePeluquero() { }

        public void calcualarTiempoLibreAprendiz() { }

        public void verificarTiempoEsperaCliente() { }

        public void setlistaActual() { }

        public void borrarVariable() { }

        public void addListaMatriz() { }

        public void setProxtiempoLlegada(float tiempoLlegada) { }

        public void crearCliente() { }

        public void calcularColaMax() { }



        public void calcularTiempoLlegada()
        {
            // Crear una instancia de la clase Random
            Random random = new Random();

            // Generar un número aleatorio entre 0 y 1
            RNDAtencion = random.NextDouble();
            

            // Tomar acciones basadas en el valor aleatorio
            if (RNDAtencion < probAprendiz)
            {
                // Acción para el aprendiz
                quienAtiende = "Aprendiz";
            }
            else if (RNDAtencion < probAprendiz + probVeteranoA)
            {
                // Acción para el veterano A
                quienAtiende = "VeteranoA";
            }
            else if (RNDAtencion < probAprendiz + probVeteranoA + probVeteranoB)
            {
                // Acción para el veterano B
                quienAtiende = "VeteranoB";
            }


            //Llegada
            RNDLlegada = random.NextDouble();
            tiempo = ((hastaClient - desdeClient) * (float) RNDLlegada + desdeClient);
            tiempoLlegada = reloj + tiempo;
        }

    }
}