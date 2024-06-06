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

        int filaMax = 0;
        
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
        private List<Cliente> clientesEnElSistema = new List<Cliente>();

        //estadisticas
        private int colaMax = 0;


        //para mostrar
        private List<Object> lista = new List<object>();
        private List<List<Object>> MatrizMostrar = new List<List<object>>();

        //datosLlegadaCliente
        private double RNDAtencion = 0;
        private string quienAtiende = "";
        private double RNDLlegada = 0;
        private float tiempo = 0;
        private float tiempoLlegada = 0;

        private float desdeClient;
        private float hastaClient;

        //datos Fin Atencion
        private Peluquero quienAtendio;

        //tiempo
        private float reloj = 0;
        private float relojAnterior = 0;
        private int clienteEnCola = 0;
        private int diaAnterior = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }

        public void llegadaCliente ()
        {
            calcularTiempoLlegada();
            crearCliente();
            verificarTiempoEsperaCliente();
            calcualarTiempoLibreAprendiz();
            calcularColaMax();
            setlistaActual();
        }

        public void finAtencion()
        {
            verQuePeluquero();
            RNDFinAtencion = random.NextDouble();
            int id = quienAtendio.finAtencionCliente(EstadoLibre, EstadoOcupado, SA, SVA, SVB, reloj, RNDFinAtencion);
            if (quienAtendio.sosEstadoLibre(EstadoLibre))
            {
                RNDFinAtencion = 0f;
                tiempo = 0f;
            }
            verificarTiempoEsperaCliente();
            calcualarTiempoLibreAprendiz();
            setListaActualCU2(id);
        }

        public void setListaActualCU2(int id)
        {
            lista.Add("Fin Atencion cli " + id.ToString());
            if (reloj > 8 && clienteEnCola == 0)
            {
                lista.Add(diaAnterior);
                diaAnterior += 1;
                reloj = 0f;
                tiempoCalcFinAtencion = 0f;
            }
            lista.Add(reloj);
            lista.Add("");
            lista.Add("");
            lista.Add("");
            lista.Add("");
            lista.Add(tiempoLlegada);
            lista.Add(RNDFinAtencion);
            lista.Add(tiempo);
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

            foreach (Cliente cliente in clientesEnElSistema)
            {
                lista.Add((int)cliente.getId());
                lista.Add((string)cliente.getNombreEstado());
                lista.Add((float)cliente.getTiempoLlegada());
                lista.Add((float)cliente.getTiempoEspera());
            }

            addListaMatriz(lista);
        }
        public void verQuePeluquero() 
        {
            float finAtencionA = (float)Aprendiz.getFinAtencion();
            float finAtencionVA = (float)VeteranoA.getFinAtencion();
            float finAtencionVB = (float)VeteranoB.getFinAtencion();

            if (finAtencionA < finAtencionVA)
            {
                if (finAtencionA < finAtencionVB)
                {
                    quienAtendio = Aprendiz;
                }
                else
                {
                    quienAtendio = VeteranoB;
                }
            }
            else
            {
                if (finAtencionVA < finAtencionVB)
                {
                    quienAtendio = VeteranoA;
                }
                else
                {
                    quienAtendio = VeteranoB;
                }
            }
        }

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

            addListaMatriz(lista);
        }

        public void addListaMatriz(List<Object> lista)
        {
            if (filaMax < lista.Count) {
                filaMax = lista.Count;
            }
            MatrizMostrar.Add(lista);
        }

        public void setProxtiempoLlegada(float tiempoLlegada) { }

        public void crearCliente() {
            // Generar un número aleatorio entre 0 y 1
            RNDAtencion = random.NextDouble();


            // Tomar acciones basadas en el valor aleatorio
            if (RNDAtencion < probAprendiz)
            {
                // Acción para el aprendiz
                quienAtiende = "Aprendiz";
                Object[] ArrayfinAtencion = Aprendiz.crearCliente(reloj,EstadoLibre,EstadoOcupado,SA,EA);
                RNDFinAtencion = (float)ArrayfinAtencion[0];
                tiempo = (float)ArrayfinAtencion[1];
                tiempoCalcFinAtencion = (float)ArrayfinAtencion[2];
            }
            else if (RNDAtencion < probAprendiz + probVeteranoA)
            {
                // Acción para el veterano A
                quienAtiende = "VeteranoA";
                Object[] ArrayfinAtencion = VeteranoA.crearCliente(reloj, EstadoLibre, EstadoOcupado, SVA, EVA);
                RNDFinAtencion = (float)ArrayfinAtencion[0];
                tiempo = (float)ArrayfinAtencion[1];
                tiempoCalcFinAtencion = (float)ArrayfinAtencion[2];
            }
            else if (RNDAtencion < probAprendiz + probVeteranoA + probVeteranoB)
            {
                // Acción para el veterano B
                quienAtiende = "VeteranoB";
                Object[] ArrayfinAtencion = VeteranoB.crearCliente(reloj, EstadoLibre, EstadoOcupado, SVB, EVB);
                RNDFinAtencion = (float)ArrayfinAtencion[0];
                tiempo = (float)ArrayfinAtencion[1];
                tiempoCalcFinAtencion = (float)ArrayfinAtencion[2];
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

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            int desdeAprendiz = (int)txtDesdeAprendiz.Value;
            int hastaAprendiz = (int)txtHastaAprendiz.Value;
            probAprendiz = float.Parse(txtProbApren.Text);

            int desdeVeterarnoA = (int)txtDesdeVeterA.Value;
            int hastaVeterarnoA = (int)txtHastaVeterA.Value;
            probVeteranoA = float.Parse(txtProbVeterA.Text);

            int desdeVeterarnoB = (int)txtDesdeVeterB.Value;
            int hastaVeterarnoB = (int)txtHastaVeterB.Value;
            probVeteranoB = float.Parse(txtProbVeterB.Text);

            Aprendiz = new Peluquero(desdeAprendiz, hastaAprendiz, EstadoLibre);
            VeteranoA = new Peluquero(desdeVeterarnoA, hastaVeterarnoA, EstadoLibre);
            VeteranoB = new Peluquero(desdeVeterarnoB, hastaVeterarnoB, EstadoLibre);

            desdeClient = (int)txtDesdeCliente.Value;
            hastaClient = (int)txtHastaCliente.Value;

            
            while(true)
            {
                if (reloj > (diaAnterior*1440)+(float)txtTiempoSumu.Value)
                {
                    Mostrar mostrar = new Mostrar(MatrizMostrar, filaMax);
                    mostrar.Show();
                    this.Hide();
                }
                if ((float)Aprendiz.getFinAtencion() == 0f && (float)VeteranoA.getFinAtencion() == 0f && (float)VeteranoB.getFinAtencion() == 0f)
                {
                    llegadaCliente();
                }
                else {
                    if (tiempoLlegada < (float)Aprendiz.getFinAtencion() || tiempoLlegada < (float)VeteranoA.getFinAtencion() || tiempoLlegada < (float)VeteranoB.getFinAtencion())
                    {
                        reloj += tiempoLlegada;
                        llegadaCliente();
                    }
                    else
                    {
                        reloj += tiempoCalcFinAtencion;
                        finAtencion();
                    }
                }
                
            }

        }
    }
}