using System;
using System.Drawing.Drawing2D;
using System.Numerics;
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
        private List<Posicion> paraClientes = new List<Posicion>();

        //RK
        private float h;
        private float coefA;
        private float coefB;
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

            h = float.Parse(txth.Text);
            coefA= float.Parse(txtCoefA.Text);
            coefB = float.Parse(txtCoefB.Text);
            

            if (desdeAprendiz >= 0 && hastaAprendiz >= 0 && desdeVeterarnoA >= 0 && hastaVeterarnoA >= 0 && desdeVeterarnoB >= 0 && hastaVeterarnoB >= 0 && hastaAprendiz > desdeAprendiz && hastaVeterarnoA > desdeVeterarnoA && hastaVeterarnoB > desdeVeterarnoB && hastaClient > desdeClient)
            {
                if ((probVeteranoA + probVeteranoB + probAprendiz) == 1f)
                {
                    simular();

                    if (MatrizMostrar.Count() >= (desdeItera + hastaItera))
                    {
                        List<List<object>> subMatrix = MatrizMostrar.GetRange((int)desdeItera, (int)hastaItera);
                        if (checkBox1.Checked)
                        {
                            Mostrar mostrar = new Mostrar(MatrizMostrar, filaMax);
                            mostrar.Show();
                        }
                        else
                        {
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
            else {
                MessageBox.Show("Ningun desde puede ser mayor o igual a un hasta");
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
            RK rK = new RK();
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
                    float llegadaVeteranoa = (float)listaAnterior[11];
                    float llegadaVeteranoB = (float)listaAnterior[12];
                    float llegadaAprendis = (float)listaAnterior[13];
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

                    float finAtencionVeteranoA = (float)listaAnterior[11];
                    float finAtencionVeteranoB = (float)listaAnterior[12];
                    float finAtencionAprendiz = (float)listaAnterior[13];
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
                            lista.Add((float)listaAnterior[11]);
                            seVaElAtendidoPorVA = true;
                        }
                        else if (minimo.HasValue && minimo == finAtencionVeteranoB)
                        {
                            lista.Add((float)listaAnterior[12]);
                            seVaElAtendidoPorVB = true;
                        }
                        else
                        {
                            lista.Add((float)listaAnterior[13]);
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
                    float llegadaVeteranoa = (float)listaAnterior[11];
                    float llegadaVeteranoB = (float)listaAnterior[12];
                    float llegadaAprendis = (float)listaAnterior[13];
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
                //AGREGAR COMPLEGIDAD
                //finAtencion
                if (i == 0)
                {
                    lista.Add(0f);
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

                    float llegadaVeteranoa = (float)listaAnterior[11];
                    float llegadaVeteranoB = (float)listaAnterior[12];
                    float llegadaAprendis = (float)listaAnterior[13];
                    float LlegadaCliente = (float)listaAnterior[7];
                    List<float> variables = new List<float> { (float)llegadaVeteranoa, (float)llegadaVeteranoB, (float)llegadaAprendis, (float)LlegadaCliente };
                    List<float> variablesNoCero = variables.Where(v => v != 0f).ToList();
                    // Encontrar el valor mínimo de la lista que no tiene ceros
                    float? minimo = variablesNoCero.Count > 0 ? (float?)variablesNoCero.Min() : null;

                    if (minimo.HasValue && minimo == LlegadaCliente && !bastaClientes)
                    {
                        //controla si no hay gente en cola
                        if (lista[4] == "Aprendiz" && (string)listaAnterior[14] == "Libre")
                        {
                            float randomFinAtencion = (float)random.NextDouble();
                            lista.Add(randomFinAtencion);
                            lista.Add(0f);
                            float tiempoAtencion = desdeAprendiz + randomFinAtencion * (hastaAprendiz - desdeAprendiz);
                            lista.Add(tiempoAtencion);
                            lista.Add(listaAnterior[11]);
                            lista.Add(listaAnterior[12]);
                            lista.Add(tiempoAtencion + (float)lista[2]);
                            setEstadoOcupadoAprendiz = true;
                        }
                        if (lista[4] == "VeteranoA" && (string)listaAnterior[16] == "Libre")
                        {
                            float randomFinAtencion = (float)random.NextDouble();
                            lista.Add(randomFinAtencion);
                            lista.Add(0f);
                            float tiempoAtencion = desdeVeterarnoA + randomFinAtencion * (hastaVeterarnoA - desdeVeterarnoA);
                            lista.Add(tiempoAtencion);
                            lista.Add(tiempoAtencion + (float)lista[2]);
                            lista.Add(listaAnterior[12]);
                            lista.Add(listaAnterior[13]);
                            setEstadoOcupadoVeteranoA = true;
                        }
                        if (lista[4] == "VeteranoB" && (string)listaAnterior[18] == "Libre")
                        {
                            float randomFinAtencion = (float)random.NextDouble();
                            lista.Add(randomFinAtencion);
                            float complejidad = (float) (desdeVeterarnoB + randomFinAtencion * (hastaVeterarnoB - desdeVeterarnoB));
                            lista.Add(complejidad);
                            float tiempo = rK.RungeKutta4(h, complejidad, coefA, coefB, hastaVeterarnoB);
                            lista.Add(tiempo);
                            lista.Add(listaAnterior[11]);
                            //RK
                            lista.Add(tiempo + (float)lista[2]);
                            lista.Add(listaAnterior[13]);
                            setEstadoOcupadoVeteranoB = true;
                        }
                        //si hay cola
                        if (lista[4] == "Aprendiz" && (string)listaAnterior[14] == "Ocupado")
                        {
                            lista.Add(0);
                            lista.Add(0);
                            lista.Add(0);
                            lista.Add(listaAnterior[11]);
                            lista.Add(listaAnterior[12]);
                            lista.Add(listaAnterior[13]);
                            incrementarColaApre = true;

                        }
                        if (lista[4] == "VeteranoA" && (string)listaAnterior[16] == "Ocupado")
                        {
                            lista.Add(0);
                            lista.Add(0);
                            lista.Add(0);
                            lista.Add(listaAnterior[11]);
                            lista.Add(listaAnterior[12]);
                            lista.Add(listaAnterior[13]);
                            incrementarColaVeteA = true;
                        }
                        if (lista[4] == "VeteranoB" && (string)listaAnterior[18] == "Ocupado")
                        {
                            lista.Add(0);
                            lista.Add(0);
                            lista.Add(0);
                            lista.Add(listaAnterior[11]);
                            lista.Add(listaAnterior[12]);
                            lista.Add(listaAnterior[13]);
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
                        if ((int)listaAnterior[15] == 0 && seVaElAtendidoPorA)
                        {
                            lista.Add(0);
                            lista.Add(0);
                            lista.Add(0);
                            lista.Add(listaAnterior[11]);
                            lista.Add(listaAnterior[12]);
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
                        if ((int)listaAnterior[17] == 0 && seVaElAtendidoPorVA)
                        {
                            lista.Add(0);
                            lista.Add(0);
                            lista.Add(0);
                            lista.Add(0f);
                            lista.Add(listaAnterior[12]);
                            lista.Add(listaAnterior[13]);
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
                        if ((int)listaAnterior[19] == 0 && seVaElAtendidoPorVB)
                        {
                            lista.Add(0);
                            lista.Add(0);
                            lista.Add(0);
                            lista.Add(listaAnterior[11]);
                            lista.Add(0f);
                            lista.Add(listaAnterior[13]);
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
                        if ((int)listaAnterior[15] != 0 && seVaElAtendidoPorA)
                        {
                            float randomFinAtencion = (float)random.NextDouble();
                            lista.Add(randomFinAtencion);
                            lista.Add(0);
                            float tiempoAtencion = desdeAprendiz + randomFinAtencion * (hastaAprendiz - desdeAprendiz);
                            lista.Add(tiempoAtencion);
                            lista.Add(listaAnterior[11]);
                            lista.Add(listaAnterior[12]);
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
                        if ((int)listaAnterior[17] != 0 && seVaElAtendidoPorVA)
                        {
                            float randomFinAtencion = (float)random.NextDouble();
                            lista.Add(randomFinAtencion);
                            lista.Add(0);
                            float tiempoAtencion = desdeVeterarnoA + randomFinAtencion * (hastaVeterarnoA - desdeVeterarnoA);
                            lista.Add(tiempoAtencion);
                            lista.Add(tiempoAtencion + (float)lista[2]);
                            lista.Add(listaAnterior[12]);
                            lista.Add(listaAnterior[13]);
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
                        if ((int)listaAnterior[19] != 0 && seVaElAtendidoPorVB)
                        {
                            float randomFinAtencion = (float)random.NextDouble();
                            lista.Add(randomFinAtencion);
                            float complejidad = (float) (desdeVeterarnoB + randomFinAtencion * (hastaVeterarnoB - desdeVeterarnoB));
                            lista.Add(complejidad);
                            float tiempo = rK.RungeKutta4(h, complejidad, coefA, coefB, hastaVeterarnoB);
                            lista.Add(tiempo);
                            lista.Add(listaAnterior[11]);
                            lista.Add(tiempo + (float)lista[2]);
                            lista.Add(listaAnterior[13]);
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
                        lista.Add(listaAnterior[16]);
                        lista.Add(listaAnterior[17]);
                        lista.Add(listaAnterior[18]);
                        lista.Add(listaAnterior[19]);
                        setEstadoOcupadoAprendiz = false;
                        tiempoLibreAprendiz = (float)listaAnterior[20] + ((float)lista[2] - (float)listaAnterior[2]);
                    }
                    else
                    {
                        if (setEstadoOcupadoVeteranoA)
                        {
                            lista.Add(listaAnterior[14]);
                            lista.Add(listaAnterior[15]);
                            lista.Add("Ocupado");
                            lista.Add(0);
                            lista.Add(listaAnterior[18]);
                            lista.Add(listaAnterior[19]);
                            setEstadoOcupadoVeteranoA = false;
                        }
                        else
                        {
                            if (setEstadoOcupadoVeteranoB)
                            {
                                lista.Add(listaAnterior[14]);
                                lista.Add(listaAnterior[15]);
                                lista.Add(listaAnterior[16]);
                                lista.Add(listaAnterior[17]);
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
                        lista.Add((int)listaAnterior[15] + 1);
                        lista.Add(listaAnterior[16]);
                        lista.Add(listaAnterior[17]);
                        lista.Add(listaAnterior[18]);
                        lista.Add(listaAnterior[19]);
                        incrementarColaApre = false;
                    }
                    else
                    {
                        if (incrementarColaVeteA)
                        {
                            lista.Add(listaAnterior[14]);
                            lista.Add(listaAnterior[15]);
                            lista.Add("Ocupado");
                            lista.Add((int)listaAnterior[17] + 1);
                            lista.Add(listaAnterior[18]);
                            lista.Add(listaAnterior[19]);
                            incrementarColaVeteA = false;
                        }
                        else
                        {
                            if (incrementarColaVeteB)
                            {
                                lista.Add(listaAnterior[14]);
                                lista.Add(listaAnterior[15]);
                                lista.Add(listaAnterior[16]);
                                lista.Add(listaAnterior[17]);
                                lista.Add("Ocupado");
                                lista.Add((int)listaAnterior[19] + 1);
                                incrementarColaVeteB = false;
                            }
                        }
                    }
                    //cuando esta en estado ocupado y hay que pasarlo a estado libre
                    if (setEstadoLibreAprendiz)
                    {
                        lista.Add("Libre");
                        lista.Add(0);
                        lista.Add(listaAnterior[16]);
                        lista.Add(listaAnterior[17]);
                        lista.Add(listaAnterior[18]);
                        lista.Add(listaAnterior[19]);
                        setEstadoLibreAprendiz = false;
                    }
                    else
                    {
                        if (setEstadoLibreVeteA)
                        {
                            lista.Add(listaAnterior[14]);
                            lista.Add(listaAnterior[15]);
                            lista.Add("Libre");
                            lista.Add(0);
                            lista.Add(listaAnterior[18]);
                            lista.Add(listaAnterior[19]);
                            setEstadoLibreVeteA = false;
                        }
                        else
                        {
                            if (setEstadoLibreVeteB)
                            {
                                lista.Add(listaAnterior[14]);
                                lista.Add(listaAnterior[15]);
                                lista.Add(listaAnterior[16]);
                                lista.Add(listaAnterior[17]);
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
                        lista.Add((int)listaAnterior[15] - 1);
                        lista.Add(listaAnterior[16]);
                        lista.Add(listaAnterior[17]);
                        lista.Add(listaAnterior[18]);
                        lista.Add(listaAnterior[19]);
                        decrementaColaApre = false;
                    }
                    else
                    {
                        if (decrementaColaVeteA)
                        {
                            lista.Add(listaAnterior[14]);
                            lista.Add(listaAnterior[15]);
                            lista.Add("Ocupado");
                            lista.Add((int)listaAnterior[17] - 1);
                            lista.Add(listaAnterior[18]);
                            lista.Add(listaAnterior[19]);
                            decrementaColaVeteA = false;
                        }
                        else
                        {
                            if (decrementaColaVeteB)
                            {
                                lista.Add(listaAnterior[14]);
                                lista.Add(listaAnterior[15]);
                                lista.Add(listaAnterior[16]);
                                lista.Add(listaAnterior[17]);
                                lista.Add("Ocupado");
                                lista.Add((int)listaAnterior[19] - 1);
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
                    if ((string)listaAnterior[14] == "Libre" && (string)lista[14] == "Libre")
                    {
                        tiempoLibreAprendiz = (float)listaAnterior[20] + ((float)lista[2] - (float)listaAnterior[2]);
                    }
                    lista.Add(tiempoLibreAprendiz);
                    if (colaMax < ((int)lista[15] + (int)lista[17] + (int)lista[19]))
                    {
                        colaMax = (int)lista[15] + (int)lista[17] + (int)lista[19];
                    }
                    lista.Add(colaMax);
                }
                //Cosas de clientes si sos peluquero no te metas
                if (esLlegadaCliente && atiendeAprendiz)
                {
                    if ((int)lista[15] == 0 && (string)listaAnterior[14] == "Libre")
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
                    if ((int)lista[17] == 0 && (string)listaAnterior[16] == "Libre")
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
                    if ((int)lista[19] == 0 && (string)listaAnterior[18] == "Libre")
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
                
                //Sacampos los clientes que estan en listaAnterior

                if (listaAnterior.Count > 21) 
                {
                    int posicion = 0;
                    Cliente cli = new Cliente();
                    for (int j = 22; j < listaAnterior.Count; j++)
                    {
                        // aca
                        if (listaAnterior[j] is not "") 
                        {
                            if (listaAnterior[j] is int)
                            {
                               posicion = j;
                               foreach(Cliente cliente in listaCliente)
                               {
                                    if ((int)listaAnterior[j] == cliente.getId())
                                    {
                                        Posicion pos = new Posicion(cliente, posicion);
                                        paraClientes.Add(pos);
                                    }
                               }
                            }
                        }
                    }
                }
                //Mostrar
                for (int l = 22; l < listaAnterior.Count(); l++)
                {
                    lista.Add("");
                }

                foreach (Posicion pos in paraClientes)
                {
                    lista[pos.getPosicion()] = pos.getCliente().getId();
                    lista[pos.getPosicion()+1] = pos.getCliente().getEstado();
                    lista[pos.getPosicion()+2] = pos.getCliente().getTiempoLlegada();
                    lista[pos.getPosicion()+3] = pos.getCliente().getTiempoEspera();
                }

                List<Cliente> copyClient = new List<Cliente>(listaCliente);
                foreach (Cliente cliente in listaCliente)
                {
                    foreach (Posicion pos in paraClientes) 
                    {
                        if (cliente.getId() == pos.getCliente().getId()) 
                        {
                            copyClient.Remove(cliente);
                        }
                    }
                }

                this.paraClientes = new List<Posicion>();
                List<Object> copyLista = new List<object>(lista);
                foreach (Cliente cli in copyClient)
                {
                    bool seAgrego = false;
                    bool yaPaso = false;
                    for (int a = 22; a < copyLista.Count; a += 4)
                    {
                        if (!yaPaso && copyLista[a] is "")
                        {
                            lista[a] = cli.getId();
                            lista[a+1] = cli.getEstado();
                            lista[a+2] = cli.getTiempoLlegada();
                            lista[a+3] = cli.getTiempoEspera();
                            seAgrego = true;
                            yaPaso = true;
                        }
                    }
                    if(!seAgrego)
                    {
                        lista.Add(cli.getId());
                        lista.Add(cli.getEstado());
                        lista.Add(cli.getTiempoLlegada());
                        lista.Add(cli.getTiempoEspera());
                    }
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
                if (i != 0 && bastaClientes && (string)lista[14] == "Libre" && (string)lista[16] == "Libre" && (string)lista[18] == "Libre" && (int)lista[15] == 0 && (int)lista[17] == 0 && (int)lista[19] == 0)
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