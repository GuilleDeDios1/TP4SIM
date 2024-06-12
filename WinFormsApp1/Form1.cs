using System;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Random random = new Random();

        //para mostrar
        private List<Object> lista = new List<object>();
        private List<Object> listaAnterior = new List<object>();
        private List<List<Object>> MatrizMostrar = new List<List<object>>();

        //datosLlegadaCliente
        private int desdeClient;
        private int hastaClient;

        private int desdeAprendiz;
        private int hastaAprendiz;
        private float probAprendiz;

        private int desdeVeterarnoA;
        private int hastaVeterarnoA;
        private float probVeteranoA;

        private int desdeVeterarnoB;
        private int hastaVeterarnoB;
        private float probVeteranoB;

        private float timmpoSimu;
        private float desdeItera;
        private float hastaItera;

        private int filaMax;

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            desdeAprendiz = (int)txtDesdeAprendiz.Value;
            hastaAprendiz = (int)txtHastaAprendiz.Value;
            probAprendiz = float.Parse(txtProbApren.Text);

            desdeVeterarnoA = (int)txtDesdeVeterA.Value;
            hastaVeterarnoA = (int)txtHastaVeterA.Value;
            probVeteranoA = float.Parse(txtProbVeterA.Text);

            desdeVeterarnoB = (int)txtDesdeVeterB.Value;
            hastaVeterarnoB = (int)txtHastaVeterB.Value;
            probVeteranoB = float.Parse(txtProbVeterB.Text);


            desdeClient = (int)txtDesdeCliente.Value;
            hastaClient = (int)txtHastaCliente.Value;

            timmpoSimu = (float.Parse(txtTiempoSumu.Text) * 60f);

            desdeItera = int.Parse(txtDesdeItera.Text);

            hastaItera = int.Parse(txtHastaItera.Text);

            if((probVeteranoA + probVeteranoB + probAprendiz) == 1f)
            {
                simular();

                if (MatrizMostrar.Count() >= (desdeItera + hastaItera))
                {
                    List<List<object>> subMatrix = MatrizMostrar.GetRange((int)desdeItera, (int)hastaItera);
                    if (checkBox1.Checked) {
                        Mostrar mostrar = new Mostrar(MatrizMostrar, filaMax);
                        mostrar.Show();
                    }
                    else {
                        Mostrar mostrar = new Mostrar(subMatrix, filaMax);
                        mostrar.Show();
                    }
                }
                else
                {
                    MessageBox.Show("La simulacion no alcanzo las lineas a mostrar");
                }
            }
            else
            {
                MessageBox.Show("La suma de probabilidades no da 1");
            }

            
        }
        public void mostrar(List<List<Object>> matrizMostrar)
        {
            Mostrar mostrar = new Mostrar(MatrizMostrar, filaMax);
            mostrar.Show();
        }

        public void simular()
        {
            bool setEstadoOcupadoAprendiz = false;
            bool vanderaLlenoLlegadaCliente = false;
            bool setEstadoOcupadoVeteranoA = false;
            bool setEstadoOcupadoVeteranoB = false;
            bool incrementarColaApre = false;
            bool incrementarColaVeteA = false;
            bool incrementarColaVeteB = false;
            bool setEstadoLibreAprendiz = false;
            bool setEstadoLibreVeteA = false;
            bool setEstadoLibreVeteB = false;
            bool decrementaColaApre = false;
            bool decrementaColaVeteA = false;
            bool decrementaColaVeteB = false;
            float tiempoLibreAprendiz = 0;
            int colaMax = 0;
            bool esLlegadaCliente = false;
            bool esFinAtencion = false;
            List<Cliente> listaCliente = new List<Cliente>();
            bool atiendeAprendiz = false;
            bool atiendeVeteA = false;
            bool atiendeVeteB = false;
            float acumuladorMinutos = 0f;
            bool seVaElAtendidoPorVA = false;
            bool seVaElAtendidoPorVB = false;
            bool seVaElAtendidoPorA = false;
            int contadorDia = 0;
            bool bastaClientes = false;

            for (int i = 0; acumuladorMinutos < timmpoSimu; i++)
            {
                //agrega evento
                if (i == 0)
                {
                    lista.Add("Inicializar");
                }
                //agrega evento
                else
                {
                    float llegadaVeteranoa = (float)listaAnterior[10];
                    float llegadaVeteranoB = (float)listaAnterior[11];
                    float llegadaAprendis = (float)listaAnterior[12];
                    float LlegadaCliente = (float)listaAnterior[7];
                    List<float> variables = new List<float> { (float)llegadaVeteranoa, (float)llegadaVeteranoB, (float)llegadaAprendis, (float)LlegadaCliente };
                    List<float> variablesNoCero = variables.Where(v => v != 0f).ToList();
                    // Encontrar el valor mínimo de la lista que no tiene ceros
                    float? minimo = variablesNoCero.Count > 0 ? (float?)variablesNoCero.Min() : null;

                    if (minimo.HasValue && minimo == LlegadaCliente && !bastaClientes)
                    {
                        // Ejecutar las líneas de código solamente si LlegadaCliente es la menor entre las variables que no son 0
                        lista.Add("LlegadaCliente");
                        esLlegadaCliente = true;
                        //Para Fin Atencion
                    }
                    else
                    {
                        lista.Add("FinAtencion");
                        esFinAtencion = true;
                    }

                }
                //reloj dia
                lista.Add(contadorDia);

                //reloj minutos
                if (i == 0)
                {
                    lista.Add(0f);
                }
                else
                {
                    //verifica en la lista anterior cual es el menor tiempo

                    float finAtencionVeteranoA = (float)listaAnterior[10];
                    float finAtencionVeteranoB = (float)listaAnterior[11];
                    float finAtencionAprendiz = (float)listaAnterior[12];
                    float LlegadaCliente = (float)listaAnterior[7];
                    List<float> variables = new List<float> { (float)finAtencionVeteranoA, (float)finAtencionVeteranoB, (float)finAtencionAprendiz, (float)LlegadaCliente };
                    List<float> variablesNoCero = variables.Where(v => v != 0f).ToList();
                    // Encontrar el valor mínimo de la lista que no tiene ceros
                    float? minimo = variablesNoCero.Count > 0 ? (float?)variablesNoCero.Min() : null;

                    if (minimo.HasValue && minimo == LlegadaCliente && !bastaClientes)
                    {
                        lista.Add((float)listaAnterior[7]);
                    }
                    else
                    {
                        if (minimo.HasValue && minimo == finAtencionVeteranoA)
                        {
                            lista.Add((float)listaAnterior[10]);
                            seVaElAtendidoPorVA = true;
                        }
                        else if (minimo.HasValue && minimo == finAtencionVeteranoB)
                        {
                            lista.Add((float)listaAnterior[11]);
                            seVaElAtendidoPorVB = true;
                        }
                        else
                        {
                            lista.Add((float)listaAnterior[12]);
                            seVaElAtendidoPorA = true;
                        }
                    }
                }

                //RNDQuienAtiende
                if (i == 0)
                {
                    lista.Add(0f);
                    lista.Add(0f);
                }
                else
                {
                    //para llegadaCliente
                    float llegadaVeteranoa = (float)listaAnterior[10];
                    float llegadaVeteranoB = (float)listaAnterior[11];
                    float llegadaAprendis = (float)listaAnterior[12];
                    float LlegadaCliente = (float)listaAnterior[7];
                    List<float> variables = new List<float> { (float)llegadaVeteranoa, (float)llegadaVeteranoB, (float)llegadaAprendis, (float)LlegadaCliente };
                    List<float> variablesNoCero = variables.Where(v => v != 0f).ToList();
                    // Encontrar el valor mínimo de la lista que no tiene ceros
                    float? minimo = variablesNoCero.Count > 0 ? (float?)variablesNoCero.Min() : null;

                    if (minimo.HasValue && minimo == LlegadaCliente && !bastaClientes)
                    {
                        float randomQuienAtiende = (float)random.NextDouble();
                        lista.Add(randomQuienAtiende);

                        if (randomQuienAtiende < probAprendiz)
                        {
                            lista.Add("Aprendiz");
                            atiendeAprendiz = true;
                        }
                        else
                        {
                            if (randomQuienAtiende < probAprendiz + probVeteranoA)
                            {
                                lista.Add("VeteranoA");
                                atiendeVeteA = true;
                            }
                            else
                            {
                                if (randomQuienAtiende < probAprendiz + probVeteranoA + probVeteranoB)
                                {
                                    lista.Add("VeteranoB");
                                    atiendeVeteB = true;
                                }
                            }
                        }
                    }
                    //Para Fin Atencion
                    else
                    {
                        if ((string)lista[0] == "FinAtencion" && !bastaClientes)
                        {
                            lista.Add(0f);
                            lista.Add(0f);
                            lista.Add(0f);
                            lista.Add(0f);
                            lista.Add(listaAnterior[7]);
                            vanderaLlenoLlegadaCliente = true;
                        }
                        else
                        {
                            lista.Add(0f);
                            lista.Add(0f);
                            lista.Add(0f);
                            lista.Add(0f);
                            lista.Add(0f);
                            vanderaLlenoLlegadaCliente = true;
                        }
                    }
                }
                //RNDTiempoLlegada
                if (!vanderaLlenoLlegadaCliente)
                {
                    float randomTiempoLlegada = (float)random.NextDouble();
                    lista.Add(randomTiempoLlegada);
                    float tiempo = desdeClient + randomTiempoLlegada * (hastaClient - desdeClient);
                    lista.Add(tiempo);
                    lista.Add(tiempo + (float)lista[2]);
                }
                //finAtencion
                if (i == 0)
                {
                    lista.Add(0f);
                    lista.Add(0f);
                    lista.Add(0f);
                    lista.Add(0f);
                    lista.Add(0f);
                }
                else
                {
                    //ve si es llegada de cliente
                    //
                    //

                    float llegadaVeteranoa = (float)listaAnterior[10];
                    float llegadaVeteranoB = (float)listaAnterior[11];
                    float llegadaAprendis = (float)listaAnterior[12];
                    float LlegadaCliente = (float)listaAnterior[7];
                    List<float> variables = new List<float> { (float)llegadaVeteranoa, (float)llegadaVeteranoB, (float)llegadaAprendis, (float)LlegadaCliente };
                    List<float> variablesNoCero = variables.Where(v => v != 0f).ToList();
                    // Encontrar el valor mínimo de la lista que no tiene ceros
                    float? minimo = variablesNoCero.Count > 0 ? (float?)variablesNoCero.Min() : null;

                    if (minimo.HasValue && minimo == LlegadaCliente && !bastaClientes)
                    {
                        //controla si no hay gente en cola
                        if (lista[4] == "Aprendiz" && (string)listaAnterior[13] == "Libre")
                        {
                            float randomFinAtencion = (float)random.NextDouble();
                            lista.Add(randomFinAtencion);
                            float tiempoAtencion = desdeAprendiz + randomFinAtencion * (hastaAprendiz - desdeAprendiz);
                            lista.Add(tiempoAtencion);
                            lista.Add(listaAnterior[10]);
                            lista.Add(listaAnterior[11]);
                            lista.Add(tiempoAtencion + (float)lista[2]);
                            setEstadoOcupadoAprendiz = true;
                        }
                        if (lista[4] == "VeteranoA" && (string)listaAnterior[15] == "Libre")
                        {
                            float randomFinAtencion = (float)random.NextDouble();
                            lista.Add(randomFinAtencion);
                            float tiempoAtencion = desdeVeterarnoA + randomFinAtencion * (hastaVeterarnoA - desdeVeterarnoA);
                            lista.Add(tiempoAtencion);
                            lista.Add(tiempoAtencion + (float)lista[2]);
                            lista.Add(listaAnterior[11]);
                            lista.Add(listaAnterior[12]);
                            setEstadoOcupadoVeteranoA = true;
                        }
                        if (lista[4] == "VeteranoB" && (string)listaAnterior[17] == "Libre")
                        {
                            float randomFinAtencion = (float)random.NextDouble();
                            lista.Add(randomFinAtencion);
                            float tiempoAtencion = desdeVeterarnoB + randomFinAtencion * (hastaVeterarnoB - desdeVeterarnoB);
                            lista.Add(tiempoAtencion);
                            lista.Add(listaAnterior[10]);
                            lista.Add(tiempoAtencion + (float)lista[2]);
                            lista.Add(listaAnterior[12]);
                            setEstadoOcupadoVeteranoB = true;
                        }
                        //si hay cola
                        if (lista[4] == "Aprendiz" && (string)listaAnterior[13] == "Ocupado")
                        {
                            lista.Add(0);
                            lista.Add(0);
                            lista.Add(listaAnterior[10]);
                            lista.Add(listaAnterior[11]);
                            lista.Add(listaAnterior[12]);
                            incrementarColaApre = true;

                        }
                        if (lista[4] == "VeteranoA" && (string)listaAnterior[15] == "Ocupado")
                        {
                            lista.Add(0);
                            lista.Add(0);
                            lista.Add(listaAnterior[10]);
                            lista.Add(listaAnterior[11]);
                            lista.Add(listaAnterior[12]);
                            incrementarColaVeteA = true;
                        }
                        if (lista[4] == "VeteranoB" && (string)listaAnterior[17] == "Ocupado")
                        {
                            lista.Add(0);
                            lista.Add(0);
                            lista.Add(listaAnterior[10]);
                            lista.Add(listaAnterior[11]);
                            lista.Add(listaAnterior[12]);
                            incrementarColaVeteB = true;
                        }
                    }

                    //ve si es fin de atencion
                    //
                    //
                    else
                    {
                        //No hay cola
                        //hat que verificar quien esta atendiendo al cliente que se va, viendo el tiempo anterior cual es elmenor, vamos a prender una vandera
                        if ((int)listaAnterior[14] == 0 && seVaElAtendidoPorA)
                        {
                            lista.Add(0);
                            lista.Add(0);
                            lista.Add(listaAnterior[10]);
                            lista.Add(listaAnterior[11]);
                            lista.Add(0f);
                            setEstadoLibreAprendiz = true;
                            seVaElAtendidoPorA = false;
                            List<Cliente> copia = new List<Cliente>(listaCliente);
                            foreach (Cliente cliente in copia)
                            {
                                if (cliente.getEstado() == "SAA")
                                {
                                    listaCliente.Remove(cliente);
                                }
                            }
                        }
                        if ((int)listaAnterior[16] == 0 && seVaElAtendidoPorVA)
                        {
                            lista.Add(0);
                            lista.Add(0);
                            lista.Add(0f);
                            lista.Add(listaAnterior[11]);
                            lista.Add(listaAnterior[12]);
                            setEstadoLibreVeteA = true;
                            seVaElAtendidoPorVA = false;
                            List<Cliente> copia = new List<Cliente>(listaCliente);
                            foreach (Cliente cliente in copia)
                            {
                                if (cliente.getEstado() == "SAVA")
                                {
                                    listaCliente.Remove(cliente);
                                }
                            }
                        }
                        if ((int)listaAnterior[18] == 0 && seVaElAtendidoPorVB)
                        {
                            lista.Add(0);
                            lista.Add(0);
                            lista.Add(listaAnterior[10]);
                            lista.Add(0f);
                            lista.Add(listaAnterior[12]);
                            seVaElAtendidoPorVB = false;
                            setEstadoLibreVeteB = true;
                            List<Cliente> copia = new List<Cliente>(listaCliente);
                            foreach (Cliente cliente in copia)
                            {
                                if (cliente.getEstado() == "SAVB")
                                {
                                    listaCliente.Remove(cliente);
                                }
                            }
                        }
                        //Hay cola
                        if ((int)listaAnterior[14] != 0 && seVaElAtendidoPorA)
                        {
                            float randomFinAtencion = (float)random.NextDouble();
                            lista.Add(randomFinAtencion);
                            float tiempoAtencion = desdeAprendiz + randomFinAtencion * (hastaAprendiz - desdeAprendiz);
                            lista.Add(tiempoAtencion);
                            lista.Add(listaAnterior[10]);
                            lista.Add(listaAnterior[11]);
                            lista.Add(tiempoAtencion + (float)lista[2]);
                            decrementaColaApre = true;
                            seVaElAtendidoPorA = false;
                            bool yapaso = false;
                            int idClienteEstado = 0;
                            List<Cliente> copia = new List<Cliente>(listaCliente);
                            foreach (Cliente cliente in copia)
                            {
                                if (cliente.getEstado() == "SAA")
                                {
                                    listaCliente.Remove(cliente);
                                }
                                if (cliente.getEstado() == "EAA" && !yapaso)
                                {
                                    yapaso = true;
                                    idClienteEstado = cliente.getId();
                                }
                            }
                            foreach(Cliente cliente in listaCliente)
                            {
                                if(cliente.getId() == idClienteEstado)
                                {
                                    cliente.setEstado("SAA");
                                }
                            }
                        }
                        if ((int)listaAnterior[16] != 0 && seVaElAtendidoPorVA)
                        {
                            float randomFinAtencion = (float)random.NextDouble();
                            lista.Add(randomFinAtencion);
                            float tiempoAtencion = desdeVeterarnoA + randomFinAtencion * (hastaVeterarnoA - desdeVeterarnoA);
                            lista.Add(tiempoAtencion);
                            lista.Add(tiempoAtencion + (float)lista[2]);
                            lista.Add(listaAnterior[11]);
                            lista.Add(listaAnterior[12]);
                            decrementaColaVeteA = true;
                            seVaElAtendidoPorVA = false;
                            bool yapaso = false;
                            int idClienteEstado = 0;
                            List<Cliente> copia = new List<Cliente>(listaCliente);
                            foreach (Cliente cliente in copia)
                            {
                                if (cliente.getEstado() == "SAVA")
                                {
                                    listaCliente.Remove(cliente);
                                }
                                if (cliente.getEstado() == "EAVA" && !yapaso)
                                {
                                    yapaso = true;
                                    idClienteEstado = cliente.getId();
                                }
                            }
                            foreach (Cliente cliente in listaCliente)
                            {
                                if (cliente.getId() == idClienteEstado)
                                {
                                    cliente.setEstado("SAVA");
                                }
                            }
                        }
                        if ((int)listaAnterior[18] != 0 && seVaElAtendidoPorVB)
                        {
                            float randomFinAtencion = (float)random.NextDouble();
                            lista.Add(randomFinAtencion);
                            float tiempoAtencion = desdeVeterarnoB + randomFinAtencion * (hastaVeterarnoB - desdeVeterarnoB);
                            lista.Add(tiempoAtencion);
                            lista.Add(listaAnterior[10]);
                            lista.Add(tiempoAtencion + (float)lista[2]);
                            lista.Add(listaAnterior[12]);
                            decrementaColaVeteB = true;
                            seVaElAtendidoPorVB = false;
                            bool yapaso = false;
                            int idClienteEstado = 0;
                            List<Cliente> copia = new List<Cliente>(listaCliente);
                            foreach (Cliente cliente in copia)
                            {
                                if (cliente.getEstado() == "SAVB")
                                {
                                    listaCliente.Remove(cliente);
                                }
                                if (cliente.getEstado() == "EAVB" && !yapaso)
                                {
                                    yapaso = true;
                                    idClienteEstado = cliente.getId();
                                }
                            }
                            foreach (Cliente cliente in listaCliente)
                            {
                                if (cliente.getId() == idClienteEstado)
                                {
                                    cliente.setEstado("SAVB");
                                }
                            }
                        }
                    }

                }
                //Objetos permantes
                if (i == 0)
                {
                    lista.Add("Libre");
                    lista.Add(0);
                    lista.Add("Libre");
                    lista.Add(0);
                    lista.Add("Libre");
                    lista.Add(0);
                }
                else
                {
                    //Cuando esta en estado libre y pasa a ocuapado
                    if (setEstadoOcupadoAprendiz)
                    {
                        lista.Add("Ocupado");
                        lista.Add(0);
                        lista.Add(listaAnterior[15]);
                        lista.Add(listaAnterior[16]);
                        lista.Add(listaAnterior[17]);
                        lista.Add(listaAnterior[18]);
                        setEstadoOcupadoAprendiz = false;
                        tiempoLibreAprendiz = (float)listaAnterior[19] + ((float)lista[2] - (float)listaAnterior[2]);
                    }
                    else
                    {
                        if (setEstadoOcupadoVeteranoA)
                        {
                            lista.Add(listaAnterior[13]);
                            lista.Add(listaAnterior[14]);
                            lista.Add("Ocupado");
                            lista.Add(0);
                            lista.Add(listaAnterior[17]);
                            lista.Add(listaAnterior[18]);
                            setEstadoOcupadoVeteranoA = false;
                        }
                        else
                        {
                            if (setEstadoOcupadoVeteranoB)
                            {
                                lista.Add(listaAnterior[13]);
                                lista.Add(listaAnterior[14]);
                                lista.Add(listaAnterior[15]);
                                lista.Add(listaAnterior[16]);
                                lista.Add("Ocupado");
                                lista.Add(0);
                                setEstadoOcupadoVeteranoB = false;
                            }
                        }
                    }
                    //cuando esta en estado ocupado y hay que sumarle a la cola
                    if (incrementarColaApre)
                    {
                        lista.Add("Ocupado");
                        lista.Add((int)listaAnterior[14] + 1);
                        lista.Add(listaAnterior[15]);
                        lista.Add(listaAnterior[16]);
                        lista.Add(listaAnterior[17]);
                        lista.Add(listaAnterior[18]);
                        incrementarColaApre = false;
                    }
                    else
                    {
                        if (incrementarColaVeteA)
                        {
                            lista.Add(listaAnterior[13]);
                            lista.Add(listaAnterior[14]);
                            lista.Add("Ocupado");
                            lista.Add((int)listaAnterior[16] + 1);
                            lista.Add(listaAnterior[17]);
                            lista.Add(listaAnterior[18]);
                            incrementarColaVeteA = false;
                        }
                        else
                        {
                            if (incrementarColaVeteB)
                            {
                                lista.Add(listaAnterior[13]);
                                lista.Add(listaAnterior[14]);
                                lista.Add(listaAnterior[15]);
                                lista.Add(listaAnterior[16]);
                                lista.Add("Ocupado");
                                lista.Add((int)listaAnterior[18] + 1);
                                incrementarColaVeteB = false;
                            }
                        }
                    }
                    //cuando esta en estado ocupado y hay que pasarlo a estado libre
                    if (setEstadoLibreAprendiz)
                    {
                        lista.Add("Libre");
                        lista.Add(0);
                        lista.Add(listaAnterior[15]);
                        lista.Add(listaAnterior[16]);
                        lista.Add(listaAnterior[17]);
                        lista.Add(listaAnterior[18]);
                        setEstadoLibreAprendiz = false;
                    }
                    else
                    {
                        if (setEstadoLibreVeteA)
                        {
                            lista.Add(listaAnterior[13]);
                            lista.Add(listaAnterior[14]);
                            lista.Add("Libre");
                            lista.Add(0);
                            lista.Add(listaAnterior[17]);
                            lista.Add(listaAnterior[18]);
                            setEstadoLibreVeteA = false;
                        }
                        else
                        {
                            if (setEstadoLibreVeteB)
                            {
                                lista.Add(listaAnterior[13]);
                                lista.Add(listaAnterior[14]);
                                lista.Add(listaAnterior[15]);
                                lista.Add(listaAnterior[16]);
                                lista.Add("Libre");
                                lista.Add(0);
                                setEstadoLibreVeteB = false;
                            }
                        }
                    }
                    //cuando esta en estado ocupado y hay que decrementar cola
                    if (decrementaColaApre)
                    {
                        lista.Add("Ocupado");
                        lista.Add((int)listaAnterior[14] - 1);
                        lista.Add(listaAnterior[15]);
                        lista.Add(listaAnterior[16]);
                        lista.Add(listaAnterior[17]);
                        lista.Add(listaAnterior[18]);
                        decrementaColaApre = false;
                    }
                    else
                    {
                        if (decrementaColaVeteA)
                        {
                            lista.Add(listaAnterior[13]);
                            lista.Add(listaAnterior[14]);
                            lista.Add("Ocupado");
                            lista.Add((int)listaAnterior[16] - 1);
                            lista.Add(listaAnterior[17]);
                            lista.Add(listaAnterior[18]);
                            decrementaColaVeteA = false;
                        }
                        else
                        {
                            if (decrementaColaVeteB)
                            {
                                lista.Add(listaAnterior[13]);
                                lista.Add(listaAnterior[14]);
                                lista.Add(listaAnterior[15]);
                                lista.Add(listaAnterior[16]);
                                lista.Add("Ocupado");
                                lista.Add((int)listaAnterior[18] - 1);
                                decrementaColaVeteB = false;
                            }
                        }
                    }
                }
                if (i == 0)
                {
                    lista.Add(0f);
                    lista.Add(0);
                }
                else
                {
                    if ((string)listaAnterior[13] == "Libre" && (string)lista[13] == "Libre")
                    {
                        tiempoLibreAprendiz = (float)listaAnterior[19] + ((float)lista[2] - (float)listaAnterior[2]);
                    }
                    lista.Add(tiempoLibreAprendiz);
                    if (colaMax < ((int)lista[14] + (int)lista[16] + (int)lista[18]))
                    {
                        colaMax = (int)lista[14] + (int)lista[16] + (int)lista[18];
                    }
                    lista.Add(colaMax);
                }
                //Cosas de clientes si sos peluquero no te metas
                if (esLlegadaCliente && atiendeAprendiz)
                {
                    if ((int)lista[14] == 0 && (string)listaAnterior[13] == "Libre")
                    {
                        Cliente nuevoClienteAprendizSA = new Cliente("SAA", (float)lista[2]);
                        listaCliente.Add(nuevoClienteAprendizSA);
                    }
                    else
                    {
                        Cliente nuevoClienteAprendizEA = new Cliente("EAA", (float)lista[2]);
                        listaCliente.Add(nuevoClienteAprendizEA);
                    }
                    atiendeAprendiz = false;
                    esLlegadaCliente = false;
                }
                if (esLlegadaCliente && atiendeVeteA)
                {
                    if ((int)lista[16] == 0 && (string)listaAnterior[15] == "Libre")
                    {
                        Cliente nuevoClienteVeteASA = new Cliente("SAVA", (float)lista[2]);
                        listaCliente.Add(nuevoClienteVeteASA);
                    }
                    else
                    {
                        Cliente nuevoClienteVeteAEA = new Cliente("EAVA", (float)lista[2]);
                        listaCliente.Add(nuevoClienteVeteAEA);
                    }
                    atiendeVeteA = false;
                    esLlegadaCliente = false;
                }
                if (esLlegadaCliente && atiendeVeteB)
                {
                    if ((int)lista[18] == 0 && (string)listaAnterior[17] == "Libre")
                    {
                        Cliente nuevoClienteVetaBSA = new Cliente("SAVB", (float)lista[2]);
                        listaCliente.Add(nuevoClienteVetaBSA);
                    }
                    else
                    {
                        Cliente nuevoClienteVetaBEA = new Cliente("EAVB", (float)lista[2]);
                        listaCliente.Add(nuevoClienteVetaBEA);
                    }
                    atiendeVeteB = false;
                    esLlegadaCliente = false;
                }
                //la parte de eliminacion de clientes esta en la linea 347
                List<Cliente> copyClie = new List<Cliente>(listaCliente);
                foreach (Cliente cliente in copyClie)
                {
                    if (cliente.superasteLos30Min((float)lista[2]))
                    {
                        listaCliente.Remove(cliente);
                    }
                }
                //recorre y agrega datos de los clientes
                foreach (Cliente cliente in listaCliente)
                {
                    lista.Add(cliente.getId());
                    lista.Add(cliente.getEstado());
                    lista.Add(cliente.getTiempoLlegada());
                    lista.Add(cliente.getTiempoEspera());
                }

                MatrizMostrar.Add(lista);
                if (filaMax < lista.Count())
                {
                    filaMax = lista.Count();
                }
                if (i != 0)
                {
                    acumuladorMinutos += ((float)lista[2] - (float)listaAnterior[2]);
                }
                if ((float)lista[2] > (480f - (float)hastaClient))
                {
                    bastaClientes = true;
                }
                if (i != 0 && bastaClientes && (string)lista[13] == "Libre" && (string)lista[15] == "Libre" && (string)lista[17] == "Libre" && (int)lista[14] == 0 && (int)lista[16] == 0 && (int)lista[18] == 0)
                {
                    contadorDia += 1;
                    i = -1;
                    bastaClientes = false;
                }
                listaAnterior = lista;
                lista = new List<object>();
                seVaElAtendidoPorA = false;
                seVaElAtendidoPorVA = false;
                seVaElAtendidoPorVB = false;
                vanderaLlenoLlegadaCliente = false;
            }
        }

        private void txtTiempoSumu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // Permitir solo una coma
            if (e.KeyChar == ',' && (sender as TextBox).Text.Contains(","))
            {
                e.Handled = true;
            }
        }

        private void txtDesdeItera_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHastaItera_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtProbApren_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // Permitir solo una coma y asegurar que no sea el primer carácter
            if (e.KeyChar == ',' && ((sender as TextBox).Text.Contains(",") || (sender as TextBox).Text.Length == 0))
            {
                e.Handled = true;
            }
        }

        private void txtProbVeterA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // Permitir solo una coma y asegurar que no sea el primer carácter
            if (e.KeyChar == ',' && ((sender as TextBox).Text.Contains(",") || (sender as TextBox).Text.Length == 0))
            {
                e.Handled = true;
            }
        }

        private void txtProbVeterB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // Permitir solo una coma y asegurar que no sea el primer carácter
            if (e.KeyChar == ',' && ((sender as TextBox).Text.Contains(",") || (sender as TextBox).Text.Length == 0))
            {
                e.Handled = true;
            }
        }
    }
}