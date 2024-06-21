using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class RK
    {
        private static List<List<float>> tablaRK = new List<List<float>>();
        public static float Derivative(float t,float coefA,float coefB)
        {
            return (coefA * (float) Math.Sqrt(t + coefB));
        }

        public static float RungeKutta4(float t0, float y0, float h, float C,float coefA,float coefB)
        {
            if (tablaRK.Count == 0)
            {
                float t = t0;
                float y = y0;
                int i = 0;
                while (y <= C)
                {
                    if (i >= tablaRK.Count)
                    {
                        tablaRK.Add(new List<float>());
                    }

                    float tAnt = t;
                    float yAnt = y;
                    float k1 = h * Derivative(t, coefA, coefB);
                    float k2 = h * Derivative(t + h / 2.0f, coefA, coefB);
                    float k3 = h * Derivative(t + h / 2.0f, coefA, coefB);
                    float k4 = h * Derivative(t + h, coefA, coefB);

                    y += (k1 + 2 * k2 + 2 * k3 + k4) / 6.0f;
                    t += h;


                    tablaRK[i].Add(tAnt);
                    tablaRK[i].Add(yAnt);
                    tablaRK[i].Add(k1);
                    tablaRK[i].Add(k2);
                    tablaRK[i].Add(k3);
                    tablaRK[i].Add(k4);
                    tablaRK[i].Add(t);
                    tablaRK[i].Add(y);

                    i++;
                    if (y > coefB)
                    {
                        break;
                    }
                }
            }
            float devolver = 0f;
            bool paso = false;
            for (int i = 0; i < tablaRK.Count; i++) {
                if (!paso && tablaRK[i][1] > C) {
                   devolver =  tablaRK[i][0];
                   paso = true;
                }
            }
            return devolver;
            
        }
    }
}
