using System;
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

        int filaMax = 0;
        
        //estadisticas
        private int colaMax = 0;

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

            timmpoSimu = ((float)txtTiempoSumu.Value)*60;

            desdeItera = (float)txtDesdeItera.Value;

            hastaItera = (float)txtHastaItera.Value;

            simular();
        }

        public void simular()
        {
            bool incrementarColaApre = false;
            bool incrementarColaVeteA = false;
            bool incrementarColaVeteB = false;
            bool decrementaColaApre = false;
            bool decrementaColaVeteA = false;
            bool decrementaColaVeteB = false;
            bool vanderaLlenoLlegadaCliente = false;
            for(int i = 0; i< (desdeItera + hastaItera);i++)
            {
                //agrega evento
                if(i == 0)
                {
                    lista.Add("Inicializar");
                }
                //agrega evento
                else
                {
                    //para llegadaCliente
                    if ((float)listaAnterior[7] < (float)listaAnterior[10] && (float)listaAnterior[7] < (float)listaAnterior[11] && (float)listaAnterior[7] < (float)listaAnterior[12])
                    {
                        lista.Add("LlegadaCliente");
                    }
                    //Para Fin Atencion
                    else
                    {
                        lista.Add("FinAtencion");
                    }
                }
                //reloj dia
                if (i == 0)
                {
                    lista.Add(0);
                }
                else
                {
                    //controlar minutos del anterior
                    if ((int)listaAnterior[2] > 480 && (int)listaAnterior[14] == 0 && (int)listaAnterior[16] == 0 && (int)listaAnterior[18] == 0)
                    {
                        lista.Add((int)listaAnterior[1] + 1);
                    }
                }
                //reloj minutos
                if (i == 0)
                {
                    lista.Add(0f);
                }
                else
                {
                    //verifica en la lista anterior cual es el menor tiempo
                    if ((float)listaAnterior[7] < (float)listaAnterior[10] && (float)listaAnterior[7] < (float)listaAnterior[11] && (float)listaAnterior[7] < (float)listaAnterior[12]) 
                    {
                        lista.Add((float)listaAnterior[7]);
                    }
                    else
                    {
                        if ((float)listaAnterior[10] <= (float)listaAnterior[11] && (float)listaAnterior[10] <= (float)listaAnterior[12])
                        {
                            lista.Add((float)listaAnterior[10]);
                        }
                        else if ((float)listaAnterior[11] <= (float)listaAnterior[10] && (float)listaAnterior[11] <= (float)listaAnterior[12])
                        {
                            lista.Add((float)listaAnterior[11]);
                        }
                        else
                        {
                            lista.Add((float)listaAnterior[12]);
                        } 
                    }
                }

                //RNDLlegadaCliente
                if(i == 0)
                {
                    lista.Add(0);
                }
                else
                {
                    //para llegadaCliente
                    if ((float)listaAnterior[7] < (float)listaAnterior[10] && (float)listaAnterior[7] < (float)listaAnterior[11] && (float)listaAnterior[7] < (float)listaAnterior[12])
                    {
                        float randomQuienAtiende = (float) random.NextDouble();
                        lista.Add(randomQuienAtiende);
                        if (randomQuienAtiende < probAprendiz)
                        {
                            lista.Add("Aprendiz");
                        }
                        else {
                            if (randomQuienAtiende < probAprendiz + probVeteranoA)
                            {
                                lista.Add("VeteranoA");
                            }
                            else
                            {
                                if (randomQuienAtiende < probAprendiz + probVeteranoA + probVeteranoB)
                                {
                                    lista.Add("VeteranoB");
                                }
                            }
                        }
                    }
                    //Para Fin Atencion
                    else
                    {
                        if((int)listaAnterior[14] == 0 && (int)listaAnterior[16] == 0 && (int)listaAnterior[18] == 0)
                        {
                            lista.Add(0f);
                            lista.Add(0f);
                            lista.Add(0f);
                            lista.Add(0f);
                            lista.Add(listaAnterior[7]);
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
                if(i == 0)
                {
                    lista.Add(0);
                    lista.Add(0);
                    lista.Add(0);
                    lista.Add(0);
                    lista.Add(0);
                }
                else
                {
                    //ve si es llegada de cliente
                    if ((float)listaAnterior[7] < (float)listaAnterior[10] && (float)listaAnterior[7] < (float)listaAnterior[11] && (float)listaAnterior[7] < (float)listaAnterior[12])
                    {
                        //controla si no hay gente en cola
                        if(lista[4] == "Aprendiz" && (string)listaAnterior[13] == "Libre") {
                            float randomFinAtencion = (float)random.NextDouble();
                            lista.Add(randomFinAtencion);
                            float tiempoAtencion = desdeAprendiz + randomFinAtencion * (hastaAprendiz - desdeAprendiz);
                            lista.Add(tiempoAtencion);
                            lista.Add(listaAnterior[10]);
                            lista.Add(listaAnterior[11]);
                            lista.Add(tiempoAtencion + (float)lista[2]);

                        }
                        if(lista[4] == "VeteranoA"&& (string)listaAnterior[15] == "Libre"){
                            float randomFinAtencion = (float)random.NextDouble();
                            lista.Add(randomFinAtencion);
                            float tiempoAtencion = desdeVeterarnoA + randomFinAtencion * (hastaVeterarnoA - desdeVeterarnoA);
                            lista.Add(tiempoAtencion);
                            lista.Add(tiempoAtencion + (float)lista[2]);
                            lista.Add(listaAnterior[11]);
                            lista.Add(listaAnterior[12]);
                        }
                        if(lista[4] == "VeteranoB" && (string)listaAnterior[17] == "Libre") {
                            float randomFinAtencion = (float)random.NextDouble();
                            lista.Add(randomFinAtencion);
                            float tiempoAtencion = desdeVeterarnoB + randomFinAtencion * (hastaVeterarnoB - desdeVeterarnoB);
                            lista.Add(tiempoAtencion);
                            lista.Add(listaAnterior[10]);
                            lista.Add(tiempoAtencion + (float)lista[2]);
                            lista.Add(listaAnterior[12]);
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
                    else
                    {
                        //No hay cola
                        if ((int)listaAnterior[14] == 0 && lista[4] == "Aprendiz")
                        {
                            lista.Add(0);
                            lista.Add(0);
                            lista.Add(listaAnterior[10]);
                            lista.Add(listaAnterior[11]);
                            lista.Add(listaAnterior[12]);
                        }
                        if ((int)listaAnterior[16] == 0 && lista[4] == "VeteranoA")
                        {
                            lista.Add(0);
                            lista.Add(0);
                            lista.Add(listaAnterior[10]);
                            lista.Add(listaAnterior[11]);
                            lista.Add(listaAnterior[12]);
                        }
                        if ((int)listaAnterior[18] == 0 && lista[4] == "VeteranoB")
                        {
                            lista.Add(0);
                            lista.Add(0);
                            lista.Add(listaAnterior[10]);
                            lista.Add(listaAnterior[11]);
                            lista.Add(listaAnterior[12]);
                        }
                        //Hay cola
                        if ((int)listaAnterior[14] != 0 && lista[4] == "Aprendiz")
                        {
                            float randomFinAtencion = (float)random.NextDouble();
                            lista.Add(randomFinAtencion);
                            float tiempoAtencion = desdeAprendiz + randomFinAtencion * (hastaAprendiz - desdeAprendiz);
                            lista.Add(tiempoAtencion);
                            lista.Add(listaAnterior[10]);
                            lista.Add(listaAnterior[11]);
                            lista.Add(tiempoAtencion + (float)lista[2]);
                            decrementaColaApre = true;
                        }
                        if ((int)listaAnterior[16] != 0 && lista[4] == "VeteranoA")
                        {
                            float randomFinAtencion = (float)random.NextDouble();
                            lista.Add(randomFinAtencion);
                            float tiempoAtencion = desdeVeterarnoA + randomFinAtencion * (hastaVeterarnoA - desdeVeterarnoA);
                            lista.Add(tiempoAtencion);
                            lista.Add(tiempoAtencion + (float)lista[2]);
                            lista.Add(listaAnterior[11]);
                            lista.Add(listaAnterior[12]);
                            decrementaColaVeteA = true;
                        }
                        if ((int)listaAnterior[18] != 0 && lista[4] == "VeteranoB")
                        {
                            float randomFinAtencion = (float)random.NextDouble();
                            lista.Add(randomFinAtencion);
                            float tiempoAtencion = desdeVeterarnoB + randomFinAtencion * (hastaVeterarnoB - desdeVeterarnoB);
                            lista.Add(tiempoAtencion);
                            lista.Add(listaAnterior[10]);
                            lista.Add(tiempoAtencion + (float)lista[2]);
                            lista.Add(listaAnterior[12]);
                            decrementaColaVeteB = true;
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
                    if (listaAnterior[13] == "Libre")
                    {
                        lista.Add("Ocupado");
                    }
                    else
                    {
                       
                    }
                }
            }
        }
    }
}